using FlorApp.Mobile.ViewModels;

namespace FlorApp.Mobile.Views;

public partial class ProductosPage : ContentPage
{
    public ProductosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = (ProductosViewModel)this.BindingContext;
        await viewModel.CargarProductosAsync();
    }
}