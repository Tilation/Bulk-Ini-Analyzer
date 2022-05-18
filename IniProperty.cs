using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IniCompacter
{
    class IniProperty
    {
        public string Name { get; set; }
        public string Header { get; set; }

        public List<string> FileOcurrences { get; set; }

        /// <summary>
        /// Key is value, values are files
        /// </summary>
        public Dictionary<string, List<string>> Values { get; set; }
        public string DisplayMember => $"[{Header}] {Name} ({FileOcurrences.Count})";

        public IniProperty(string name, string header)
        {
            Name = name;
            FileOcurrences = new List<string>();
            Values = new Dictionary<string, List<string>>();
            Regex r = new Regex("([0-9]+)");
            Header = header;
            if (r.IsMatch(header)) Header = r.Replace(header, "#");
        }
    }
}
