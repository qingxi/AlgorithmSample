using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Console_Async_await
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new HttpClient();
            //var task = await  client.GetStringAsync("http://www.sina.com");

            //Console.WriteLine($"task:{task.Length}");
            //var a = 1;
            //for (int i = 0; i < 1_0; i++)
            //{
            //    a += i;
            //    Console.Write(a);
            //}

            //var task2 = await client.GetStringAsync("http://baidu.com");
            //Console.WriteLine($"task2:{task2.Length}");
            //Console.WriteLine("Hello World!");
            //string[] aa = { "--name", "SOME_NAME", "--count", "132"};
            //var a = getDay("Sat",23);
            var a = evenSumK(new int[] { 10000},5);
            Console.WriteLine(a);
        }

        static int evenSumK(int[] A, int K)
        {
            if (A.Max() >= 10000)
            {
                return -1;
            }
            int maxSum = 0;
            List<int> Even = new List<int>();
            List<int> Odd = new List<int>();
            for (int idx = 0; idx < A.Length; idx++)
            {
                if (A[idx] % 2 == 1)
                {
                    Odd.Add(A[idx]);
                }
                else
                {
                    Even.Add(A[idx]);
                }
            }
            Odd.Sort();
            Even.Sort();

            int i = Even.Count - 1;
            int j = Odd.Count - 1;

            while (K > 0)
            {
                if (K % 2 == 1)
                {
                    if (i >= 0)
                    {
                        maxSum += Even[i];
                        i--;
                    }
                    else
                    {
                        return -1;
                    }
                    K--;
                }
                else if (i >= 1 && j >= 1)
                {
                    if (Even[i] + Even[i - 1]<= Odd[j] + Odd[j - 1])
                    {
                        maxSum += Odd[j] + Odd[j - 1];
                        j -= 2;
                    }
                    else
                    {
                        maxSum += Even[i] + Even[i - 1];
                        i -= 2;
                    }
                    K -= 2;
                }
                else if (i >= 1)
                {
                    maxSum += Even[i] + Even[i - 1];
                    i -= 2;
                    K -= 2;
                }
                else if (j >= 1)
                {
                    maxSum += Odd[j] + Odd[j - 1];
                    j -= 2;
                    K -= 2;
                }
            }
            return maxSum;
        }

        static public int solution(int[] A)
        {
            Array.Sort(A);
            int dis = int.MinValue;
            if (A.Length == 2) return (A[1] - A[0]) / 2;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i + 1] - A[i] > 1)
                {
                    dis = Math.Max(dis, A[i + 1] - A[i]);
                }
            }

            return dis / 2;
        }
        static string getDay(string s, int k)
        {

            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            var index = -1;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(s))
                {
                    index = i;
                    break;
                }
            }

            index = (index + k) % days.Length;

            return days[index];
        }
        private static int Validate(string[] args)
        {
            if (args == null || args.Length == 0) return -1;

            if (!(args.Any(l => string.CompareOrdinal(l.ToLower(), "--name") == 0) || args.Any(l => string.CompareOrdinal(l.ToLower(), "--count") == 0) || args.Any(l => string.CompareOrdinal(l.ToLower(), "--help") == 0)))
            {
                return -1;
            }
            else if (args.Any(l => string.CompareOrdinal(l.ToLower(), "--help") == 0))
            {
                if (args.Length != 1 && !(args.Any(l => string.CompareOrdinal(l.ToLower(), "--name") == 0) || args.Any(l => string.CompareOrdinal(l.ToLower(), "--count") == 0)))
                {
                    return -1;
                }
                return 1;
            }

            int argsLength = args.Length;
            int index = 0;
            int validatedName = -1;
            int validatedValue = -1;
            foreach (var arg in args)
            {
                var argValue = string.Empty;
                if (index + 1 < argsLength)
                {
                    argValue = args[index + 1];
                }

                if (string.CompareOrdinal(arg.ToLower(), "--name") == 0)
                {
                    validatedName += 1;
                    if (!string.IsNullOrEmpty(argValue) && argValue.Length > 3 && argValue.Length < 10)
                    {
                        validatedName += 1;
                    }
                    else
                    {
                        validatedName = -1;
                    }
                }
                else if (string.CompareOrdinal(arg.ToLower(), "--count") == 0)
                {
                    validatedValue += 1;
                    if (int.TryParse(argValue, out int parsedCountValue) && parsedCountValue >= 10 && parsedCountValue <= 100)
                    {
                        validatedValue += 1;
                    }
                    else
                    {
                        validatedValue = -1;
                    }
                }
                index += 1;
            }

            if (validatedName == -1)
            {
                return validatedValue == 0 ? 1 : validatedValue == -1 ? -1 : 0;
            }
            else if (validatedValue == -1)
            {
                return validatedName == 0 ? 1 : validatedName == -1 ? -1 : 0;
            }
            else
            {
                return validatedName + validatedValue == 0 ? 1 : 0;
            }

        }
    }
}
