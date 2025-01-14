﻿using App3.Models;
using System;
using Xamarin.Forms;


namespace App3.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public NoteEntryPage()
        {
            InitializeComponent();

            BindingContext = new Note();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note) BindingContext;
            note.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveNoteAsync(note);
            }

            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.Database.DeleteNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnApplyGoldChangeButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(GoldChangeEntry.Text, out double changeValue))
            {
                var note = (Note)BindingContext;
                note.Gold += changeValue;
                await App.Database.SaveNoteAsync(note);
            }
            GoldChangeEntry.Text = string.Empty; // Clear the input field after applying the change
        }
    }

}