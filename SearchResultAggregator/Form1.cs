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
        private List<Record> markedDuplicates;
        private List<Record> markedTitleAbst;
        private List<Record> markedFullText;

        private int totalRecordsHit, duplicatesFound;

        public Form1()
        {
            InitializeComponent();
            records = new List<Record>();
            searchUris = new List<string>();
            markedDuplicates = new List<Record>();
            totalRecordsHit = 0;
            duplicatesFound = 0;
            lblCopied.Text = "";

            //Test - remove me
            records.Add(new Record("Study 1", "www.google.com"));
            records.Add(new Record("Study 2", "www.google.com"));
            records.Add(new Record("Study 3", "www.google.com"));
            records.Add(new Record("Study 3", "www.google.com"));
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
                dataGridView1.Rows.Add(new object[] { "", "", "", record.Title });
            }
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
            //If we have clicked a button 
            if(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn  && e.RowIndex >= 0)
            {
                HandleButtonActions(e);
            }
            //If we have clicked a link
            else if (dgv.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
            {
                Record record = records.ElementAt(e.RowIndex);
                if(record.Link != null)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(record.Link);
                    Process.Start(psi);
                }                
            }
        }

        private void HandleButtonActions(DataGridViewCellEventArgs e)
        {
            DataGridViewButtonCell button =
                ((DataGridViewButtonCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            switch (e.ColumnIndex)
            {
                //Duplicate button
                case 0:
                    {
                        if (button.Value.ToString().Equals("Unmark"))
                        {
                            //remove record from markedDuplicates list
                            string recordTitle = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                            markedDuplicates.Remove(records.SingleOrDefault(r => r.Title.Equals(recordTitle)));

                            //remove colour from row
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;

                            //restore button's original text
                            button.Value = "Duplicate";

                            //update grid view?
                            //update statiistics
                            UpdateStatistics();
                        }
                        else
                        {
                            markedDuplicates.Add(records.ElementAt(e.RowIndex));
                            //if (!btnUndo.Enabled)
                            //    btnUndo.Enabled = true;
                            //dataGridView1[e.ColumnIndex, e.RowIndex].Value = "Unmark";
                            ((DataGridViewButtonCell)dataGridView1[e.ColumnIndex, e.RowIndex]).Value = "Unmark";
                            //records.RemoveAt(e.RowIndex);
                            UpdateGridView();
                            UpdateStatistics();
                        }
                        
                    }
                    break;
                //Mark as discarded - title & abstract
                case 1:
                    {
                        if (button.Value.ToString().Equals("Unmark"))
                        {
                            //remove record from markedDuplicates list
                            string recordTitle = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
                            markedTitleAbst.Remove(records.SingleOrDefault(r => r.Title.Equals(recordTitle)));

                            //remove colour from row
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;

                            //restore button's original text
                            button.Value = "Title & Abs.";

                            //update grid view?
                            //update statiistics
                            UpdateStatistics();
                        }
                        else
                        {
                            markedTitleAbst.Add(records.ElementAt(e.RowIndex));
                            //if (!btnUndo.Enabled)
                            //    btnUndo.Enabled = true;
                            button.Value = "Unmark";
                            //records.RemoveAt(e.RowIndex);
                            UpdateGridView();
                            UpdateStatistics();
                        }

                    }
                    break;
                //Mark as discarded - full text
                case 2:
                    {
                        if (button.Value.ToString().Equals("Unmark"))
                        {

                        }
                        else
                        {
                            markedFullText.Add(records.ElementAt(e.RowIndex));
                            //if (!btnUndo.Enabled)
                            //    btnUndo.Enabled = true;
                            button.Value = "Full Text";
                            //records.RemoveAt(e.RowIndex);
                            UpdateGridView();
                            UpdateStatistics();
                        }
                    }
                    break;
            }
        }

        //private void btnUndo_Click(object sender, EventArgs e)
        //{
        //    if (markedDuplicates.Count > 0)
        //    {
        //        Record lastDuplicate = markedDuplicates.Last();
        //        records.Add(lastDuplicate);
        //        markedDuplicates.RemoveAt(markedDuplicates.IndexOf(markedDuplicates.Last()));
        //        if (markedDuplicates.Count <= 0)
        //            btnUndo.Enabled = false;
        //        UpdateGridView();
        //        UpdateStatistics();
        //    }
        //}

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.ColumnIndex > 0)
            {
                for(int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[1, i].Selected = true;
                }
            }
            ////Selection whole column except header
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            //DataGridViewColumn columnCells =  dataGridView1.Columns[e.ColumnIndex];
            //dataGridView1[1, 0].Selected = false;
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


        private void UpdateStatistics()
        {
            //Display statistics
            lblSearches.Text = searchUris.Count.ToString();
            lblDuplicates.Text = (duplicatesFound + markedDuplicates.Count).ToString();
            lblUniques.Text = (records.Count - markedDuplicates.Count).ToString();
            lblTitleAbs.Text = markedTitleAbst.Count.ToString();
            lblFullText.Text = markedFullText.Count.ToString();
            lblUnmarked.Text = 
                (records.Count - (markedDuplicates.Count + markedFullText.Count + markedTitleAbst.Count))
                    .ToString();       
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
