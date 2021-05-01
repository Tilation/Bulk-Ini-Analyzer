using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace IniCompacter
{
    public partial class Form1 : Form
    {
        List<string> files = new List<string>();

        Dictionary<string, INIProperty> matches = new Dictionary<string, INIProperty>();

        Dictionary<string, INIProperty> filteredmatches = new Dictionary<string, INIProperty>();
        List<string> filteredFoundIn = new List<string>();

        List<Dictionary<string, List<string>>> values = new List<Dictionary<string, List<string>>>();
        List<string> filteredValues = new List<string>();

        private bool updatingValues;

        enum Stype
        {
            Result,
            Value
        }
        Stype LastClicked;

        public Form1()
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

        private void buttonGather_Click(object sender, EventArgs e)
        {
            var root = textBoxRoot.Text;
            if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root)) return;

            matches.Clear();
            files.Clear();

            string filter = string.IsNullOrWhiteSpace(textBoxEXT.Text) ? "*.ini" : $"*.{textBoxEXT.Text}";

            files = Directory.GetFiles(root, filter).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var lines = File.ReadLines(file);
                string header = "";
                foreach(string line in lines)
                {
                    if (line.Contains("["))
                    {
                        header = line.Trim().ToUpper();
                        //MessageBox.Show(header);
                    }
                    if (!line.Contains("=")) continue;

                    string property = line.Split('=')[0].Trim().ToUpper();

                    Regex r = new Regex("([0-9]*)");
                    property = $"{r.Replace(header, "")} {property}";
                    if (!matches.ContainsKey(property))
                    {
                        matches.Add(property, new INIProperty(property, header));
                    }
                    matches[property].FileOcurrences.Add(file);
                    
                    string value = line.Split('=')[1].Trim().ToUpper();
                    if (!matches[property].Values.ContainsKey(value))
                    {
                        matches[property].Values.Add(value, new List<string>());
                    }
                    matches[property].Values[value].Add(file);
                }
            }

            DisplayResults();
        }

        private void DisplayResults()
        {
            filteredmatches = matches;
            if (!string.IsNullOrWhiteSpace(textBoxResultsSearch.Text))
            {
                filteredmatches = matches.Where(x => x.Value.DisplayMember.Contains(textBoxResultsSearch.Text.ToUpper())).ToDictionary(X => X.Key, x => x.Value);
            }
            listBoxResults.DataSource = filteredmatches.Values.OrderBy(x=>x.DisplayMember).ToList();
            listBoxResults.DisplayMember = "DisplayMember";
        }

        void DisplayValues()
        {
            updatingValues = true;
            if (listBoxResults.SelectedItem is INIProperty iniprop)
            {
                var filtered = iniprop.Values.Keys.OrderBy(x => x).ToList();
                var filter = textBoxVaues.Text.ToUpper();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filtered = filtered.Where(x => x.Contains(filter)).OrderBy(x=>x).ToList();
                }
                listBoxValues.BeginUpdate();
                listBoxValues.DataSource = null;
                listBoxValues.DataSource = filtered;
                listBoxValues.EndUpdate();
            }
            updatingValues = false;

        }

        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBoxFoundIn.BeginUpdate();
            listBoxFoundIn.DataSource = null;
            if (listBoxResults.SelectedItem is INIProperty iniprop)
            {
                LastClicked = Stype.Result;
                DisplayFoundInResults();
                DisplayValues();
            }
            listBoxFoundIn.EndUpdate();
        }

        class INIProperty
        {
            public string Name { get; set; }
            public string Header { get; set; }
            
            public List<string> FileOcurrences { get; set; }
            public Dictionary<string, List<string>> Values { get; set; }
            public string DisplayMember => $"{Name} ({FileOcurrences.Count})";
            
            public INIProperty(string name, string header)
            {
                this.Name = name;
                FileOcurrences = new List<string>();
                Values = new Dictionary<string, List<string>>();
                Regex r = new Regex("([0-9]*)");
                this.Header = r.Replace(header, "");
                //MessageBox.Show($"prev: {header} post: {Header}");
            }

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
            if (listBoxResults.SelectedItem is INIProperty iniprop)
            {
                if (LastClicked == Stype.Result)
                {
                    groupBoxFoundIn.Text = "Header/Property Found In:";
                    filteredFoundIn = iniprop.FileOcurrences;
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
                        filteredFoundIn = iniprop.Values[value];
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
    }
}
