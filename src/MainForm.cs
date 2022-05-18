using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IniCompacter
{
    public partial class MainForm : Form
    {
        readonly Regex r = new Regex("([0-9]+)");

        /// <summary>
        /// Key is the file, value is the content of the ini as <see cref="IniResult"/>
        /// </summary>
        Dictionary<string, IniResult> filesAndContents = new Dictionary<string, IniResult>();

        /// <summary>
        /// All found properties, across all files.
        /// </summary>
        List<IniProperty> allProperties = new List<IniProperty>();
        
        /// <summary>
        /// Search-matching properties, across all files.
        /// </summary>
        List<IniProperty> filteredmatches = new List<IniProperty>();

        List<string> files = new List<string>();

        List<string> filteredFoundIn = new List<string>();

        List<Dictionary<string, List<string>>> values = new List<Dictionary<string, List<string>>>();
        List<string> filteredValues = new List<string>();

        private IniProperty SelectedProperty => dataGridView1.SelectedRows.Count == 0 ? null :  dataGridView1.SelectedRows[0].DataBoundItem as IniProperty;

        private bool updatingValues;

        enum Stype
        {
            Result,
            Value
        }

        Stype LastClicked;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonChangeRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Environment.CurrentDirectory;
            var dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBoxRoot.Text = fbd.SelectedPath;
            }
        }

        private async void buttonGather_Click(object sender, EventArgs e)
        {
            var root = textBoxRoot.Text;
            if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root)) return;

            filesAndContents.Clear();

            string filter = string.IsNullOrWhiteSpace(textBoxEXT.Text) ? "*.ini" : $"*.{textBoxEXT.Text}";

            files = Directory.GetFiles(root, filter).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var result = await IniReader.Read(file);
                filesAndContents.Add(file, result);
            }

            foreach (var kv in filesAndContents)
            {
                var ini = kv.Value;
                var file = kv.Key;

                var headers = ini.GetHeaders();
                foreach(var h in headers.Select(x=>x.ToLower()))
                {
                    var header = h;
                    if (r.IsMatch(header)) 
                        header = r.Replace(header, "#");

                    var properties = ini.GetPropertyNames(h);
                    foreach (var p in properties.Select(x=>x.ToLower()))
                    {
                        var property = p;
                        if (r.IsMatch(property))
                            property = r.Replace(property, "#");

                        var prop = allProperties.FirstOrDefault(x => x.Header == header && x.PropertyName == property);
                        if (prop == null)
                        {
                            prop = new IniProperty(property, header);
                            allProperties.Add(prop);
                        }
                        prop.FileOcurrences.Add(file);
                        var value = ini.AsString(h, p);
                        if (!prop.Values.ContainsKey(value)) prop.Values.Add(value, new List<string>());
                        prop.Values[value].Add(file);
                    }
                }
            }


            DisplayResults();
        }

        private void DisplayResults()
        {
            filteredmatches = allProperties;
            if (!string.IsNullOrWhiteSpace(textBoxResultsSearch.Text))
            {
                filteredmatches = allProperties.Where(x => x.DisplayMember.Contains(textBoxResultsSearch.Text.ToUpper())).ToList();
            }
            dataGridView1.DataSource = filteredmatches.OrderBy(x => x.DisplayMember).ToList();
            dataGridView1.Columns["DisplayMember"].Visible = false;
            dataGridView1.Columns["Values"].Visible = false;
            dataGridView1.Columns["Header"].DisplayIndex = 0;
            dataGridView1.Columns["PropertyName"].HeaderText = "Property Name";

            dataGridView1.Columns["Header"].Width = dataGridView1.Columns["Header"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);
            dataGridView1.Columns["PropertyName"].Width = dataGridView1.Columns["PropertyName"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, false);

            //listBoxResults.DataSource = filteredmatches.OrderBy(x => x.DisplayMember).ToList();
            //listBoxResults.DisplayMember = "DisplayMember";
        }

        void DisplayValues()
        {
            updatingValues = true;
            if (SelectedProperty != null)
            {
                var filtered = SelectedProperty.Values.Keys.OrderBy(x => x).ToList();
                var filter = textBoxVaues.Text.ToUpper();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filtered = filtered.Where(x => x.Contains(filter)).OrderBy(x => x).ToList();
                }
                listBoxValues.BeginUpdate();
                listBoxValues.DataSource = null;
                listBoxValues.DataSource = filtered;
                listBoxValues.EndUpdate();
            }
            updatingValues = false;
        }

        public bool ExploreFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return false;
            }
            //Clean up file path so it can be navigated OK
            filePath = System.IO.Path.GetFullPath(filePath);
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
            return true;
        }
        private void textBoxResultsSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void textBoxFoundInSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayFoundInResults();
        }

        private void DisplayFoundInResults()
        {
            if (SelectedProperty != null)
            {
                if (LastClicked == Stype.Result)
                {
                    groupBoxFoundIn.Text = "Header/Property Found In:";
                    filteredFoundIn = SelectedProperty.FileOcurrences;
                    if (!string.IsNullOrWhiteSpace(textBoxFoundInSearch.Text))
                    {
                        filteredFoundIn = filteredFoundIn.Where(x => x.Contains(textBoxFoundInSearch.Text.ToUpper())).ToList();
                    }
                    listBoxFoundIn.DataSource = filteredFoundIn.OrderBy(x => x).ToList();

                }
                else if (LastClicked == Stype.Value)
                {
                    groupBoxFoundIn.Text = "Value Found In:";

                    string value = listBoxValues.SelectedItem as string;
                    if (value != null)
                    {
                        filteredFoundIn = SelectedProperty.Values[value];
                        if (!string.IsNullOrWhiteSpace(textBoxFoundInSearch.Text))
                        {
                            filteredFoundIn = filteredFoundIn.Where(x => x.Contains(textBoxFoundInSearch.Text.ToUpper())).ToList();
                        }
                        listBoxFoundIn.DataSource = filteredFoundIn.OrderBy(x => x).ToList();
                    }
                }
            }
        }

        private void listBoxFoundIn_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFoundIn.SelectedIndex < 0) return;
            if (!File.Exists((string)listBoxFoundIn.SelectedItem)) return;
            ExploreFile((string)listBoxFoundIn.SelectedItem);
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingValues)
            {
                LastClicked = Stype.Value;
                DisplayFoundInResults();
            }
        }

        private void textBoxVaues_TextChanged(object sender, EventArgs e)
        {
            DisplayValues();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            listBoxFoundIn.BeginUpdate();
            listBoxFoundIn.DataSource = null;
            if (SelectedProperty != null)
            {
                LastClicked = Stype.Result;
                DisplayFoundInResults();
                DisplayValues();
            }
            listBoxFoundIn.EndUpdate();
        }
    }
}
