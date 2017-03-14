using Mang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace MaNG
{
  /// <summary>
  /// Interaction logic for RootDirPicker.xaml
  /// </summary>
  public partial class RootDirPicker : Window
  {
    #region Field Region
    
    string rootDir;

    #endregion

    #region Property Region
    
    public string RootDir
    {
      get { return rootDir; }
    }

    #endregion

    public RootDirPicker()
    {
      InitializeComponent();
    }

    private void rootDirTextbox_Loaded(object sender, RoutedEventArgs e)
    {
      rootDir = GlobalProperties.ROOTDIR;
      rootDirTextbox.Text = GlobalProperties.ROOTDIR;
    }

    private void rootDirPickerBtn_Click(object sender, RoutedEventArgs e)
    {
      var dialog = new CommonOpenFileDialog();
      dialog.IsFolderPicker = true;
      dialog.InitialDirectory = Directory.GetCurrentDirectory();
      dialog.EnsureFileExists = true;
      dialog.EnsurePathExists = true;
      CommonFileDialogResult result = dialog.ShowDialog();

      if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
      {
        rootDir = dialog.FileName;
        rootDirTextbox.Text = rootDir;
      }
    }

    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(rootDir))
      {
        MessageBox.Show("Please select a folder.", "Invalid Folder", MessageBoxButton.OK);
      }
      else
      {
        GlobalProperties.ROOTDIR = rootDir;
      }
      Close();
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
