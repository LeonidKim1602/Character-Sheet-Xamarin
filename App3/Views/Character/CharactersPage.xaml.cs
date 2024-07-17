using App3.Models;
using System;
using System.Linq;
using Xamarin.Forms;

namespace App3.Views
{
    public partial class CharactersPage : ContentPage
    {
        public CharactersPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.CDatabase.GetCharactersAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewCharacterPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection != null)
            {
                Character character = (Character)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CharacterPage)}?{nameof(CharacterPage.ItemId)}={character.Id.ToString()}");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var character = (Character)BindingContext;
            character.HP = character.MaxHP;

            if (!string.IsNullOrWhiteSpace(character.Name) && !string.IsNullOrWhiteSpace(character.Class) && !string.IsNullOrWhiteSpace(character.Race) && !string.IsNullOrWhiteSpace(character.Alignment))
            {
                await App.CDatabase.SaveCharacterAsync(character);
            }

            await Navigation.PopToRootAsync();
        }
    }
}