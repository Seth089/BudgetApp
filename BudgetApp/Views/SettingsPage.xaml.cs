using Microsoft.Maui.Controls;

namespace BudgetApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            // Set the initial state of the switch based on the current theme
/*            DarkModeSwitch.IsToggled = Application.Current.RequestedTheme == AppTheme.Dark;
*/        }

        /*private void OnDarkModeToggled(object sender, ToggledEventArgs e)
        {
            var mergedDict = Application.Current.Resources;

            if (e.Value)
            {
                // Dark Theme
                mergedDict["BackgroundColor"] = mergedDict["DarkBackgroundColor"];
                mergedDict["TextColor"] = mergedDict["DarkTextColor"];
            }
            else
            {
                // Light Theme
                mergedDict["BackgroundColor"] = mergedDict["LightBackgroundColor"];
                mergedDict["TextColor"] = mergedDict["LightTextColor"];
            }
        }*/



        private async void OnNavHomeButton(object sender, EventArgs e)
        {
            // Navigate to HomePage (already the current page)
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnNavControlsButton(object sender, EventArgs e)
        {
            // Navigate to ControlsPage
            await Shell.Current.GoToAsync("//ControlsPage");
        }

        private async void OnNavSettingsButton(object sender, EventArgs e)
        {
            // Navigate to SettingsPage
            await Shell.Current.GoToAsync("//SettingsPage");
        }
    }

}