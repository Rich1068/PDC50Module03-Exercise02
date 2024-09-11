namespace Module02Exercise01.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Module02Exercise01.Services;

public partial class OfflinePage : ContentPage
{
    private readonly IMyService _myService; //Field for the service
    public OfflinePage(IMyService myService)
    {
        InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel.Text = message;
    }
}