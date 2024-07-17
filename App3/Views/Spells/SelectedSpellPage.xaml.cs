using App3.Models;
using System;
using Xamarin.Forms;


namespace App3.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class SelectedSpellPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadSpell(value);
            }
        }
        public SelectedSpellPage()
        {
            InitializeComponent();
        }

        async void LoadSpell(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                Spell spell = await App.CDatabase.GetSpellByIdAsync(id);
                BindingContext = spell;
            }catch (Exception)
            {
                Console.WriteLine("Failed to load spell");
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var spell = (Spell)BindingContext;

            await App.CDatabase.DeleteSpellAsync(spell);

            await Shell.Current.GoToAsync("..");
        }
    }
}