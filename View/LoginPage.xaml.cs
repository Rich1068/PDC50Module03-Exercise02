using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Module02Exercise01.Services;

namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly IMyService _myService; //Field for the service
        public LoginPage(IMyService myService)
        {
            InitializeComponent();
            _myService = myService;

            var message = _myService.GetMessage();
            MyLabel.Text = message;
        }


        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "admin")
            {
                try
                {
                    await Shell.Current.GoToAsync("//EmployeePage");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
                
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password. The username and password is admin admin", "OK");
            }
        }
    }
}
