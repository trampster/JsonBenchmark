using BenchmarkDotNet.Attributes;
using Jsonics;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    public class FromJsonComparision
    {
        string _json;
        IJsonConverter<JsonTestClass> _jsonConverter;

        public FromJsonComparision()
        {
            _json = "{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Age\":21}";
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }

        [Benchmark]
        public JsonTestClass Jsonics() => _jsonConverter.FromJson(_json);

        [Benchmark]
        public JsonTestClass Newtonsoft() => JsonConvert.DeserializeObject<JsonTestClass>(_json);

        [Benchmark]
        public JsonTestClass NetJson() => NetJSON.NetJSON.Deserialize<JsonTestClass>(_json);

        [Benchmark]
        public JsonTestClass JIL() => Jil.JSON.Deserialize<JsonTestClass>(_json);
    }
}