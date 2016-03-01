using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using ru.Company.Library;

namespace triangleTest
{
    class Program
    {

        static double CalcArea1(double a, double b, double c)
        {
            return (a > c ? c : a) * (b > c ? c : b) * 0.5;
        }

        static double CalcAreaGeron(double a, double b, double c)
        {
            var p = (a + b + c) * 0.5; // полупериметр
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        static long SpeedTest1(List<double> testData)
        {
            var len = testData.Count;
            var timer = Stopwatch.StartNew();

            for (int i = 0; i < len; i += 3)
            {
                CalcArea1(testData[i], testData[i + 1], testData[i + 2]);
            }

            timer.Stop();
            return timer.ElapsedTicks;
        }

        static long SpeedTestGeron(List<double> testData)
        {
            var len = testData.Count;
            var timer = Stopwatch.StartNew();

            for (int i = 0; i < len; i += 3)
            {
                CalcAreaGeron(testData[i], testData[i + 1], testData[i + 2]);
            }
            timer.Stop();
            return timer.ElapsedTicks;
        }

        /// <summary>
        /// Тест скорости обработки методов вычисления площади.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var testData = new List<double>(3000000);

            // сформировать тестовый набор данных
            Random rnd = new Random(10000);
            for (int i = 0; i < testData.Capacity; i += 3)
            {
                var v1 = rnd.NextDouble() * 100000;
                var v2 = rnd.NextDouble() * 100000;
                var v3 = Math.Sqrt(v1 * v1 + v2 * v2);

                testData.Add(v1);
                testData.Add(v2);
                testData.Add(v3);
            }

            var testResult1 = new List<long>(1000);
            var testResult2 = new List<long>(1000);

            for (int i = 0; i < 1000; i++)
            {
                testResult1.Add(SpeedTest1(testData));
                testResult2.Add(SpeedTestGeron(testData));
            }

            Console.WriteLine("m"
                + ": " + testResult1.Average(a => Convert.ToDouble(a))
                + ", " + testResult2.Average(a => Convert.ToDouble(a))
            );

            Console.ReadKey();
        }
    }
}
