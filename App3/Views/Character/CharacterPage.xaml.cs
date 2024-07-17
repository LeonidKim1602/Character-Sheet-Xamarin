using App3.Models;
using System;
using Xamarin.Forms;


namespace App3.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CharacterPage : ContentPage
    {

        public string ItemId
        {
            set
            {
                LoadCharacter(value);
            }
        }

        public CharacterPage()
        {
            InitializeComponent();
        }

        async void LoadCharacter(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                Character character = await App.CDatabase.GetCharacterByIdAsync(id);
                BindingContext = character;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load character.");
            }
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            Character character = (Character)BindingContext;

            if (character != null)
            {
                await App.CDatabase.DeleteCharacterAsync(character);

                await Shell.Current.GoToAsync("..");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var character = (Character)BindingContext;

            await App.CDatabase.SaveCharacterAsync(character);


            await Navigation.PopToRootAsync();
        }
        private async void OnAddMaxHPButtonClicked(object sender, EventArgs e)
        {
            string input = await DisplayPromptAsync("Add MaxHP", "Enter value to add to MaxHP:");

            if (int.TryParse(input, out int value))
            {
                var character = (Character)BindingContext;
                character.MaxHP += value;
                await App.CDatabase.SaveCharacterAsync(character);
            }
        }


    }

}
