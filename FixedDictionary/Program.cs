using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试用例
            //1.增删改查是否正确
            Console.WriteLine("===========================测试用例1===============================");
            FixedDictionary<string, string> fixedDict = new FixedDictionary<string, string>();
            for (int i = 0; i < 10000; i++)
            {
                fixedDict.Add(i.ToString(), i.ToString());
            }
            Console.WriteLine($"Count is {fixedDict.Count}");
            for (int i = 100; i < 2000; i++)
            {
                fixedDict.Remove(i.ToString());
            }
            Console.WriteLine($"Count is {fixedDict.Count}");
            for (int i = 0; i < 10000; i++)
            {
                bool isContains = fixedDict.ContainsKey(i.ToString());
            }

            //for (int i = 0; i < 30; i++)
            //{
            //    fixedDict.Add(i.ToString(), i.ToString());
            //}
            //Console.WriteLine($"Count is {fixedDict.Count}");
            //for (int i = 0; i < 2; i++)
            //{
            //    fixedDict.Remove(i.ToString());
            //}
            //Console.WriteLine($"Count is {fixedDict.Count}");
            //for (int i = 0; i < 10; i++)
            //{
            //    bool isContains = fixedDict.ContainsKey(i.ToString());
            //    if(isContains)
            //        Console.WriteLine($"{i.ToString()} is contians.");
            //    else
            //        Console.WriteLine($"{i.ToString()} not contians.");
            //}

            //2.调用contains的查询效率
            Console.WriteLine("===========================测试用例2===============================");
            Random rand = new Random();
            FixedDictionary<uint, short> tree = new FixedDictionary<uint, short>(100000);
            Dictionary<uint, short> dic = new Dictionary<uint, short>(100000);
            List<uint> testCases = new List<uint>();

            for (int i = 0; i < 100000; i++)
            {
                uint k = (uint)rand.Next(0, 100000);
                testCases.Add(k);

            }

            foreach (uint testCase in testCases)
            {
                if (!dic.ContainsKey(testCase))
                    dic.Add(testCase, 0);
                if (!tree.ContainsKey(testCase))
                    tree.Add(testCase, 0);
            }


            DateTime start0 = DateTime.Now;
            for (int i = testCases.Count - 1; i >= 0; i--)
            {
                dic.ContainsKey(testCases[i]);
            }
            for (int i = testCases.Count - 1; i >= testCases.Count - 10; i--)
            {
                dic.ContainsKey(testCases[i]);
            }
            //dic.ContainsKey(testCases[1]);
            DateTime end0 = DateTime.Now;
            TimeSpan timeSpan0 = end0 - start0;
            Console.WriteLine($"timeSpan0.TotalMilliseconds : {timeSpan0.TotalMilliseconds}");


            DateTime start1 = DateTime.Now;
            //tree.ContainsKey(testCases[0]);
            for (int i = testCases.Count - 1; i >= 0; i--)
            {
                tree.ContainsKey(testCases[i]);
            }
            DateTime end1 = DateTime.Now;
            TimeSpan timeSpan1 = end1 - start1;
            Console.WriteLine($"timeSpan1.TotalMilliseconds: {timeSpan1.TotalMilliseconds}");
            //Console.WriteLine(tree.GetMaxListLength());

            Console.ReadLine();
        }
    }
}

