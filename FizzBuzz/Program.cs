using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

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
            
            NewLine(1);
            ColourOut("Runtime >> " + runtimeStr, ConsoleColor.Cyan);
            ColourOut("Outtime >> " + outtimeStr, ConsoleColor.Yellow);
            ColourOut("______________________________", ConsoleColor.White);
            ColourOut("Runtime >> " + alltimeStr, ConsoleColor.Magenta);
            NewLine(1);
            
            Console.ForegroundColor = ConsoleColor.White;
            long frequency = Stopwatch.Frequency;
            Console.WriteLine("  Timer frequency in ticks per second = {0}", frequency);
            
            long nanosecondsPerTick = (1000L*1000L*1000L) / frequency;
            Console.WriteLine("  Timer is accurate within {0} nanoseconds", nanosecondsPerTick);

            NewLine(1);
            long nanoseconds = nanosecondsPerTick * runtime.ElapsedTicks;
            ColourOut("  Runtime nanoseconds >> ", ConsoleColor.White, nanoseconds.ToString(), ConsoleColor.Red);

            nanoseconds = nanosecondsPerTick * outtime.ElapsedTicks;
            ColourOut("  Outtime nanoseconds >> ", ConsoleColor.White, nanoseconds.ToString(), ConsoleColor.Red);
            
            NewLine(1);
            ColourOut("Press any key to continue...", ConsoleColor.Gray);
            Console.ReadKey();
        }

        static string TimeFormat(TimeSpan time)
        {
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000}::tck.{time.Ticks}";
        }

        static void ColourOut(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
        }
        
        static void ColourOut(string value, ConsoleColor color, string value2, ConsoleColor color2)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = color2;
            Console.WriteLine(value2);
        }

        static void NewLine(uint count)
        {
            for (int i = 0; i < count; i++) Console.WriteLine();
        }
    }
}