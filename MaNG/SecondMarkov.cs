using System;
using System.Collections.Generic;

namespace Mang
{
  public class SecondMarkov
  {
    /*
      TODO: 
        1. Add Damerau-Levenshtein distance check to ensure output is not
           too close to input.
        2. Add constant, low probability that a random letter from the 
           "input alphabet" is picked, instead of the normal next letter.
        3. Extend name generation to take into account input word "moulds"
           -- CVCCVVC, CVCCVC, etc., to ensure "grammar" is kept intact
           and no complete gibberish is created
    */
    public Dictionary<string, List<char>> markovChain { get; set; }
    public List<string> samples { get; set; }

    public SecondMarkov(IEnumerable<string> sampleNames)
    {
      markovChain = new Dictionary<string, List<char>>();
      samples = new List<string>();

      foreach (string line in sampleNames)
      {
        char[] splitChar = new char[] { ',', '\n'};
        string[] tokens = line.Split(splitChar);

        foreach (string word in tokens)
        {
          // convert to uppercase, trim white space
          // if the length of the word is less than the Markov Chain Order (ngram length), skip it
          // add words to list of string samples

          string upper = word.Trim().ToUpper();
          if (upper.Length < GlobalProperties.ORDER) { continue; }
          samples.Add(upper);
        }
      }

      // for each word in the list of samples
      // iterate through the letters of the word, minus the length of the Order
      // create a token, starting at the current letter, length = Order

      foreach (string word in samples)
      {
        for (int letter = 0; letter < word.Length - GlobalProperties.ORDER; letter++)
        {
          string token = word.Substring(letter, GlobalProperties.ORDER);

          // initialize an empty list of characters that will be used to insert usable tokens to a chain list
          // if the list of chain items already contains this token, set the current entry to this token
          // if not, add the token to the chain list

          List<char> markovEntry = null;
          if (markovChain.ContainsKey(token))
          {
            markovEntry = markovChain[token];
          }
          else
          {
            markovEntry = new List<char>();
            markovChain[token] = markovEntry;
          }

          markovEntry.Add(word[letter + GlobalProperties.ORDER]);

        }
      }
    }
  }
}
