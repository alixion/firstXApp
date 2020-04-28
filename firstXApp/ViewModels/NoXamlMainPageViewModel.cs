using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using firstXApp.Models;

namespace firstXApp.ViewModels
{
    public class NoXamlMainPageViewModel : INotifyPropertyChanged
    {
        public NoXamlMainPageViewModel()
        {
            SaveNote = new Command(() =>
            {
                Notes.Add(new NoteModel { Text = NoteText });
                NoteText = string.Empty;
            });
            DeleteNotes = new Command(() =>
            {
                Notes.Clear();
            });
            SelectNote = new Command(async () =>
              {
                  if (SelectedNote == null)
                      return;
                  var detailVM = new NoXamlDetailPageViewModel(SelectedNote.Text);
                  await Application.Current.MainPage.Navigation.PushAsync(new NoXamlDetailPage(detailVM));
              });
        }

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
                SaveNote.ChangeCanExecute();
            }
        }

        NoteModel selectedNote;
        public NoteModel SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
                
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NoteModel> Notes { get; set; } = new ObservableCollection<NoteModel>();
        public Command SaveNote { get; }
        public Command DeleteNotes { get; }
        public Command SelectNote { get; }
    }
}
