using claseX1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace claseX1
{
    class NewDetailPage : ContentPage
    {
        public NewDetailPage(NewDetailPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Title = "Notes Detail";

            BackgroundColor = Color.PowderBlue;

            var textLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLabel.SetBinding(Label.TextProperty, nameof(NewDetailPageViewModel.NoteText));

            var exitButton = new Button
            {
                Text = "Pop",
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(20),
                BackgroundColor = Color.Red,
                TextColor = Color.White,
                FontSize = 20
            };
            exitButton.SetBinding(Button.CommandProperty, nameof(NewDetailPageViewModel.ExitCommand));

            var stackLayout = new StackLayout
            {
                Margin = new Thickness(20, 40)
            };
            stackLayout.Children.Add(textLabel);
            stackLayout.Children.Add(exitButton);

            Content = stackLayout;
        }
    }
}
