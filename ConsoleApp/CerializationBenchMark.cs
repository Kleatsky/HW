using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    [MemoryDiagnoser]
    public class CerializationBenchMark
    {
        private F _testObj;
        private string _testObjCSVString;
        private string _testObjJSONString;
        private string _testObjNewtonJSONString;

        [GlobalSetup]
        public void Setup()
        {
            _testObj = F.Get();
            _testObjCSVString = CSVHandler.SerializetoCSV(_testObj);
            _testObjJSONString = System.Text.Json.JsonSerializer.Serialize(_testObj);
            _testObjNewtonJSONString = Newtonsoft.Json.JsonConvert.SerializeObject(_testObj);
        }

        [Benchmark(Description = "CSVHandler Serialize")]
        public string MySerialize() => CSVHandler.SerializetoCSV(_testObj);

        [Benchmark(Description = "System.Text.Json Serialize")]
        public string JsonSerialize() => System.Text.Json.JsonSerializer.Serialize(_testObj);

        [Benchmark(Description = "Newtonsoft Serialize")]
        public string SystemJsonSerialize() => Newtonsoft.Json.JsonConvert.SerializeObject(_testObj);

        [Benchmark(Description = "CSVHandler Deserialize")]
        public F MyDeserialize() => CSVHandler.DeserializeFromCSV<F>(_testObjCSVString);

        [Benchmark(Description = "System.Text.Json Deserialize")]
        public F JsonDeserialize() => System.Text.Json.JsonSerializer.Deserialize<F>(_testObjJSONString);

        [Benchmark(Description = "Newtonsoft Deserialize")]
        public F NewtonsoftDeser() => JsonConvert.DeserializeObject<F>(_testObjNewtonJSONString);
    }
}
