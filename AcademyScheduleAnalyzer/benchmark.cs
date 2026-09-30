using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyScheduleAnalyzer
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        public string[] Sessions = {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"};
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;

        [Benchmark]
        public string StringConcatenation()
        {
            var result = "";
            foreach (var session in Sessions)
            {
                string report = $"{session}\n";
                result += report;
            }
            return result;
        }
        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder result = new StringBuilder();
            foreach (var session in Sessions)
            {
                string report = $"{session}\n";
                result.Append(report);
            }
            return result.ToString();
        }
        [Benchmark]
        public void FirstIterationMethod()
        {       
            Console.WriteLine($"Benchmark : \n");
            for (int i = 0; i < Iterations; i++)
            {
                Console.WriteLine(i);
            }
        }
        [Benchmark]
        public void SecondIterationMethod()
        {
            Console.WriteLine($"Benchmark : \n");
            for (int i = 0; i < Iterations; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
