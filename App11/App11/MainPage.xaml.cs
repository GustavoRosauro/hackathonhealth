using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App11
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        IProdutos interfaceP = new IProdutos();
        Produto produto = new Produto();
        public MainPage()
        {
            InitializeComponent();
            PreencheLista();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

           
            ////if (placemark != null)
            //{
            //    var geocodeAddress =
            //        $"AdminArea:       {placemark.AdminArea}\n" +
            //        $"CountryCode:     {placemark.CountryCode}\n" +
            //        $"CountryName:     {placemark.CountryName}\n" +
            //        $"FeatureName:     {placemark.FeatureName}\n" +
            //        $"Locality:        {placemark.Locality}\n" +
            //        $"PostalCode:      {placemark.PostalCode}\n" +
            //        $"SubAdminArea:    {placemark.SubAdminArea}\n" +
            //        $"SubLocality:     {placemark.SubLocality}\n" +
            //        $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
            //        $"Thoroughfare:    {placemark.Thoroughfare}\n";
            //}
            try
                {
                double latitude = 0;
                double longitude = 0;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeout: null);
                latitude = position.Latitude;
                longitude = position.Longitude;
                var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);
                var placemark = placemarks?.FirstOrDefault();
                produto.Idade = 60;
                produto.Nome = "Jõao";
                produto.Status = "Pendente";
                produto.Mensagem = "Emergencia !  "+placemark.Locality + " " + placemark.SubLocality + " "+placemark.Thoroughfare+ " "+ placemark.SubThoroughfare;
                await interfaceP.AdicionaProduto(produto);
                PreencheLista();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            }
         async void PreencheLista()
        {
            try
            {
               var lista = await interfaceP.GetProdutosAsync();
                listaProdutos.ItemsSource = lista.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            
            try
            {
                double latitude = 0;
                double longitude = 0;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeout: null);
                latitude = position.Latitude;
                longitude = position.Longitude;
                var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);
                var placemark = placemarks?.FirstOrDefault();
                produto.Idade = 60;
                produto.Nome = "Jõao";
                produto.Status = "Pendente";
                produto.Mensagem = "Urgência !  " + placemark.Locality +  " " + placemark.SubLocality +" "+placemark.Thoroughfare+ " "+ placemark.SubThoroughfare;
                await interfaceP.AdicionaProduto(produto);
                PreencheLista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }

