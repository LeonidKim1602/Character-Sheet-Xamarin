using App3.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    public partial class SpellsPage : ContentPage
    {
        public SpellsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.CDatabase.GetSpellsAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Spell spell = (Spell)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(SelectedSpellPage)}?{nameof(SelectedSpellPage.ItemId)}={spell.Id.ToString()}");
            }
        }
        async void OnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewSpellPage));
        }
    }
}