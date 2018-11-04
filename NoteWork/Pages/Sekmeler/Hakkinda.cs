using NoteWork.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Hakkinda : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        public Hakkinda()
        {
            var stack = new StackLayout()
            {
                BackgroundColor = Color.FromHex("#eee")
            };

            var webView = new Wrenderer
            {
                HeightRequest = 500
            };

            webView.Source = "";


            var baslik = new Label()
            {
                Text = "\n Sizi sitemize yönlendirelim",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#31b196"),
                FontSize = 25,
                FontAttributes = FontAttributes.Italic,

            };

            var iptal = new Button()
            {
                Text = "Geri",
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#1a94d2"),
                WidthRequest = Device.OnPlatform(100, 100, 0)
            };

            iptal.Clicked += OnButtonClicked4;


            stack.Children.Add(baslik);
            stack.Children.Add(webView);
            stack.Children.Add(iptal);

            Content = stack;
        }
    }
}
