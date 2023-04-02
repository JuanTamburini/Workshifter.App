using workshifter.Model;

namespace workshifter.View;

public partial class WorkshiftPage : ContentPage
{
	public WorkshiftPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		Workshift workshift;

		DateTime start = date.Date.Add(startTime.Time);
		DateTime end;
		if (endTime.Time < startTime.Time) // if day changed during work
		{
            end = date.Date.AddDays(1).Add((endTime.Time));            
		}
		else
		{
            end = date.Date.Add(endTime.Time);
        }

		if(!decimal.TryParse(normalPrice.Text, out decimal normalHourlyRate))
		{
			await DisplayAlert("Error", "Precio de hora invalido", "Ok");
			return;
		}
		if(!decimal.TryParse(nightPrice.Text, out decimal nightHourlyRate))
		{
            await DisplayAlert("Error", "Precio de hora nocturna invalido", "Ok");
            return;
        }

		workshift = new(start, end, normalHourlyRate, nightHourlyRate, notes.Text, isHoliday.IsToggled);

		await DisplayAlert("Guardado", $"Fecha: {workshift.StartTime.Date.Date}\n Inicio: {workshift.StartTime}\n Fin: {workshift.EndTime}\n Total horas: {workshift.TotalHours}\n Ganancia: {workshift.TotalEarning:C2}", "Volver");
    }
}