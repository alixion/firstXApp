using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace firstXApp.ViewModels
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            DeleteNote = new Command(() =>
              {
                  NoteText = string.Empty;
              });

            SaveNote = new Command(() =>
            {
                Notes.Add(NoteText);
                NoteText = string.Empty;
            });

            SelectionChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage
                {
                    BindingContext = detailVM
                };

                await Application.Current.MainPage.Navigation.PushAsync(detailPage);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Notes { get; set; } = new ObservableCollection<string>();

        string noteText;
        public string NoteText
        {
            get => noteText;
            set {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));  
            }
        }

        string selectedNote;
        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedNote)));
            }
        }




        public Command SaveNote { get; }
        public Command DeleteNote { get; }
        public Command SelectionChangedCommand { get; }
    }
}
