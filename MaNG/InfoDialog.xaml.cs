using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mang
{
  /// <summary>
  /// Interaction logic for InfoDialog.xaml
  /// </summary>
  public partial class InfoDialog : Window
  {
    public InfoDialog()
    {
      InitializeComponent();
      PreviewKeyDown += new KeyEventHandler(HandleExit);
    }

    public void InfoTextBlock_Loaded(object sender, RoutedEventArgs e)
    {
      var infoHeader = sender as TextBlock;

      infoHeader.Text = "Mang\n" +
                        "A name generator app\n" +
                        "Version - 1.0\n" +
                        "Copyright © 2017 - Brandon Gandy\n" +
                        "All rights reserved";
    }

    public void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
    {
      var infoBody = sender as TextBox;

      infoBody.Text = "Mang is a Markov Name Generator, which takes a set of input strings (names or words) and uses a Markov chain to generate similar, " +
                  "but not the same, output. This allows you to easily take a list of names or words in your own conlang (or any language), and generate additional " +
                  "names or words that fit right in with what you already have.\n\n" +
                  "The pre-set names were aggregated from various open sources around the internet.\n\n" +
                  "Special thanks to:\n" +
                  "Kate Monk's Onomastikon, a wonderful compilation of names from all around the world. In Mang, many Medieval, Ancient World, and Aztec name sources " +
                  "were derived from this source, as well as the general layout of the menu structure. Please give this site a look.\n" +
                  "https://tekeli.li/onomastikon/index.html \n\n" +
                  "donjon, which inspired me to make this tool.\n" +
                  "https://donjon.bin.sh/ \n\n" +
                  "Icon by Freepik\nhttp://www.flaticon.com/authors/freepik\nIcon license Creative Commons BY 3.0";
    }

    private void InfoOKButton_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void HandleExit(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        Close();
      }
    }
  }
}
