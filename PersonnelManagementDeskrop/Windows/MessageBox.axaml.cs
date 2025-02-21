using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PersonnelManagementDeskrop.Windows;

public partial class MessageBox : Window
{
    public string MessageText { get; set; }
    public string TitleText { get; set; }
    public bool HasNegativeButton { get; set; }
    public string ClickedButton { get; private set; }
    public MessageBox(string titleText, string messageText, bool hasNegativeButton)
    {
        InitializeComponent();
        TitleText = titleText;
        MessageText = messageText;
        HasNegativeButton = hasNegativeButton;
        DataContext = this;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        ClickedButton = button.Content.ToString();
        Close();
    }
}