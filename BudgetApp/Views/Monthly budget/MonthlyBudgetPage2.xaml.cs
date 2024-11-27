using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace BudgetApp.Views.Monthly_budget
{
    public partial class MonthlyBudgetPage2 : ContentPage
    {
        public MonthlyBudgetPage2()
        {
            InitializeComponent();
        }

        private void OnRetrieveClicked(object sender, EventArgs e)
        {
            // Example: Retrieve the saved TotalIncome value for a specific month and year
            var selectedMonthYear = "November-2024"; // You can modify this to get input from user
            LoadTotalIncome(selectedMonthYear);
        }

        private void LoadTotalIncome(string monthYear)
        {
            // Load the saved TotalIncome value from Preferences
            var savedTotalIncome = Preferences.Get($"TotalIncome_{monthYear}", "Total: $0.00");
            receivedTotalIncomeLabel.Text = savedTotalIncome;
        }
    }
}
