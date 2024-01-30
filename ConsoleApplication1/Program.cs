using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
           AnagramChecker();
           Console.ReadKey();
        }

        private static void PalindromeChecker()
        {
            Console.Write("Enter a word or character: ");
            string input = Console.ReadLine() ?? "";
            Console.WriteLine($"{input} is {(IsPalindrome(input)? "" : "not ")}a palindrome."); //Ternary Operators
        }
        private static bool IsPalindrome(string input)
        {
            var originalInput = input.Trim().ToLower();
            var sb = new StringBuilder();
            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }
            var s = sb.ToString().Trim().ToLower().Replace(" ", "");
            var reversedInput = new string(s.Reverse().ToArray());
            return reversedInput == s;
        }

        private static void AnagramChecker()
        {
            Console.Write("Enter Word 1: ");
            string input1 = Console.ReadLine();
            Console.Write("Enter word 2: ");
            string input2 = Console.ReadLine();
            AreAnagrams(input1, input2);
            Console.WriteLine($"{input1} and {input2} is {(AreAnagrams(input1, input2)? "" : "not")}an anagram!");
        }

        private static bool AreAnagrams(string input1, string input2)
        {
            var arr1 = input1.Trim().ToLower().Replace(" ", "").ToCharArray();
            var arr2 = input2.Trim().ToLower().Replace(" ", "").ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            var string1 = new string(arr1);
            var string2 = new string(arr2);
            return string1 == string2;
        }
    }
}