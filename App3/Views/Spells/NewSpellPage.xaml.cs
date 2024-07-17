using App3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	public partial class NewSpellPage : ContentPage
	{
		public NewSpellPage ()
		{
            InitializeComponent();
            BindingContext = new Spell();
		}
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var spell = (Spell)BindingContext;
            if (!string.IsNullOrWhiteSpace(spell.Name))
            {
                await App.CDatabase.SaveSpellAsync(spell);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}