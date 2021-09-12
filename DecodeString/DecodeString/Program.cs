using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeString
{
    class Program
    {
        static void Main(string[] args)
        {
            ///LeetCode 394 Decode String
            Console.WriteLine(DecodeString("3[z]2[2[y]pq4[2[jk]e1[f]]]ef"));
            Console.ReadLine();
        }

        public static string DecodeString(string s)
        {
            var curStr = new StringBuilder();

            var strStack = new Stack<string>();
            var multStack = new Stack<int>();

            int mult = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsDigit(s[i]))
                {
                    mult = mult * 10 + s[i] - '0';
                }
                else
                {
                    if (mult > 0)
                    {
                        multStack.Push(mult);
                        mult = 0;
                    }

                    if (s[i] == '[')
                    {
                        strStack.Push(curStr.ToString());
                        curStr.Clear();
                    }
                    else
                    if (s[i] == ']')
                    {
                        int max = multStack.Pop();
                        StringBuilder temp = new StringBuilder(strStack.Pop());
                        do
                        {
                            temp.Append(curStr);
                            max--;
                        }
                        while (max > 0);
                        curStr = temp;
                    }
                    else
                    {
                        curStr.Append(s[i]);
                    }
                }
            }

            return curStr.ToString();
        }
    }
}
