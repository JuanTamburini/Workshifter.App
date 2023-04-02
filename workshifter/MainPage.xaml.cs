using System.Collections.ObjectModel;
using workshifter.Data;
using workshifter.Model;

namespace workshifter;

public partial class MainPage : ContentPage
{
    WorkshiftDatabase database;
    public ObservableCollection<Workshift> Items { get; set; } = new();
    public MainPage(WorkshiftDatabase workshiftDatabase)
	{
		InitializeComponent();

		database = workshiftDatabase;
		BindingContext = this;

        Appearing += async (s, e) => await UpdateCollectionView();
    }

	private async void OnCreateItemClicked(object sender, EventArgs e)
	{
        await database.SaveItemAsync(new Workshift());
        await UpdateCollectionView();
    }

	private async Task UpdateCollectionView()
	{
        var items = await database.GetItemsAsync();

        Items.Clear();
        foreach (var item in items)
            Items.Add(item);
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        foreach(var item in Items)
            await database.DeleteItemAsync(item);

        await UpdateCollectionView();
    }
}

