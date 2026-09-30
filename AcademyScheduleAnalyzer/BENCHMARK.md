
// * Summary *

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9550/25H2/2025Update/HudsonValley2)
AMD Ryzen 7 9700X 3.80GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]     : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4


| Method                     | Iterations | Mean                | Error             | StdDev            | Gen0   | Allocated |
|--------------------------- |----------- |--------------------:|------------------:|------------------:|-------:|----------:|
| StringConcatenation        | 100        |            36.76 ns |          0.644 ns |          0.602 ns | 0.0382 |     640 B |
| StringBuilderConcatenation | 100        |            53.10 ns |          0.903 ns |          0.800 ns | 0.0445 |     744 B |
| FirstIterationMethod       | 100        |     5,280,951.51 ns |    103,293.730 ns |     96,621.019 ns |      - |         - |
| SecondIterationMethod      | 100        |     5,264,791.22 ns |    104,803.689 ns |    139,909.927 ns |      - |         - |
| StringConcatenation        | 1000       |            35.45 ns |          0.681 ns |          0.637 ns | 0.0382 |     640 B |
| StringBuilderConcatenation | 1000       |            51.84 ns |          0.640 ns |          0.599 ns | 0.0445 |     744 B |
| FirstIterationMethod       | 1000       |    51,665,967.41 ns |    832,206.045 ns |    737,728.983 ns |      - |   22400 B |
| SecondIterationMethod      | 1000       |    51,661,129.38 ns |    601,580.775 ns |    562,719.030 ns |      - |   22400 B |
| StringConcatenation        | 10000      |            35.46 ns |          0.719 ns |          0.706 ns | 0.0382 |     640 B |
| StringBuilderConcatenation | 10000      |            51.65 ns |          0.566 ns |          0.502 ns | 0.0445 |     744 B |
| FirstIterationMethod       | 10000      |   522,655,995.45 ns | 10,243,499.437 ns | 12,579,938.334 ns |      - |  310400 B |
| SecondIterationMethod      | 10000      |   517,586,760.00 ns | 10,048,363.577 ns |  9,399,245.529 ns |      - |  310400 B |
| StringConcatenation        | 100000     |            36.34 ns |          0.752 ns |          1.787 ns | 0.0382 |     640 B |
| StringBuilderConcatenation | 100000     |            52.85 ns |          1.074 ns |          1.278 ns | 0.0445 |     744 B |
| FirstIterationMethod       | 100000     | 5,205,238,575.00 ns | 32,538,108.163 ns | 25,403,614.594 ns |      - | 3190400 B |
| SecondIterationMethod      | 100000     | 5,217,049,600.00 ns | 32,744,569.870 ns | 30,629,290.987 ns |      - | 3190400 B |

Answers to Questions
1 Which approach was faster with 100 iterations?
Surprisingly StringConcatenation was faster It took about 3676 ns while StringBuilder took around 5310 ns

2 Which approach was faster with 100000 iterations?
It was still StringConcatenation (3634 ns vs 5285 ns) The results didnt really change even when BenchmarkDotNet increased its invocation count

3 Which approach allocated more memory?
StringBuilder allocated more memory per operation (744 B) compared to normal string concatenation (640 B)

4 What happened to string concatenation performance as the loop size increased?
Honestly nothing changed The execution time stayed completely flat around 35-36 ns whether it was 100 or 100000 iterations

5 Why does repeated string concatenation create additional allocations?
Because strings in C are immutable When you use += C doesnt just modify the existing string in memory It creates a brand new string object copies the old text over adds the new text and leaves the old string for the Garbage Collector to clean up later Doing this repeatedly creates a lot of garbage in memory

6 Why does StringBuilder usually perform better when text is repeatedly appended?
StringBuilder is basically a wrapper around a mutable character array Instead of creating a new string object every time you append it just adds the new characters to its internal buffer It only allocates a new larger buffer if it runs out of space and it only creates the final string object when you call ToString() This avoids creating tons of temporary string objects

7 Is StringBuilder always better than normal string operations? Explain
No and my benchmark is actually a great example of why We are always taught to use StringBuilder in loops but thats only true for large loops or heavy text manipulation
In my specific code Im only looping 5 times to add a few short words Instantiating a new StringBuilder() has its own overhead (allocating the initial buffer setting up the object etc) For just 5 items doing normal += is actually faster and lighter If I changed my code to append strings 10000 times inside the method Im sure StringBuilder would easily win But for small tasks normal strings are perfectly fine 