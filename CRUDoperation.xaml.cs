using MAUILearning.Model;
using MAUILearning.Services;
using System;

namespace MAUILearning
{
    public partial class CRUDoperation : ContentPage
    {
        private DatabaseService _databaseService;
        private ProteinPowder _selectedProteinPowder;

        public CRUDoperation()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(Path.Combine(FileSystem.AppDataDirectory, "proteinpowder.db3"));
            LoadProteinPowders();
        }

        private async void LoadProteinPowders()
        {
            var proteinPowders = await _databaseService.GetProteinPowders();
            ProteinPowderTable.ItemsSource = proteinPowders;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(BrandEntry.Text) || string.IsNullOrWhiteSpace(ProteinEntry.Text))
            {
                await DisplayAlert("Validation", "Please fill all fields", "OK");
                return;
            }

            if (_selectedProteinPowder == null) // Add new
            {
                var newProteinPowder = new ProteinPowder
                {
                    Name = NameEntry.Text,
                    Brand = BrandEntry.Text,
                    ProteinPerServing = double.Parse(ProteinEntry.Text),
                    Flavor = FlavorEntry.Text
                };
                await _databaseService.AddProteinPowder(newProteinPowder);
            }
            else // Update existing
            {
                _selectedProteinPowder.Name = NameEntry.Text;
                _selectedProteinPowder.Brand = BrandEntry.Text;
                _selectedProteinPowder.ProteinPerServing = double.Parse(ProteinEntry.Text);
                _selectedProteinPowder.Flavor = FlavorEntry.Text;

                await _databaseService.UpdateProteinPowder(_selectedProteinPowder);
            }

            ClearForm();
            LoadProteinPowders();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_selectedProteinPowder == null)
            {
                await DisplayAlert("Error", "No item selected", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirm", "Are you sure you want to delete this protein powder?", "Yes", "No");
            if (confirm)
            {
                await _databaseService.DeleteProteinPowder(_selectedProteinPowder.Id);
                ClearForm();
                LoadProteinPowders();
            }
        }

        private void ClearForm()
        {
            NameEntry.Text = string.Empty;
            BrandEntry.Text = string.Empty;
            ProteinEntry.Text = string.Empty;
            FlavorEntry.Text = string.Empty;
            _selectedProteinPowder = null;
            SaveButton.Text = "Add Protein Powder"; // Reset button text to "Add"
        }

        private void OnProteinPowderSelected(object sender, SelectionChangedEventArgs e)
        {
            _selectedProteinPowder = e.CurrentSelection.FirstOrDefault() as ProteinPowder;

            if (_selectedProteinPowder != null)
            {
                NameEntry.Text = _selectedProteinPowder.Name;
                BrandEntry.Text = _selectedProteinPowder.Brand;
                ProteinEntry.Text = _selectedProteinPowder.ProteinPerServing.ToString();
                FlavorEntry.Text = _selectedProteinPowder.Flavor;
                SaveButton.Text = "Update Protein Powder"; // Change button text to "Update"
            }
        }
    }
}
