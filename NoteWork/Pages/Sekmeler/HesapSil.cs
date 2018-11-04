using NoteWork.Renderer;
using NoteWork.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class HesapSil : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        public HesapSil()
        {
            {

                var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
                var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, 40, 0, 0) };
                var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
                grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });

                stack.Children.Add(stack2);

                var sifreText = new CEntry
                {
                    BackgroundColor = Color.FromHex("#eee"),
                    IsPassword = true,
                    Margin = new Thickness(15, 0, 15, 0)
                };

                stack2.Children.Add(new Label
                {
                    Text = AppResource.hesapsillabel2,

                    Margin = new Thickness(20, 20, 0, 0)
                });
                stack2.Children.Add(sifreText);



                var butonumuz = new Image()
                {
                    Source = "hesabimisil111.png",
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
                    if (sifreText.Text == GirisSayfasi.manager.login.Password)
                    {
                        GirisSayfasi.manager.DeleteProfilAsync();
                        await DisplayAlert("Dikkat", "Hesabınızı Sildiniz", "Tamam");
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        await DisplayAlert("Dikkat", "Yanlış Email Şifre Kombinasyonu", "Tamam");
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
