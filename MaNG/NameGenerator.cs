using System;
using System.Collections.Generic;

namespace Mang
{
  public class NameGenerator
  {
    private SecondMarkov markov;
    private int listSize = 50;
    private List<string> stringsUsed = new List<string>();
    private Random rand = new Random();
    private int stringsUsedSized = 0;

    public string[] nameList;

    public NameGenerator(IEnumerable<string> input)
    {
      markov = new SecondMarkov(input);
      nameList = GetNextNames();
    }

    private string[] GetNextNames()
    {
      string[] names = new string[listSize];
      for (int i = 0; i < listSize; i++)
      {
        names[i] = GetNextName();
      }
      return names;
    }

    private string GetNextName()
    {
      string nextName = "";

      // Only returns names that haven't been used yet, and names that begin
      // and end with letters (a lot of input has dashes or apostrophes)

      do
      {
        // get a random name from the input samples
        // then generate a word length to aim at

        int next = rand.Next(markov.samples.Count);
        int minLength = GlobalProperties.ORDER + 2;
        int maxLength = rand.Next(minLength + GlobalProperties.ORDER, markov.samples[next].Length + minLength);
        int nameLength = rand.Next(minLength, maxLength);

        // generate the next name: a random substring of the random sample name
        // then get a random next letter based on the previous ngram

        nextName = markov.samples[next].Substring(rand.Next(0, markov.samples[next].Length - GlobalProperties.ORDER), GlobalProperties.ORDER);
        while (nextName.Length < nameLength)
        {
          string token = nextName.Substring(nextName.Length - GlobalProperties.ORDER, GlobalProperties.ORDER);
          if (markov.markovChain.ContainsKey(token))
          {
            nextName += NextLetter(token);
          }
          else
          {
            break;
          }
        }

        // Capitalize the first letter of the name, or the first letter of the parts
        // of the name if there's a space in there

        if (nextName.Contains(" "))
        {
          string[] tokens = nextName.Split(' ');
          nextName = "";
          for (int t = 0; t < tokens.Length; t++)
          {
            if (tokens[t] == "") { continue; }

            if (tokens[t].Length == 1)
            {
              tokens[t] = tokens[t].ToUpper();
            }
            else
            {
              tokens[t] = tokens[t].Substring(0, 1) + tokens[t].Substring(1).ToLower();
            }

            if (nextName != "") { nextName += " "; }

            nextName += tokens[t];
          }
        }
        else
        {
          nextName = nextName.Substring(0, 1) + nextName.Substring(1).ToLower();
        }
      } while (stringsUsed.Contains(nextName)
               || !char.IsLetter(nextName[0])
               || !char.IsLetter(nextName[nextName.Length - 1]));
      stringsUsed.Add(nextName);
      stringsUsedSized++;
      if (stringsUsedSized > 2) { stringsUsed.Clear(); }

      return nextName;
    }

    private char NextLetter(string token)
    {
      // get all the letters that come after the passed-in token
      // then pick a random one and return it

      List<char> letters = markov.markovChain[token];
      int nextLetter = rand.Next(letters.Count);
      return letters[nextLetter];
    }
  }
}
