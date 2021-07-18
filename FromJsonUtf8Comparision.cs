using System.Text;
using BenchmarkDotNet.Attributes;
using Jsonics;
using JsonSrcGen;

namespace JsonBenchmark
{
    public class FromJsonUtf8Comparision
    {
        byte[] _json;
        IJsonConverter<JsonTestClass> _jsonConverter;

        public FromJsonUtf8Comparision()
        {
            _json = Encoding.UTF8.GetBytes("{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Age\":12, \"Registered\":true}");
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }

        [Benchmark]
        public JsonTestClass NewtonsoftJson()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JsonTestClass>(Encoding.UTF8.GetString(_json));
        }

        [Benchmark]
        public JsonTestClass NetJson() => NetJSON.NetJSON.Deserialize<JsonTestClass>(Encoding.UTF8.GetString(_json));

        [Benchmark]
        public JsonTestClass JIL() => Jil.JSON.Deserialize<JsonTestClass>(Encoding.UTF8.GetString(_json));

        [Benchmark]
        public JsonTestClass UTF8JSon()
        {
            return Utf8Json.JsonSerializer.Deserialize<JsonTestClass>(_json);
        }

        [Benchmark]
        public JsonTestClass SpanJSON()
        {
            return SpanJson.JsonSerializer.Generic.Utf8.Deserialize<JsonTestClass>(_json);
        }

        [Benchmark]
        public JsonTestClass SystemTextJson()
        {
            return System.Text.Json.JsonSerializer.Deserialize<JsonTestClass>(_json);
        }

        JsonTestClass _jsonTextClass = new JsonTestClass();
        JsonConverter _jsonSrcGenConverter = new JsonConverter();

        [Benchmark]
        public JsonTestClass JsonSrcGen()
        {
            _jsonSrcGenConverter.FromJson(_jsonTextClass, _json);
            return _jsonTextClass;
        }
    }
}