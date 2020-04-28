using firstXApp.Models;
using firstXApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace firstXApp
{
    public class NoXamlMainPage : ContentPage
    {

        public NoXamlMainPage()
        {
            BackgroundColor = Color.PowderBlue;
            BindingContext = new NoXamlMainPageViewModel();

            var xamagonImage = new Image
            {
                Source = "xamagon.png"
            };

            var editor = new Editor
            {
                Placeholder = "Enter note...",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };
            editor.SetBinding(Editor.TextProperty, "NoteText");

            var saveButton = new Button
            {
                Text = "Save",
                BackgroundColor = Color.LightGreen,
                Margin = new Thickness(10)
            };
            saveButton.SetBinding(Button.CommandProperty, "SaveNote");

            var deleteButton = new Button
            {
                Text = "Delete notes",
                BackgroundColor = Color.OrangeRed,
                Margin = new Thickness(10)
            };
            deleteButton.SetBinding(Button.CommandProperty, "DeleteNotes");


            

            var collectionView = new CollectionView
            {
                ItemTemplate = new NotesTemplate()
            };
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, nameof(NoXamlMainPageViewModel.Notes));
            collectionView.SetBinding(CollectionView.SelectedItemProperty, nameof(NoXamlMainPageViewModel.SelectedNote));
            collectionView.SetBinding(CollectionView.SelectionChangedCommandProperty, nameof(NoXamlMainPageViewModel.SelectNote));

            var grid = new Grid
            {
                Margin = new Thickness(20, 40),
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width=new GridLength(1, GridUnitType.Star)}
                },
                RowDefinitions =
                {
                    new RowDefinition {Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition {Height=new GridLength(2.5,GridUnitType.Star)},
                    new RowDefinition {Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition {Height=new GridLength(2,GridUnitType.Star)},
                }
            };

            grid.Children.Add(xamagonImage, 0, 0);
            Grid.SetColumnSpan(xamagonImage, 2);

            grid.Children.Add(editor, 0, 1);
            Grid.SetColumnSpan(editor, 2);

            grid.Children.Add(saveButton, 0, 2);
            grid.Children.Add(deleteButton, 1, 2);

            grid.Children.Add(collectionView, 0, 3);
            Grid.SetColumnSpan(collectionView, 2);

            Content = grid;
        }

        class NotesTemplate:DataTemplate
        {
            public NotesTemplate():base(LoadTemplate)
            {

            }
            static StackLayout LoadTemplate()
            {
                var textLabel = new Label();
                textLabel.SetBinding(Label.TextProperty, nameof(NoteModel.Text));

                var frame = new Frame
                {
                    VerticalOptions = LayoutOptions.Center,
                    Content = textLabel
                };

                return new StackLayout
                {
                    Children = { frame },
                    Padding = new Thickness(10, 10)
                };
            }
        }
    }
}