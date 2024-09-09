using Microsoft.Maui.Controls;

namespace MAUILearning
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void OnTaskDetailsClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TaskDetailsPage());
        }
    }
}
