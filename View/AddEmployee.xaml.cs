namespace Module02Exercise01.View;
using Module02Exercise01.Model;
using Module02Exercise01.ViewModel;
public partial class AddEmployee : ContentPage
{
	public AddEmployee()
	{
		InitializeComponent();
	}

    private async void OnGetLocationCLicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High
                });
            }
            if (location != null)
            {
                Coordinates.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}";

                //Get Geocoding -Get address from lat and long
                var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);

                var placemark = placemarks?.FirstOrDefault();

                if (placemark != null)
                {
                    Municipality.Text = $"{placemark.SubAdminArea}";
                    Province.Text = $"{placemark.Locality}";
                }
                else
                {
                    Municipality.Text = "Unable to determine the Municipality";
                    Province.Text = "Unable to determine the Province";
                }
            }
            //end of geocoding
            else
            {
                Coordinates.Text = "Unable to get Location";
            }

        }
        catch (Exception ex)
        {
            Coordinates.Text = $"Error: {ex.Message}";
        }
    }
    private async void OnCapturePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //Capture a photo using MediaPicker
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    await LoadPhotoAsync(photo);
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occured: {ex.Message}", "ok");
        }
    }

    private async Task LoadPhotoAsync(FileResult photo)
    {
        if (photo == null)
            return;
        Stream stream = await photo.OpenReadAsync();
        CaptureImage.Source = ImageSource.FromStream(() => stream);
    }

    private async void OnEmployeePageClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
