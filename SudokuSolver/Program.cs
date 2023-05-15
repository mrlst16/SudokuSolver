// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");

List<int> generatedInts = new List<int>();

Stopwatch stopwatch = Stopwatch.StartNew();
stopwatch.Start();

while (true && stopwatch.Elapsed < TimeSpan.FromSeconds(3))
{
    Random random = new Random(Guid.NewGuid().GetHashCode());
    int i = random.Next(1, 10);
    generatedInts.Add(i);
}

stopwatch.Stop();

Console.WriteLine($"Count: {generatedInts.Count}");
Console.WriteLine($"{generatedInts.Contains(1)}");
Console.WriteLine($"{generatedInts.Contains(2)}");
Console.WriteLine($"{generatedInts.Contains(3)}");
Console.WriteLine($"{generatedInts.Contains(4)}");
Console.WriteLine($"{generatedInts.Contains(5)}");
Console.WriteLine($"{generatedInts.Contains(6)}");
Console.WriteLine($"{generatedInts.Contains(7)}");
Console.WriteLine($"{generatedInts.Contains(8)}");
Console.WriteLine($"{generatedInts.Contains(9)}");
Console.WriteLine($"{!generatedInts.Any(x=> x < 0 || x > 9)}");