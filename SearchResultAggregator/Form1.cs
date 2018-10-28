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
        private List<string> records;
        private List<string> searchUris;
        private List<string> markedDuplicates;
        private int totalRecordsHit, duplicatesFound;

        public Form1()
        {
            InitializeComponent();
            records = new List<string>();
            searchUris = new List<string>();
            markedDuplicates = new List<string>();
            totalRecordsHit = 0;
            duplicatesFound = 0;

            //Remove me - test
            records.Add("Study 1");
            records.Add("Study 2");
            records.Add("Study 3");
            records.Add("Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3Study 3");
            foreach (var record in records)
            {
                textBox2.AppendText(record);
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(Environment.NewLine);
            }


            UpdateGridView();
            UpdateStatistics();
            //dataGridView1.DataSource = records;
            //dataGridView1.Update();

        }

        private void UpdateGridView()
        {
            dataGridView1.Rows.Clear();
            records.Sort();
            foreach(var record in records)
            {
                dataGridView1.Rows.Add(new object[] { "", record });
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
            records = records.Distinct().ToList();

            //The ones which have been removed are duplicates
            duplicatesFound = totalRecordsHit - records.Count;

            lblTotalHits.Text = totalRecordsHit.ToString();
            UpdateStatistics();

            UpdateGridView();

            //Display list
            foreach (var record in records)
            {
                textBox2.AppendText(record);
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(Environment.NewLine);
            }                                
        }

        private List<string> GetData(string uri, ref string errorMessage)
        {
            Uri uriObj = new Uri(uri);
            WebScrapingTools wst = new WebScrapingTools();
            List<string> records = new List<string>();

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
            if(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn  && e.RowIndex >= 0)
            {
                markedDuplicates.Add(records.ElementAt(e.RowIndex));
                if (!btnUndo.Enabled)
                    btnUndo.Enabled = true;
                records.RemoveAt(e.RowIndex);
                UpdateGridView();
                UpdateStatistics();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (markedDuplicates.Count > 0)
            {
                string lastDuplicate = markedDuplicates.Last();
                records.Add(lastDuplicate);
                markedDuplicates.RemoveAt(markedDuplicates.IndexOf(markedDuplicates.Last()));
                if (markedDuplicates.Count <= 0)
                    btnUndo.Enabled = false;
                UpdateGridView();
                UpdateStatistics();
            }
        }

        private void UpdateStatistics()
        {
            //Display statistics
            lblSearches.Text = searchUris.Count.ToString();
            lblDuplicates.Text = (duplicatesFound + markedDuplicates.Count).ToString();
            lblUniques.Text = records.Count.ToString();
        }

    }
}
