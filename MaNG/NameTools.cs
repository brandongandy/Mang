using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mang
{ 
  public class NameTools
  {
    // Populate the drop down lists
    public static List<int> OrderLength = new List<int>();
    public static List<int> MinLength = new List<int>();

    public static void PopulateDropDowns()
    {
      // Order and length max values should remain the same -- too high on either and the work
      // will take too long to be useful
      for (int i = 1; i < 5; i++) {
        OrderLength.Add(i);
        MinLength.Add(i);
      }
    }

    public static List<string> GetNameSource()
    {
      List<string> NameSourceType = new List<string>();
      DirectoryInfo thisRoot = new DirectoryInfo(GlobalProperties.ROOTDIR);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();
      try
      {
        foreach (DirectoryInfo di in subDir)
        {
          NameSourceType.Add(di.ToString());
        }
      } catch (Exception e)
      {
        // TODO: Handle a directory / file not found exception
        Console.Write(e);
      }
      return NameSourceType;
    }

    public static List<string> GetNameType()
    {
      List<string> NameType = new List<string>();
      NameType.Clear();
      string subRoot = GlobalProperties.ROOTDIR + GlobalProperties.SOURCE;
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

    public static List<string> GetNameSubType()
    {
      List<string> NameSubType = new List<string>();
      NameSubType.Clear();
      string subRoot = GlobalProperties.ROOTDIR + GlobalProperties.SOURCE + @"\" + GlobalProperties.TYPE;
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

    public static string FromPreset()
    {
      string curDir = GlobalProperties.ROOTDIR + GlobalProperties.SOURCE + @"\" + GlobalProperties.TYPE + @"\" + GlobalProperties.SUBTYPE;
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

    public static string FromInput(string input)
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
