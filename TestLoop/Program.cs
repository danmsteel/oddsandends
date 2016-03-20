using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1,2";
            var watch = Stopwatch.StartNew();
            long ticks = 0;
            long diff = 0;
            long average = 0;
            long maxCount = 1000000;

            FileStream filestream = new FileStream("out.txt", FileMode.Append);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

            for(int count = 0; count <maxCount; count++)
            {
                AddLoop(input);

                watch.Stop();
                ticks = watch.ElapsedTicks;
                watch.Reset();
                watch.Start();

                Add(input);

                watch.Stop();

                diff = (watch.ElapsedTicks - ticks) / ticks * 100;

                average += diff;

                count++;
            }

            Console.Write("Average difference = {0}%\n", average / maxCount);

            Console.ReadKey();

        }

        public static int AddLoop(string input)
        {            
            string[] parts = input.Split(',');
            int answer = default(int);

            foreach(string part in parts)
            {
                answer = answer + Convert.ToInt32(part);
            }

            return answer;
        }

        public static int Add(string input)
        {
            string[] parts = input.Split(',');

            return Convert.ToInt32(parts[0]) + Convert.ToInt32(parts[1]); 

        }
    }
}
