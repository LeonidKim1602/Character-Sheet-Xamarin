using App3.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCharacterPage : ContentPage
    {
        public NewCharacterPage()
        {
            InitializeComponent();

            BindingContext = new Character
            {
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10
            };
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var character = (Character)BindingContext;
            character.HP = character.MaxHP;

            if (!string.IsNullOrWhiteSpace(character.Name) && !string.IsNullOrWhiteSpace(character.Class) && !string.IsNullOrWhiteSpace(character.Race) && !string.IsNullOrWhiteSpace(character.Alignment) && !string.IsNullOrWhiteSpace(character.Background))
            {
                await App.CDatabase.SaveCharacterAsync(character);
            }
            else {
                MessageLabel.Text = "Не все поля заполнены!";
                MessageLabel.TextColor = Color.Red;
                return;
            }

            await Navigation.PopToRootAsync();
        }
    }
}