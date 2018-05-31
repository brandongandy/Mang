using MaNG;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mang
{
  public class NameGenerator
  {
    #region Fields

    private MarkovData markovData;
    private readonly int listSize = 20;
    private List<string> stringsUsed = new List<string>();

    private readonly int tokenLength;
    private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    #endregion

    #region Properties

    public List<string> NameList { get; set; }

    #endregion

    public NameGenerator(IEnumerable<string> input, int tokenLength)
    {
      this.tokenLength = tokenLength;

      markovData = new MarkovData(input, tokenLength);
      NameList = GetNameList(listSize);
    }

    private List<string> GetNameList(int listSize)
    {
      List<string> names = new List<string>();
      for (int i = 0; i < listSize; i++)
      {
        string nextName = GetNextName();
        if (names.Contains(nextName))
        {
          i--;
          continue;
        }
        else
        {
          names.Add(nextName);
        }
      }
      return names;
    }

    private string GetNextName()
    {
      string nextName = "";

      // Only returns names that haven't been used yet, and names that begin
      // and end with letters (a lot of input has dashes or apostrophes)

     
      // get a random name from the input samples
      // then generate a word length to aim at

      int next = RandomNumber.Next(markovData.Samples.Count);
      int minLength = tokenLength + 2;
      int maxLength = RandomNumber.Next(minLength + tokenLength, markovData.Samples[next].Length + minLength);
      int nameLength = RandomNumber.Next(minLength, maxLength);

      // generate the next name: a random substring of the random sample name
      // then get a random next letter based on the previous ngram

      nextName = markovData.Samples[next].Substring(RandomNumber.Next(0, markovData.Samples[next].Length - tokenLength), tokenLength);

      while (nextName.Length < nameLength)
      {
        string token = nextName.Substring(nextName.Length - tokenLength, tokenLength);
        if (markovData.MarkovChain.ContainsKey(token))
        {
          nextName += NextLetter(token);
        }
        else
        {
          break;
        }
      }

      nextName = textInfo.ToTitleCase(nextName.ToLower());

      stringsUsed.Add(nextName);

      return nextName;
    }

    private char NextLetter(string token)
    {
      // get all the letters that come after the passed-in token
      // then pick a random one and return it

      List<char> letters = markovData.MarkovChain[token];
      int nextLetter = RandomNumber.Next(letters.Count);
      return letters[nextLetter];
    }
  }
}
