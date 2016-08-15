using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mang
{
  /// <summary>
  /// Interaction logic for HelpDialog.xaml
  /// </summary>
  public partial class HelpDialog : Window
  {
    public HelpDialog()
    {
      InitializeComponent();
      PreviewKeyDown += new KeyEventHandler(HandleExit);
    }

    public void HelpTextBox_Loaded(object sender, RoutedEventArgs e)
    {
      var helpText = sender as TextBlock;

      helpText.Text = "Source: Geographical region, or discrete grouping, of name type sources.\n\n" +
                      "Type: Sub-region, culture, or primary type of name to be generated.\n\n" +
                      "Sub-Type: Gender distinction, town, deity, or other type of distinction for specific name type.\n\n" + 
                      "Order: The length of the \"N-gram\" derived from the source input. For example, with an Order of 2, and a source of \"Lorem\", the first N-gram would be \"Lo\".\n\n" + 
                      "v: Generate a new output list based on the dropdown menu choices.\n\n" + 
                      ">: Generate a new output list based on the text present inside the input box.\n\n" + 
                      "Tip: When using the user-generated input, the longer your input list is, the better and more unique the results will be.";
    }

    private void HelpOKButton_Click(object sender, RoutedEventArgs e)
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
