using JsonSrcGen;

namespace JsonBenchmark
{
    [Json]
    public class JsonTestClass
    {
        public string FirstName{get;set;}

        public string LastName{get;set;}

        public int Age{get;set;}

        public bool Registered {get;set;}
    }
}