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
      if (!string.IsNullOrEmpty(GlobalProperties.ROOTDIR))
      {
        NameTools.PopulateDropDowns();
      }
    }

    private void NameSourceType_Loaded(object sender, RoutedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      try
      {
        comboBox.ItemsSource = NameTools.GetNameSource();
      }
      catch (Exception ex)
      {
        markovInputBox.AppendText(ex.ToString());
      }
      comboBox.SelectedIndex = 0;
    }

    private void NameSourceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      GlobalProperties.SOURCE = comboBox.SelectedValue as string;
      try
      {
        nameTypeCB.ClearValue(ItemsControl.ItemsSourceProperty);
        nameTypeCB.ItemsSource = NameTools.GetNameType();
        nameTypeCB.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        markovInputBox.AppendText(ex.ToString());
      }
    }

    private void NameType_Loaded(object sender, RoutedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      comboBox.ItemsSource = NameTools.GetNameType();
      comboBox.SelectedIndex = 0;
    }

    private void NameType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      GlobalProperties.TYPE = comboBox.SelectedValue as string;
      try
      {
        nameSubTypeCB.ClearValue(ItemsControl.ItemsSourceProperty);
        nameSubTypeCB.ItemsSource = NameTools.GetNameSubType();
        nameSubTypeCB.SelectedIndex = 0;
      }
      catch (Exception ex)
      {
        markovInputBox.AppendText(ex.ToString());
      }
    }

    private void NameSubType_Loaded(object sender, RoutedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      comboBox.ItemsSource = NameTools.GetNameSubType();
      comboBox.SelectedIndex = 0;
    }

    private void NameSubType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      GlobalProperties.SUBTYPE = comboBox.SelectedValue as string;
    }

    private void OrderLength_Loaded(object sender, RoutedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      comboBox.ItemsSource = NameTools.OrderLength;
      comboBox.SelectedIndex = 2;
    }

    private void OrderLength_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      GlobalProperties.ORDER = (int)comboBox.SelectedValue;
    }

    private void MinLength_Loaded(object sender, RoutedEventArgs e)
    {
      var comboBox = sender as ComboBox;
      comboBox.ItemsSource = NameTools.MinLength;
      comboBox.SelectedIndex = 1;
    }

    private void Preset_Click(object sender, RoutedEventArgs e)
    {
      markovOutputBox.Clear();
      markovOutputBox.AppendText(NameTools.FromPreset());
    }

    private void UserInput_Click(object sender, RoutedEventArgs e)
    {
      markovOutputBox.Clear();
      markovOutputBox.AppendText(NameTools.FromInput(markovInputBox.Text));
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

    private void ChooseDirectory_Click(object sender, RoutedEventArgs e)
    {
      RootDirPicker rdp = new RootDirPicker();
      rdp.Owner = this;
      rdp.ShowDialog();

      if (!string.IsNullOrEmpty(GlobalProperties.ROOTDIR))
      {
        NameTools.PopulateDropDowns();
      }
    }
  }
}
