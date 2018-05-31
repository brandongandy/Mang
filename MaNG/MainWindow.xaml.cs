using MaNG;
using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Mang
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private NameTools NameTools;

    public MainWindow()
    {
      InitializeComponent();
      NameTools = new NameTools();

      DataContext = NameTools;
    }

    private void NameSourceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      NameTools.NameSourceDirectory = comboBox.SelectedValue as string;

      try
      {
        NameTools.RefreshNameTypes();
        nameTypeCB.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    private void NameType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      NameTools.NameTypeDirectory = comboBox.SelectedValue as string;

      try
      {
        NameTools.RefreshNameSubTypes();
        nameSubTypeCB.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    private void NameSubType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      NameTools.NameSubTypeDirectory = comboBox.SelectedValue as string;
    }

    private void OrderLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      NameTools.TokenLength = (int)comboBox.SelectedValue;
    }

    private void Preset_Click(object sender, RoutedEventArgs e)
    {
      NameTools.FromPreset();
    }

    private void UserInput_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        NameTools.FromInput(markovInputBox.Text);
      } catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    private void Info_Click(object sender, RoutedEventArgs e)
    {
      InfoDialog infoDialog = new InfoDialog();
      infoDialog.ShowDialog();
    }

    private void Help_Click(object sender, RoutedEventArgs e)
    {
      HelpDialog helpDialog = new HelpDialog();
      helpDialog.ShowDialog();
    }
  }
}
