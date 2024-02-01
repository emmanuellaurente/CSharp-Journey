using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        { 
            CommonPrefix(); 
           // StringReverse();
           // PalindromeChecker();
           // AnagramChecker();
           Console.ReadKey();
        }

        private static void PalindromeChecker()
        {
            var input = GetStringInput("Enter a word or character: ");
            Console.WriteLine($"{input} is {(IsPalindrome(input) ? "" : "not ")}a palindrome."); //Ternary Operators
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
            var input1 = GetStringInput("Enter Word 1: ");
            var input2 = GetStringInput("Enter word 2: ");
            AreAnagrams(input1, input2);
            Console.WriteLine($"{input1} and {input2} is {(AreAnagrams(input1, input2) ? "" : "not")}an anagram!");
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

        public static string GetStringInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;
                
                return input;
            }
        }

        public static void StringReverse()
        {
            string s = GetStringInput("Enter string here: ");
            ReverseWords(s);
            Console.WriteLine($"Original Sequence: {s} | Reversed Sequence: {ReverseWords(s)}");
        }

        private static string ReverseWords(string s)
        {
            string[] wordArray = s.Split(' ');
            return string.Join(" ", wordArray.Reverse().ToArray());;
        }

        public static void CommonPrefix()
        {
            string[] stringList = GetStringInput("Enter words, please use comma to add another one:  ").Split(',');
            Console.WriteLine(LongestCommonPrefix(stringList));

        }

        public static string LongestCommonPrefix(string[] strings)
        {
            var stringList = strings;
            if (stringList == null || stringList.Length == 0)
            {
                return "Empty";
            }
            Array.Sort(stringList);
            string firstString = stringList.First();
            var commonPrefix = " ";
            for (int i = 0; i < firstString.Length; i++)
            {
                char c = stringList[0][i];
                for (int j = 0; j < stringList.Length; j++)
                {
                    if (i >= stringList[j].Length || stringList[j][i] != c)
                    {
                        return commonPrefix;
                    }
                }
                commonPrefix += c;
            }
            return commonPrefix;
        }
    }
}