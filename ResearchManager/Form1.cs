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
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace ResearchManager
{
    public partial class Form1 : Form
    {
        private List<string> searchUris;
        private List<Record> records;        

        private int totalRecordsHit, duplicatesFound;

        private string workSpaceFileLocation;

        public Form1()
        {
            InitializeComponent();
            records = new List<Record>();
            searchUris = new List<string>();
            totalRecordsHit = 0;
            duplicatesFound = 0;
            lblCopied.Text = "";
            lblError.Text = "";
            dtTo.Value = DateTime.Now;
            workSpaceFileLocation = null;

            //Test - remove me
            //for (int i = 0; i < 200; i++)
            //{
            //records.Add(new Record("Study 1", "www.google.com"));
            //    records.Add(new Record("Study 2", "www.google.com"));
            //    records.Add(new Record("Study 3", "www.google.com"));
            //    records.Add(new Record("Study 3", "www.google.com"));
            //}

            UpdateGridView();
            UpdateStatistics();
            //End test
        }

        #region Component Methods
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
            
            UpdateStatistics();
            UpdateGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //If we have clicked a link
            if (dgv.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
            {
                Record record = records.ElementAt(e.RowIndex);
                if (record.Link != null)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(record.Link);
                    Process.Start(psi);
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[1, i].Selected = true;
                }
            }
        }

        private void btnCopyUnmarked_Click(object sender, EventArgs e)
        {
            var recordsList = records.Where(r => r.Status == Status.Unmarked).ToList();
            if (recordsList.Count > 0)
            {
                string recordsString = RecordListToString(recordsList);
                Clipboard.SetText(recordsString);
                lblCopied.Text = "Unmarked records copied to clipboard.";
            }
            else
                lblCopied.Text = "There is nothing to copy.";

        }

        private void btnCopyTitleAbs_Click(object sender, EventArgs e)
        {
            var recordsList = records.Where(r => r.Status == Status.DiscardedTitleAbs).ToList();
            if (recordsList.Count > 0)
            {
                string recordsString = RecordListToString(recordsList);
                Clipboard.SetText(recordsString);
                lblCopied.Text = "Discarded (Title & Abstract) records \ncopied to clipboard.";
            }
            else
                lblCopied.Text = "There is nothing to copy.";
        }

        private void btnCopyFullText_Click(object sender, EventArgs e)
        {
            var recordsList = records.Where(r => r.Status == Status.DiscardedFullText).ToList();
            if (recordsList.Count > 0)
            {
                string recordsString = RecordListToString(recordsList);
                Clipboard.SetText(recordsString);
                lblCopied.Text = "Discarded (Full Text) records copied \nto clipboard.";
            }
            else
                lblCopied.Text = "There is nothing to copy.";
        }

        private void btnMarkDuplicate_Click(object sender, EventArgs e)
        {
            btnMarkDuplicate.Enabled = false;
            UpdateSelectedRecordsStatus(Status.Duplicate);
        }

        private void btnMarkDiscTitleAbs_Click(object sender, EventArgs e)
        {
            btnMarkDiscTitleAbs.Enabled = false;
            UpdateSelectedRecordsStatus(Status.DiscardedTitleAbs);
        }

        private void btnMarkDiscFullText_Click(object sender, EventArgs e)
        {
            btnMarkDiscFullText.Enabled = false;
            UpdateSelectedRecordsStatus(Status.DiscardedFullText);
        }

        private void btnUnmark_Click(object sender, EventArgs e)
        {
            btnUnmark.Enabled = false;
            UpdateSelectedRecordsStatus(Status.Unmarked);
        }

        private void chkUseDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtTo.Enabled = chkUseDateFilter.Checked;
            dtFrom.Enabled = chkUseDateFilter.Checked;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                btnMarkDiscFullText.Enabled = true;
                btnMarkDiscTitleAbs.Enabled = true;
                btnMarkDuplicate.Enabled = true;

                int selectedIndex = dataGridView1.CurrentRow.Index;
                if (records[selectedIndex].Status != Status.Unmarked)
                    btnUnmark.Enabled = true;
                else
                    btnUnmark.Enabled = false;

            }
        }

        private void loadTSMI_Click(object sender, EventArgs e)
        {
            WorkSpace ws = null;
            //Open Dialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Set workSpaceFileLocation
                workSpaceFileLocation = openFileDialog1.FileName;

                //Load workspace
                ws = LoadProgressFromFile(openFileDialog1.FileName); 
            }  
            
            if(ws != null)
            {
                totalRecordsHit = ws.TotalRecordsHit;
                duplicatesFound = ws.DuplicatesFound;
                records = ws.Records;

                UpdateStatistics();
                UpdateGridView();
            }
        }

        private void saveTSMI_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(workSpaceFileLocation))
            {
                //Overwrite progress to the last opened file
                SaveProgressToFile(workSpaceFileLocation);
            }else
            {
                saveAsTSMI_Click(sender, e);
            }      
        }

        private void saveAsTSMI_Click(object sender, EventArgs e)
        {
            //Open Dialog
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveProgressToFile(saveFileDialog1.FileName);
                workSpaceFileLocation = saveFileDialog1.FileName;
            }
        }
        #endregion

        #region Function Methods
        private void UpdateGridView()
        {
            dataGridView1.Rows.Clear();

            //Sorting records
            records = records.OrderBy(r => r.Title.ToLower()).ToList();

            for (int i = 0; i < records.Count; i++)
            {
                //Getting record to update
                Record record = records[i];

                //Creating the row
                var row = new DataGridViewRow();
                var titleCell = new DataGridViewLinkCell();
                titleCell.Value = record.Title;
                row.Cells.Add(titleCell);
                SetRowColour(ref row, record.Status);
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.ClearSelection();
        }

        private void UpdateGridViewRowAt(int index)
        {
            //Getting record to update
            Record record = records[index];

            //Creating the row
            var row = dataGridView1.Rows[index];
            SetRowColour(ref row, record.Status);
            
        }

        private void SetRowColour(ref DataGridViewRow row, Status recordStatus){
            switch (recordStatus)
            {
                case Status.DiscardedFullText:
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    break;
                case Status.DiscardedTitleAbs:
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    break;
                case Status.Duplicate:
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    break;
                case Status.Unmarked:
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    break;
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

                int firstDisplayedIndex = dataGridView1.FirstDisplayedCell.RowIndex;

                //UpdateGridView();
                UpdateGridViewRowAt(selectedIndex);
                UpdateStatistics();

                
                dataGridView1.CurrentCell = dataGridView1[0, selectedIndex];
                dataGridView1.ClearSelection();
                //dataGridView1.CurrentCell = dataGridView1.Rows[selectedIndex].Cells[0];

                dataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayedIndex;

            }
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
            lblTotalHits.Text = totalRecordsHit.ToString();
        }

        private string RecordListToString(List<Record> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var record in list)
            {
                sb.AppendLine(record.Title);
            }
            return sb.ToString();
        }

        private void SaveProgressToFile(string fileName)
        {
            WorkSpace ws = new WorkSpace();
            ws.DuplicatesFound = duplicatesFound;
            ws.TotalRecordsHit = totalRecordsHit;
            ws.Records = records;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(ws.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, ws);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }catch(Exception e)
            {
                lblError.Text = e.Message;
            }
            
        }

        private WorkSpace LoadProgressFromFile(string fileName)
        {
            WorkSpace ws = new WorkSpace();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(ws.GetType());
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        ws = (WorkSpace)serializer.Deserialize(reader);
                    }
                }
                return ws;
                
            }
            catch (Exception e)
            {
                lblError.Text = e.Message;
            }
            return null;
        }
        #endregion
    }

    [Serializable]
    public class WorkSpace
    {
        public List<Record> Records { get; set; }
        public int TotalRecordsHit { get; set; }
        public int DuplicatesFound { get; set; }

        public WorkSpace()
        {

        }
    }
}
