using System;
using System.Collections.Generic;

namespace Mang
{
  public class MarkovData
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

    private readonly int tokenLength;

    /// <summary>
    /// A list of formatted entries for use in a Markov chain.
    /// </summary>
    public List<string> Samples { get; set; }

    /// <summary>
    /// The list of token/list pairs that constitute the data behind a Markov chain.
    /// </summary>
    public Dictionary<string, List<char>> MarkovChain { get; set; }

    public MarkovData(IEnumerable<string> rawSampleNameList, int tokenLength)
    {
      this.tokenLength = tokenLength;

      Samples = PopulateSampleList(rawSampleNameList);
      MarkovChain = PopulateMarkovChain(Samples);
    }

    /// <summary>
    /// Iterates through the input list and adds only valid values to the useable list of Sample strings.
    /// </summary>
    /// <param name="rawSampleNameList">A list of names to potentially be used by the Markov chain</param>
    /// <returns>A list of valid entries for the Markov chain</returns>
    private List<string> PopulateSampleList(IEnumerable<string> rawSampleNameList)
    {
      if (rawSampleNameList is null)
      {
        throw new ArgumentNullException();
      }

      List<string> samples = new List<string>();

      foreach (string line in rawSampleNameList)
      {
        char[] splitChar = new char[] { ',', '\n' };
        string[] tokens = line.Split(splitChar);

        foreach (string word in tokens)
        {
          string upper = word.Trim().ToUpper();
          if (upper.Length >= tokenLength)
          {
            samples.Add(upper);
          }
        }
      }

      return samples;
    }

    /// <summary>
    /// Populates the Markov chain with tokens and values.
    /// </summary>
    /// <param name="sampleNameList">A formatted list of strings to parse through</param>
    private Dictionary<string, List<char>> PopulateMarkovChain(IEnumerable<string> sampleNameList)
    {
      if (sampleNameList is null)
      {
        throw new ArgumentNullException();
      }

      Dictionary<string, List<char>> markovChain = new Dictionary<string, List<char>>();

      foreach (string word in sampleNameList)
      {
        for (int letter = 0; letter < word.Length - tokenLength; letter++)
        {
          string token = word.Substring(letter, tokenLength);

          List<char> entry = new List<char>();

          if (markovChain.ContainsKey(token))
          {
            entry = markovChain[token];
          }
          else
          {
            markovChain[token] = entry;
          }

          entry.Add(word[letter + tokenLength]);
        }
      }

      return markovChain;
    }
  }
}
