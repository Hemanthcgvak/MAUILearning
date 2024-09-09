namespace MAUILearning;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    // Event handler for button click
    private void OnUpdateLabelClicked(object sender, EventArgs e)
    {
        TextLabel.Text = TextInput.Text;
        TextLabel.TextColor = Color.FromArgb("#48D1CC");


        if (string.IsNullOrWhiteSpace(TextInput.Text))
        {
            TextLabel.Text = "Please enter some text!";
            TextLabel.TextColor = Color.FromArgb("#48D1CC");

        }
    }
}
