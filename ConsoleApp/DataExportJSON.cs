using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DataExportJSON : DataExportText
    {
        public bool Indented { get; set; }
        public DataExportJSON(string data, string filePath, string encoding, bool indented) : base(data, filePath, encoding)
        {
            Indented = indented;
        }
        protected DataExportJSON(DataExportJSON otherDataExportJSON) : base(otherDataExportJSON)
        {
            Indented = otherDataExportJSON.Indented;
        }

        public override DataExport MyClone() => new DataExportJSON(this);
    }
}
