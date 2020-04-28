using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace firstXApp.ViewModels
{
    public class DetailPageViewModel: INotifyPropertyChanged
    {
        private string noteText;

        public DetailPageViewModel(string note)
        {
            NoteText = note;

            DismissPage = new Command(async () =>
              {
                  await Application.Current.MainPage.Navigation.PopAsync();
              });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string NoteText 
        { 
            get => noteText; 
            set  {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));
            }
        }

        public Command DismissPage { get; }
    }
}
