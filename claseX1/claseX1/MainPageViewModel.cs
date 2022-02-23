using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace claseX1
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        public Command SelectedNoteChangedCommand { get; }

        string selectedNote;

        public string SelectedNote {
            get => selectedNote;
            set
            {
                selectedNote = value;

                var args = new PropertyChangedEventArgs(nameof(selectedNote));

                PropertyChanged?.Invoke(this, args);
            }
        }
        public MainPageViewModel()
        {
            Notes = new ObservableCollection<string>();

            SelectedNoteChangedCommand = new Command(async() =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);

                var detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });

            EraseCommand = new Command(() =>
              {
                  TheNote = string.Empty;
              });

            SaveCommand = new Command(() =>
              {
                  Notes.Add(TheNote);

                  TheNote = string.Empty;
              });
        }

        public ObservableCollection<string> Notes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }

        public Command EraseCommand { get; }

    }
}
