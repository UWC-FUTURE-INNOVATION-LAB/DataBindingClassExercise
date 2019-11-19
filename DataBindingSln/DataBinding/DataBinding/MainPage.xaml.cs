using DataBinding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataBinding
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            var latestProduct = BindingContext as Product;

            App.Database.UpdateProduct(latestProduct);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            PopulateLatestProduct();

        //    GetSavedItem();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var latestProduct = BindingContext as Product;

            App.Database.DeleteProduct(latestProduct);

            PopulateLatestProduct();
        }

        private async void PopulateLatestProduct()
        {
            var latestProduct = await App.Database.GetLatestProduct();

            BindingContext = latestProduct;
        }
    }
}
