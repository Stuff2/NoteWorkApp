using NoteWork.Renderer;
using NoteWork.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class sikayet : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        public sikayet()
        {
            {

                var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
                var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, 40, 0, 0) };
                var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
                grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });

                stack.Children.Add(stack2);

                var ceditor = new CEditor
                {
                    BackgroundColor = Color.FromHex("#eee"),
                    Margin = new Thickness(15, 0, 15, 0),
                    Keyboard = Keyboard.Email,
                    HeightRequest = 200,
                    WidthRequest = 200
                };

                stack2.Children.Add(new Label
                {
                    Text = "Sorun Bildir / Soru Sor / Öneri sun",

                    Margin = new Thickness(20, 20, 0, 0)
                });
                stack2.Children.Add(ceditor);
                

                var butonumuz = new Image()
                {
                    Source = "gonder111.png",
                    Margin = new Thickness(0, 0, 15, 0),

                };
                var iptal = new Button()
                {
                    Text = AppResource.iptalbuton,
                    BackgroundColor = Color.Transparent,
                    TextColor = Color.Black
                };
                
				iptal.Clicked += OnButtonClicked4;

                
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) => {

                    using (HttpClient client = new HttpClient())
                    {
                        var dens = new MultipartFormDataContent();
                        dens.Add(new StringContent(GirisSayfasi.manager.prof.FirstName+" "+ GirisSayfasi.manager.prof.LastName), "name");
                        dens.Add(new StringContent(GirisSayfasi.manager.login.Mail), "email");
                        dens.Add(new StringContent(ceditor.Text), "message");
                        //string json = JsonConvert.SerializeObject(new Student() { Name="dede1"});

                        var response = await client.PostAsync("", dens);
                        response.EnsureSuccessStatusCode();
                        await DisplayAlert("Bilgi","Mesajınız yollandı","Tamam");
                        Navigation.PopModalAsync();
                    }
                };
                butonumuz.GestureRecognizers.Add(tapGestureRecognizer);


                grida.Children.Add(butonumuz, 1, 0);
                grida.Children.Add(iptal, 0, 0);

                var a = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
                var b = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
                b.Children.Add(a);
                b.Children.Add(grida);

                Content = b;

            }
        }
    }
}
