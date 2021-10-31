using System;
using System.Text.RegularExpressions;

namespace GoogleCase_CamelCase
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Write a sentence: ");
      string Sentence = Console.ReadLine();
      PrintGoogleCase(Sentence);
      PrintCamelCaseStr(Sentence);
    }

    private static void PrintCamelCaseStr(string str)
    {
      char[] Sentence = str.ToLower().ToCharArray();
      Array.Reverse(Sentence);

      for (int counter = 0; counter < Sentence.Length - 1; counter++)
      {
        if (Sentence[counter + 1] == ' ')
        {
          Sentence[counter] = Char.ToUpper(Sentence[counter]);
        }
      }
      if (Sentence[Sentence.Length - 1] != ' ')
      {
        Sentence[Sentence.Length - 1] = Char.ToUpper(Sentence[Sentence.Length -1]);
      }
      Array.Reverse(Sentence);
      

      Console.WriteLine("CamelCase: " + Regex.Replace(new string(Sentence), @"\s+", ""));
    }

    private static void PrintGoogleCase(string str)
    {
      char[] Sentence = str.ToCharArray();

      Sentence[0] = Char.ToLower(Sentence[0]);
      for (int counter = 1; counter < Sentence.Length; counter++)
      {
        if (Char.IsLower(str[counter]))
        {
          Sentence[counter] = Char.ToUpper(Sentence[counter]);
        }
      }
      Console.WriteLine("GoogleCase: " + new String(Sentence));
    }
  }
}
