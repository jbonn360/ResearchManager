using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using SimpleBrowser;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;

namespace SearchResultAggregator
{
    public partial class Form1 : Form
    {
        private List<string> searchUris;
        private List<Record> records;        

        private int totalRecordsHit, duplicatesFound;

        public Form1()
        {
            InitializeComponent();
            records = new List<Record>();
            searchUris = new List<string>();
            totalRecordsHit = 0;
            duplicatesFound = 0;
            lblCopied.Text = "";

            //Test - remove me
            for(int i = 0; i < 200; i++)
            {
                records.Add(new Record("Study 1", "www.google.com"));
                records.Add(new Record("Study 2", "www.google.com"));
                records.Add(new Record("Study 3", "www.google.com"));
                records.Add(new Record("Study 3", "www.google.com"));
            }
            
            UpdateGridView();
            UpdateStatistics();
            //End test
        }

        private void UpdateGridView()
        {
            dataGridView1.Rows.Clear();

            //Sorting records
            records = records.OrderBy(r => r.Title).ToList();

            foreach(var record in records)
            {
                var row = new DataGridViewRow();
                var titleCell = new DataGridViewLinkCell();
                titleCell.Value = record.Title;
                row.Cells.Add(titleCell);
                switch (record.Status)
                {
                    case Status.DiscardedFullText: {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        }break;
                    case Status.DiscardedTitleAbs:
                        {
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                        }break;
                    case Status.Duplicate:
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }break;
                }
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.ClearSelection();
        }

