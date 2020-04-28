using firstXApp.ViewModels;

using Xamarin.Forms;

namespace firstXApp
{
    public class NoXamlDetailPage : ContentPage
    {
        public NoXamlDetailPage(NoXamlDetailPageViewModel vm)
        {
            BindingContext = vm;
            Title = "Note detail";

            var textLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            textLabel.SetBinding(Label.TextProperty, nameof(NoXamlDetailPageViewModel.NoteText));

            var dismissButton = new Button
            {
                Text = "Back",
                BackgroundColor = Color.OrangeRed,
                Margin = new Thickness(10),
                VerticalOptions=LayoutOptions.End,
                FontSize=20
            };
            dismissButton.SetBinding(Button.CommandProperty, nameof(NoXamlDetailPageViewModel.DismissPage));

            Content = new StackLayout
            {
                Margin = new Thickness(20, 20),
                Children = {
                    textLabel,
                    dismissButton
                }
            };
        }
    }
}