using App3.Data;
using App3.Models;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3
{
    public partial class App : Application
    {
        static NoteDatabase database;
        static CharacterDatabase characterDatabase;

        public static NoteDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public static CharacterDatabase CDatabase
        {
            get
            {
                if(characterDatabase == null)
                {
                    characterDatabase = new CharacterDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Character.db3"));
                }
                return characterDatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            // Check if spells have already been added
            bool spellsAdded = Preferences.Get("SpellsAdded", false);
            if (!spellsAdded)
            {
                Mock mock = new Mock();
                mock.AddSpells(CDatabase);

                // Set the flag indicating that spells have been added
                Preferences.Set("SpellsAdded", true);
            }

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
