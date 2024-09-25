namespace Module02Exercise01.View;
using Module02Exercise01.Model;
using Module02Exercise01.ViewModel;
public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewModel();
	}

    private async void OnAddEmployeeButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddEmployee());
    }
}