using Microsoft.Maui.Controls;

namespace BudgetApp.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            // Set the initial state of the switch based on the current theme
            DarkModeSwitch.IsToggled = Application.Current.RequestedTheme == AppTheme.Dark;
        }

        private void OnDarkModeToggled(object sender, ToggledEventArgs e)
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
        }
    }
}