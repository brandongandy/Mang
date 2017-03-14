using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mang
{ 
  public class NameTools
  {
    #region Field Region

    // Root directory that will contain the subfolders for name source and sub-type
    private static readonly string rootDir = @"0_1\";

    private List<int> orderLength;
    private List<int> minLength;

    #endregion

    #region Property Region

    // Populate the drop down lists
    public List<int> OrderLength
    {
      get { return orderLength; }
      private set { orderLength = value; }
    }

    public List<int> MinLength
    {
      get { return minLength; }
      private set { minLength = value; }
    }

    #endregion

    #region Constructor

    public NameTools()
    {
      orderLength = new List<int>();
      minLength = new List<int>();
    }

    #endregion

    public void PopulateDropDowns()
    {
      // Order and length max values should remain the same -- too high on either and the work
      // will take too long to be useful
      for (int i = 1; i < 5; i++) {
        orderLength.Add(i);
        minLength.Add(i);
      }
    }

    public List<string> GetNameSource()
    {
      List<string> NameSourceType = new List<string>();
      DirectoryInfo thisRoot = new DirectoryInfo(rootDir);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();

      foreach (DirectoryInfo di in subDir)
      {
        NameSourceType.Add(di.ToString());
      }

      return NameSourceType;
    }

    public List<string> GetNameType()
    {
      List<string> NameType = new List<string>();
      NameType.Clear();
      string subRoot = rootDir + GlobalProperties.SOURCE;
      DirectoryInfo thisRoot = new DirectoryInfo(subRoot);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();

      try
      {
        foreach (DirectoryInfo di in subDir)
        {
          NameType.Add(di.ToString());
        }
      } catch (Exception e)
      {
        Console.Write(e);
      }

      return NameType;
    }

    public List<string> GetNameSubType()
    {
      List<string> NameSubType = new List<string>();
      NameSubType.Clear();
      string subRoot = rootDir + GlobalProperties.SOURCE + @"\" + GlobalProperties.TYPE;
      DirectoryInfo thisRoot = new DirectoryInfo(subRoot);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();

      try
      {
        foreach (DirectoryInfo di in subDir)
        {
          NameSubType.Add(di.ToString());
        }
      } catch (Exception e)
      {
        Console.Write(e);
      }
      return NameSubType;
    }

    public string FromPreset()
    {
      string curDir = NameTools.rootDir + GlobalProperties.SOURCE + @"\" + GlobalProperties.TYPE + @"\" + GlobalProperties.SUBTYPE;
      IEnumerable<string> txtFiles = Directory.EnumerateFiles(curDir, "*.*");
      try
      {
        // if there are multiple input files in the subdir, just shove them all
        // into one list
        List<string> input = new List<string>();
        foreach (string filePath in txtFiles)
        {
          input = (File.ReadAllLines(filePath).ToList());
        }

        NameGenerator ng = new NameGenerator(input);
        string[] output = ng.nameList;
        return String.Join(Environment.NewLine, output);
      } catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    public string FromInput(string input)
    {
      char[] separator = { ' ', '\n', '\r' };

      string[] userInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);

      if (input.Length <= GlobalProperties.ORDER)
      {
        return "You can't generate names\n from an empty list.";
      }

      if (userInput.Length < 5)
      {
        return "Your list isn't long enough.\nMake sure it's at least 5 items long.";
      }

      try
      {
        NameGenerator ng = new NameGenerator(userInput);
        string[] markovOutput = ng.nameList;
        return String.Join(Environment.NewLine, markovOutput);
      } catch (Exception ex)
      {
        return ex.ToString();
      }
    }
  }
}
