using Microsoft.Maui.Controls;

namespace MAUILearning
{
    public partial class TaskDetailsPage : ContentPage
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
