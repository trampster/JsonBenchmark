using BenchmarkDotNet.Attributes;
using Jsonics;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    public class ToJsonComparision
    {
        JsonTestClass _jsonTestClass;
        IJsonConverter<JsonTestClass> _jsonConverter;

        public ToJsonComparision()
        {
            _jsonTestClass = new JsonTestClass()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 21
            };
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }

        [Benchmark]
        public string Jsonics() => _jsonConverter.ToJson(_jsonTestClass);

        [Benchmark]
        public string Newtonsoft() => JsonConvert.SerializeObject(_jsonTestClass);

        [Benchmark]
        public string NetJson() => NetJSON.NetJSON.Serialize(_jsonTestClass);

        [Benchmark]
        public string JIL() => Jil.JSON.Serialize(_jsonTestClass);
    }
}