        private List<string> GetSearchUris()
        {
            const int BufferSize = 128;
            List<string> result = new List<string>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Searches.txt");
            using (var fileStream = File.OpenRead(filePath))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.StartsWith("search.url."))
                        {
                            string[] splitLine = line.Split(new[] { '=' }, 2);
                            string uri = splitLine[1];
                            result.Add(uri);
                        }
                        else
                            continue;
                    }
                }
            }
            return result;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            searchUris = GetSearchUris();            

            string errorMessage = "";
            lblError.Text = "";

            foreach (var uri in searchUris)
            {
                //Check if uri is empty
                if (String.IsNullOrEmpty(uri))
                {
                    //Show message
                    continue;
                }

                //Check if entered value is URI
                Uri uriResult;
                bool result = Uri.TryCreate(uri, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!result)
                {
                    //Show error message
                    continue;
                }

                //Adding newly gathered data to master list
                records.AddRange(GetData(uri, ref errorMessage));
            }

            //Total records retrieved
            totalRecordsHit = records.Count;

            //Remove duplicates
            records = records.GroupBy(r => r.Title).Select(g => g.First()).ToList();

            //The ones which have been removed are duplicates
            duplicatesFound = totalRecordsHit - records.Count;

            lblTotalHits.Text = totalRecordsHit.ToString();
            UpdateStatistics();

            UpdateGridView();                               
        }

        private List<Record> GetData(string uri, ref string errorMessage)
        {
            Uri uriObj = new Uri(uri);
            WebScrapingTools wst = new WebScrapingTools();
            var records = new List<Record>();

            switch (uriObj.Host)
            {
                case "hydi.um.edu.mt":
                    {
                        //records = wst.GetDataFromHydi(uri);
                        records = wst.GetDataFromHyDi(uri, ref errorMessage);
                    }
                    break;
                case "www.ncbi.nlm.nih.gov":
                    {
                        records = wst.GetDataFromPubMed(uri, GetPubMedOptions(), ref errorMessage);
                    }
                    break;
                case "scholar.google.com":
                    {
                        records = wst.GetDataFromScholar(uri, ref errorMessage);
                    }
                    break;
                default:
                    {
                        errorMessage +=  "Error: Host " + uriObj.Host + ", is not currently supported.\n";
                        return null;
                    }
            }

            return records;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            dtTo.Value = DateTime.Now;
        }

        private void chkUseDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtTo.Enabled = chkUseDateFilter.Checked;
            dtFrom.Enabled = chkUseDateFilter.Checked;
        }

        private PubMedOptions GetPubMedOptions()
        {
            PubMedOptions pmo = new PubMedOptions(
               chkAbstract.Checked,
               chkFreeFull.Checked,
               chkFullText.Checked,
               chkHumans.Checked,
               chkAnimals.Checked);

            if (chkUseDateFilter.Checked)
            {
                pmo.SetFilterDateRage(dtFrom.Value, dtTo.Value);
            }

            return pmo;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //If we have clicked a link
            if (dgv.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
            {
                Record record = records.ElementAt(e.RowIndex);
                if(record.Link != null)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(record.Link);
                    Process.Start(psi);
                }                
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex > 0)
            {
                for(int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[1, i].Selected = true;
                }
            }
        }

        private void btnCopyUnmarked_Click(object sender, EventArgs e)
        {
            lblCopied.Text = "Unmarked records copied to clip board.";
        }

        private void btnCopyTitleAbs_Click(object sender, EventArgs e)
        {
            lblCopied.Text = "Discarded (Title & Abstract) records copied to clip board.";
        }

        private void btnCopyFullText_Click(object sender, EventArgs e)
        {
            lblCopied.Text = "Discarded (Full Text) records copied to clip board.";
        }

        private void btnMarkDuplicate_Click(object sender, EventArgs e)
        {            
            if (btnMarkDuplicate.Enabled)
            {
                btnMarkDuplicate.Enabled = false;
                btnMarkDuplicate.BackColor = Color.LightGray;
                UpdateSelectedRecordsStatus(Status.Duplicate);
                btnMarkDuplicate.Enabled = true;
                btnMarkDuplicate.BackColor = Color.Red;
            }
            
        }

        private void btnMarkDiscTitleAbs_Click(object sender, EventArgs e)
        {
            UpdateSelectedRecordsStatus(Status.DiscardedTitleAbs);
        }

        private void btnMarkDiscFullText_Click(object sender, EventArgs e)
        {
            UpdateSelectedRecordsStatus(Status.DiscardedFullText);
        }

        private void btnUnmark_Click(object sender, EventArgs e)
        {
            UpdateSelectedRecordsStatus(Status.Unmarked);
        }

        private void UpdateSelectedRecordsStatus(Status status)
        {
            if(dataGridView1.RowCount == records.Count)
            {
                //int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int selectedIndex = dataGridView1.CurrentRow.Index;
                Record curRecord = records[selectedIndex];
                Record newRecord = curRecord;
                newRecord.Status = status;
                records[selectedIndex] = newRecord;

                UpdateGridView();

                dataGridView1.ClearSelection();
                //dataGridView1.CurrentCell = dataGridView1.Rows[selectedIndex].Cells[0];

                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[selectedIndex].Index;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnMarkDuplicate.Enabled = true;
            dataGridView1.ClearSelection();
        }

        private void UpdateStatistics()
        {
            int duplicatesMarked = records.Where(r => r.Status == Status.Duplicate).Count();
            int discFullTextMarked = records.Where(r => r.Status == Status.DiscardedFullText).Count();
            int discTitleAbstract = records.Where(r => r.Status == Status.DiscardedTitleAbs).Count();
            int unmarked = records.Where(r => r.Status == Status.Unmarked).Count();

            //Display statistics
            lblSearches.Text = searchUris.Count.ToString();

            lblDuplicates.Text = (duplicatesFound + duplicatesMarked).ToString();
            lblUniques.Text = (records.Count - duplicatesMarked).ToString();

            lblTitleAbs.Text = discTitleAbstract.ToString();
            lblFullText.Text = discFullTextMarked.ToString();
            lblUnmarked.Text = unmarked.ToString();       
        }

    }

    internal class RecordComparer : EqualityComparer<Record>
    {
        public override bool Equals(Record x, Record y)
        {
            return x.Title.Equals(y.Title);
        }

        public override int GetHashCode(Record obj)
        {
            return base.GetHashCode();
        }
    }
}
