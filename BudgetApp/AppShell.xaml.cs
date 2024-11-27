namespace BudgetApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("HomePage", typeof(Views.HomePage));
        Routing.RegisterRoute("ControlsPage", typeof(Views.ControlsPage));
        Routing.RegisterRoute("SettingsPage", typeof(Views.SettingsPage));

        // Monthly Buget in Controls
        Routing.RegisterRoute("MonthlyBudgetPage1", typeof(Views.Monthly_budget.MonthlyBudgetPage1)); 
        Routing.RegisterRoute("MonthlyBudgetPage2", typeof(Views.Monthly_budget.MonthlyBudgetPage2));
    }



    
}