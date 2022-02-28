using claseX1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using System.Text;

namespace claseX1.ViewModels
{
    public class NewPageViewModel : INotifyPropertyChanged
    {
        public NewPageViewModel()
        {
            Notes = new ObservableCollection<NoteModel>();

            SaveNoteCommand = new Command(() =>
            {
                Notes.Add(new NoteModel { Text = NoteText });
                NoteText = string.Empty;
            },
            () => !string.IsNullOrEmpty(NoteText));

            EraseNotesCommand = new Command(() => Notes.Clear());

            NoteSelectedCommand = new Command(async () =>
            {
                if (SelectedNote is null)
                    return;

                var detailViewModel = new NewDetailPageViewModel
                {
                    NoteText = SelectedNote.Text
                };

                await Application.Current.MainPage.Navigation.PushAsync(new NewDetailPage(detailViewModel));

                SelectedNote = null;
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoteText)));

                SaveNoteCommand.ChangeCanExecute();
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

        public ObservableCollection<NoteModel> Notes { get; }

        public Command NoteSelectedCommand { get; }
        public Command SaveNoteCommand { get; }
        public Command EraseNotesCommand { get; }

    }
}
