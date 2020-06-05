using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Runtime.Interop;

namespace CompareObjectNullOrOperatorIs
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Testing>();
        }
    }
    
    public class Testing
    {
        private Person person = new Person();

        [Benchmark]
        public void OperatorIs()
        {
            if (person is Person)
            {
                person.Name = "Pablo";
                person.Surname = "Thomaz";
                person.Age = 30;
                person.MotherName = "Marcia Thomaz";
            }
        }

        [Benchmark]
        public void CheckNull()
        {
            if (person != null)
            {
                person.Name = "Pablo";
                person.Surname = "Thomaz";
                person.Age = 30;
                person.MotherName = "Marcia Thomaz";
            }
        }
    }
}
