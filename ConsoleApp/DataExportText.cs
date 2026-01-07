using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DataExportText : DataExport
    {
        public string Encoding { get; set; }
        public DataExportText(string data, string filePath, string encoding) : base(data, filePath)
        {
            Encoding = encoding;
        }

        protected DataExportText(DataExportText otherDataExportText) : base(otherDataExportText)
        {
            Encoding = otherDataExportText.Encoding;
        }

        public override DataExport MyClone() => new DataExportText(this);
    }
}
