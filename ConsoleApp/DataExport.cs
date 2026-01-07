using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class DataExport: ICloneable, IMyCloneable<DataExport>
    {
        public string Data {  get; set; }
        public string FilePath { get; set; }

        public DataExport(string data, string filePath)
        {
            Data = data;
            FilePath = filePath;
        }

        protected DataExport(DataExport otherDataExport)
        {
            Data = otherDataExport.Data;
            FilePath = otherDataExport.FilePath;
        }

        public abstract DataExport MyClone();
        object ICloneable.Clone() => MyClone();
    }
}
