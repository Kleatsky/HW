using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DataExportBinary:DataExport
    {
        public int BufferSize { get; set; }
        public DataExportBinary(string data, string filePath, int bufferSize) : base(data, filePath)
        {
            BufferSize = bufferSize;
        }

        protected DataExportBinary(DataExportBinary otherDataExportBinary) : base(otherDataExportBinary)
        {
            BufferSize = otherDataExportBinary.BufferSize;
        }

        public override DataExport MyClone() => new DataExportBinary(this);
    }
}
