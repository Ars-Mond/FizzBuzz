using System;
using System.Diagnostics;

namespace FizzBuzz
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write count num: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Stopwatch alltime = new Stopwatch();
            Stopwatch runtime = new Stopwatch();
            Stopwatch outtime = new Stopwatch();


            alltime.Start();
            Console.WriteLine("Start generation!");
            Core core = new Core(count);
            
            runtime.Start();

            core.Generate();
            
            runtime.Stop();
            
            outtime.Start();
            
            Console.WriteLine(core.ToString());
            //core.ToStringSlow();
                
            outtime.Stop();
            alltime.Start();

            string alltimeStr = TimeFormat(alltime.Elapsed);
            string runtimeStr = TimeFormat(runtime.Elapsed);
            string outtimeStr = TimeFormat(outtime.Elapsed);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Runtime >> " + runtimeStr);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Outtime >> " + outtimeStr);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("______________________________");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Runtime >> " + alltimeStr);
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            long frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}", frequency);
            
            long nanosecPerTick = (1000L*1000L*1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds", nanosecPerTick);

            long nanoseconds = nanosecPerTick * runtime.ElapsedTicks;
            Console.WriteLine("  Runtime nanoseconds >> " + nanoseconds);
            Console.ReadLine();
        }

        static string TimeFormat(TimeSpan time)
        {
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000}::tck.{time.Ticks}";
        }
    }
}