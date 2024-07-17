using App3.Views;
using Xamarin.Forms;

namespace App3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CharacterPage), typeof(CharacterPage));
            Routing.RegisterRoute(nameof(NewCharacterPage), typeof(NewCharacterPage));
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
            Routing.RegisterRoute(nameof(SelectedSpellPage), typeof(SelectedSpellPage));
            Routing.RegisterRoute(nameof(NewSpellPage), typeof(NewSpellPage));
        }
    }
}
