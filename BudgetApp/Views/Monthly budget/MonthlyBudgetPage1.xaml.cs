using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace BudgetApp.Views.Monthly_budget
{
    public partial class MonthlyBudgetPage1 : ContentPage
    {
        private bool _isFirstFocus; // Track first focus on the Editor
        private string _selectedMonthYear; // Store the selected month and year as key

        public MonthlyBudgetPage1()
        {
            InitializeComponent();
            PopulateMonthPicker(); // Populate the month picker with the last 12 months
            LoadFirstFocusStatus(); // Load the _isFirstFocus status
        }

        // Populate the month picker with the last 12 months
        private void PopulateMonthPicker()
        {
            var months = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                var date = DateTime.Now.AddMonths(-i);
                months.Add(date.ToString("MMMM-yyyy", CultureInfo.InvariantCulture));
            }
            MonthPicker.ItemsSource = months;
            MonthPicker.SelectedIndex = 0; // Default to the current month
        }

        // Event triggered when a month is selected from the picker
        private void OnMonthSelected(object sender, EventArgs e)
        {
            _selectedMonthYear = MonthPicker.SelectedItem.ToString();
            LoadTotalIncome(_selectedMonthYear);
            LoadTextBoxContent(_selectedMonthYear);
        }

        // Load the saved TotalIncome value from Preferences
        private void LoadTotalIncome(string monthYear)
        {
            var savedTotalIncome = Preferences.Get($"TotalIncome_{monthYear}", "Total: $0.00");
            TotalIncome.Text = savedTotalIncome;
        }

        // Save the TotalIncome value to Preferences
        private void SaveTotalIncome(string monthYear, string totalIncome)
        {
            Preferences.Set($"TotalIncome_{monthYear}", totalIncome);
        }

        // Load the saved text box content from Preferences
        private void LoadTextBoxContent(string monthYear)
        {
            var savedTextContent = Preferences.Get($"TextBoxContent_{monthYear}", string.Empty);
            MultiLineInput.Text = savedTextContent;
        }

        // Save the text box content to Preferences
        private void SaveTextBoxContent(string monthYear, string textContent)
        {
            Preferences.Set($"TextBoxContent_{monthYear}", textContent);
        }

        // Load the _isFirstFocus status from Preferences
        private void LoadFirstFocusStatus()
        {
            _isFirstFocus = Preferences.Get("IsFirstFocus", true); // Default to true if not found
        }

        // Save the _isFirstFocus status to Preferences
        private void SaveFirstFocusStatus()
        {
            Preferences.Set("IsFirstFocus", _isFirstFocus);
        }

        private void EditerLayoutTapped(object sender, EventArgs e)
        {
            // Check if the editor is currently focused
            if (MultiLineInput.IsFocused)
            {
                // Unfocus the editor, which will close the keyboard
                MultiLineInput.Unfocus();
            }
        }

        // Event triggered when the background is tapped
        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            // Dismiss the keyboard by unfocusing the Editor
            MultiLineInput.Unfocus();
        }

        // Event triggered when the text changes in the Editor
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Split the text into lines
                string[] lines = MultiLineInput.Text?.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                double total = 0;

                // Calculate the total of the entered numbers
                if (lines != null)
                {
                    foreach (var line in lines)
                    {
                        if (double.TryParse(line.Trim(), out double number))
                        {
                            total += number;
                        }
                    }
                }

                // Update the total display and save it
                string totalIncomeText = $"Total: ${total}";
                TotalIncome.Text = totalIncomeText;
                SaveTotalIncome(_selectedMonthYear, totalIncomeText);

                // Save the text box content
                SaveTextBoxContent(_selectedMonthYear, MultiLineInput.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total: {ex.Message}");
            }
        }

        // Event triggered when the Editor gains focus
        private void OnEditorFocused(object sender, FocusEventArgs e)
        {
            // Clear the Editor text on first focus
            if (_isFirstFocus)
            {
                MultiLineInput.Text = string.Empty;
                _isFirstFocus = false;
                SaveFirstFocusStatus(); // Save the updated status
            }
        }

        // Event triggered when the Continue button is clicked
        private async void OnContinueClicked(object sender, EventArgs e)
        {
            // Display alert if the income is not entered
            if (_isFirstFocus)
            {
                await DisplayAlert("Please Enter Income", "It seems like you have not entered your income.", "OK");
            }
            else
            {
                // Dismiss the keyboard by unfocusing all inputs
                
                await Task.Delay(100); // Ensure the unfocus happens before navigation

                // Save the text box content
                SaveTextBoxContent(_selectedMonthYear, MultiLineInput.Text);

                // Navigate to the next page
                await Shell.Current.GoToAsync("MonthlyBudgetPage2");
            }
        }
    }
}
