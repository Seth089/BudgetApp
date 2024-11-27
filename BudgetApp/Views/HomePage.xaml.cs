namespace BudgetApp.Views;
using Microsoft.Maui.Controls;
using System.ComponentModel;

public partial class HomePage : ContentPage
{
    private string _totalBudget = "$0.00"; 
    private string _totalExpenses = "$0.00"; 
    private string _remainingBalance = "$0.00"; 
    
    public HomePage() 
    { 
        InitializeComponent(); 
        BindingContext = this; 
    }

    public string TotalBudget 
    { 
        get => _totalBudget; 
        set { _totalBudget = value; OnPropertyChanged(nameof(TotalBudget)); } 
    }

    public string TotalExpenses 
    { 
        get => _totalExpenses; 
        set { _totalExpenses = value; OnPropertyChanged(nameof(TotalExpenses)); } 
    }

    public string RemainingBalance 
    { 
        get => _remainingBalance; 
        set { _remainingBalance = value; OnPropertyChanged(nameof(RemainingBalance)); } 
    }
    public event PropertyChangedEventHandler PropertyChanged; 
    protected void OnPropertyChanged(string propertyName) => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));













    // Footer //
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