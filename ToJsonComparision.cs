using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using Jsonics;
using Newtonsoft.Json;
using Utf8Json;
using SpanJsonNamespace = SpanJson;

namespace JsonBenchmark
{
    public class ToJsonComparision
    {
        JsonTestClass _jsonTestClass;
        IJsonConverter<JsonTestClass> _jsonConverter;

        JsonSrcGen.JsonConverter _jsonSrcGenConverter = new JsonSrcGen.JsonConverter();

        

        public ToJsonComparision()
        {
            _jsonTestClass = new JsonTestClass()
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 12,
                Registered = true
            };
            _jsonConverter = JsonFactory.Compile<JsonTestClass>();
        }

        [Benchmark]
        public ReadOnlySpan<char> JsonSrcGen() => _jsonSrcGenConverter.ToJson(_jsonTestClass);

        [Benchmark]
        public string Jsonics() => _jsonConverter.ToJson(_jsonTestClass);

        [Benchmark]
        public string UTF8Json()
        {
            var jsonBytes = Utf8Json.JsonSerializer.Serialize(_jsonTestClass);
            return Encoding.UTF8.GetString(jsonBytes);
        }

        [Benchmark]
        public string Newtonsoft() => JsonConvert.SerializeObject(_jsonTestClass);

        [Benchmark]
        public string NetJson() => NetJSON.NetJSON.Serialize(_jsonTestClass);

        [Benchmark]
        public string JIL() => Jil.JSON.Serialize(_jsonTestClass);

        [Benchmark]
        public string SpanJson() => SpanJsonNamespace.JsonSerializer.Generic.Utf16.Serialize(_jsonTestClass);

        public string SystemTextJson()
        {
            return System.Text.Json.JsonSerializer.Serialize<JsonTestClass>(_jsonTestClass);
        }
    }
}