using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp82
{
    public class Set : IEnumerable<long>
    {
        private List<long> _nums = new List<long>();

        public int Count => _nums.Count;
        public void Add(long num)
        {
            if (num == null)
            {
                throw new ArgumentNullException(nameof(num));
            }

            if (!_nums.Contains(num))
            {
                _nums.Add(num);
            }

        }
        public void Present(long num)
        {
            if (_nums.Contains(num))
            { 
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
        
        public IEnumerator<long> GetEnumerator()
        {
            return _nums.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nums.GetEnumerator();
        }

       
    }

    public class Program
    {
        
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Set set = new Set();
           
            for (int i = 0; i < N; i++)
            {
                long number = 0;
                try
                {
                    string[] str = Array.ConvertAll(Console.ReadLine().Split(), element => element.ToString());
                    if (str.Length==2)
                    {
                        number = Convert.ToInt32(str[1]);
                    }

                    if (str[0] == "ADD")
                    {
                        set.Add(number);
                    }
                    else if (str[0] == "PRESENT")
                    {
                        set.Present(number);
                    }
                    else if (str[0] == "COUNT")
                    {
                        Console.WriteLine(set.Count);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

       

        }
    }
}
