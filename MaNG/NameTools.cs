using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mang
{
  public class NameTools : INotifyPropertyChanged
  {
    #region Fields
    
    private List<string> nameSources;
    private List<string> nameTypes;
    private List<string> nameSubTypes;
    private string markovChainList;

    #endregion

    #region Properties

    public List<int> TokenLengthList { get; } = new List<int>{ 1, 2, 3, 4, 5 };

    public int TokenLength { get; set; }

    /// <summary>
    /// The name of the root folder where all of the sub-folders containing metadata and data are held.
    /// </summary>
    public string RootDirectory { get => @"Names"; }

    /// <summary>
    /// The name of the current "Source" directory through which the program should browse.
    /// </summary>
    public string NameSourceDirectory { get; set; }

    /// <summary>
    /// The name of the current "Type" directory through which the program should browse.
    /// </summary>
    public string NameTypeDirectory { get; set; }

    /// <summary>
    /// The name of the current "SubType" directory through which the program should browse.
    /// </summary>
    public string NameSubTypeDirectory { get; set; }

    /// <summary>
    /// A list of geographical regions, fantasy literature, etc., from which the name lists are derived.
    /// </summary>
    public List<string> NameSources
    {
      get { return nameSources; }
      private set { nameSources = value; NotifyPropertyChanged(); }
    }

    /// <summary>
    /// Sub-regions, cultures, etc., from which the SubType lists are derived.
    /// </summary>
    public List<string> NameTypes
    {
      get { return nameTypes; }
      private set { nameTypes = value; NotifyPropertyChanged(); }
    }

    /// <summary>
    /// Denotes the granularity at which names are generated.
    /// </summary>
    public List<string> NameSubTypes
    {
      get { return nameSubTypes; }
      private set { nameSubTypes = value; NotifyPropertyChanged(); }
    }

    /// <summary>
    /// A formatted list of strings containing Markov Chain output for use in TextBoxes.
    /// </summary>
    public string MarkovChainList
    {
      get { return markovChainList; }
      set { markovChainList = value; NotifyPropertyChanged(); }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes the NameTools class and populates the lists with default values.
    /// </summary>
    public NameTools()
    {
      NameSources = GetNameSources();
      NameTypes = GetNameTypes();
      NameSubTypes = GetNameSubTypes();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Use to refresh the current list of NameTypes after parameter selection.
    /// </summary>
    public void RefreshNameTypes()
    {
      NameTypes = GetNameTypes();
    }

    /// <summary>
    /// Use to refresh the current list of NameSubTypes after parameter selection.
    /// </summary>
    public void RefreshNameSubTypes()
    {
      NameSubTypes = GetNameSubTypes();
    }

    /// <summary>
    /// Populates the MarkovChainList from preset data in the file system.
    /// </summary>
    public void FromPreset()
    {
      string currentDirectory = $@"{RootDirectory}\{NameSourceDirectory}\{NameTypeDirectory}\{NameSubTypeDirectory}";

      IEnumerable<string> txtFiles = Directory.EnumerateFiles(currentDirectory, "*.*");

      // if there are multiple input files in the subdir, just shove them all
      // into one list
      List<string> input = new List<string>();
      foreach (string filePath in txtFiles)
      {
        input = (File.ReadAllLines(filePath).ToList());
      }

      NameGenerator ng = new NameGenerator(input, TokenLength);

      MarkovChainList = String.Join(Environment.NewLine, ng.NameList);
    }

    /// <summary>
    /// Takes an input string and parses it, then populates the MarkovChainList with the output.
    /// </summary>
    /// <param name="input">The input string for the Markov chain</param>
    public void FromInput(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        throw new ArgumentNullException();
      }

      char[] separator = { ' ', '\n', '\r' };

      string[] userInput = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      
      NameGenerator ng = new NameGenerator(userInput, TokenLength);
      MarkovChainList = String.Join(Environment.NewLine, ng.NameList);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Iterates through the program's Root Directory to determine the list of folders from which the NameSources
    /// get their data.
    /// </summary>
    /// <returns>A list of folder names to be used as NameSources</returns>
    private List<string> GetNameSources()
    {
      List<string> nameSourceType = new List<string>();
      DirectoryInfo sourceRoot = new DirectoryInfo(RootDirectory);
      DirectoryInfo[] subDirectories = sourceRoot.GetDirectories();

      foreach (DirectoryInfo di in subDirectories)
      {
        nameSourceType.Add(di.ToString());
      }

      return nameSourceType;
    }

    /// <summary>
    /// Iterates through subfolders of the given NameSource to determine the list of NameTypes from which the
    /// NameSubTypes will get their data.
    /// </summary>
    /// <returns>A list of folder names to be used as NameTypes</returns>
    private List<string> GetNameTypes()
    {
      string subRoot = $@"{RootDirectory}\{NameSourceDirectory}";

      List<string> nameType = new List<string>();
      DirectoryInfo thisRoot = new DirectoryInfo(subRoot);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();

      foreach (DirectoryInfo di in subDir)
      {
        nameType.Add(di.ToString());
      }

      return nameType;
    }

    /// <summary>
    /// Iterates through the files of the given NameType folder to generate a list of NameSubTypes to be used
    /// by the NameGenerator in generating Markov names.
    /// </summary>
    /// <returns>A list of file names to be used as NameSubTypes</returns>
    private List<string> GetNameSubTypes()
    {
      string subRoot = $@"{RootDirectory}\{NameSourceDirectory}\{NameTypeDirectory}";

      List<string> nameSubType = new List<string>();
      DirectoryInfo thisRoot = new DirectoryInfo(subRoot);
      DirectoryInfo[] subDir = thisRoot.GetDirectories();

      try
      {
        foreach (DirectoryInfo di in subDir)
        {
          nameSubType.Add(di.ToString());
        }
      }
      catch (Exception e)
      {
        Console.Write(e);
      }
      return nameSubType;
    }

    #endregion

    #region INotifyPropertyChanged Impl

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}
