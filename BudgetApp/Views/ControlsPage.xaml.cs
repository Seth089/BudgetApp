using Microsoft.Maui.Controls;

namespace BudgetApp.Views;

public partial class ControlsPage : ContentPage
{
    public ControlsPage()
    {
        InitializeComponent();

    }

    // Body //
    private async void NavigateToMonthlyBudgetPage1Button_Clicked(object sender, EventArgs e)
    {
        //Navigate to MonthlyBudgetPage1
        await Shell.Current.GoToAsync("MonthlyBudgetPage1");

    }






    // Footer //

    private async void OnNavHomeButton(object sender, EventArgs e)
    {
        // Navigate to HomePage 
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