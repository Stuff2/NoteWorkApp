using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class TopluDuzenle : ContentPage
    {
        public TopluDuzenle()
        {
            var o = new int(); Device.OnPlatform(iOS: () => o = 20, Android: () => o = 0);
            Padding = new Thickness(0, o, 0, 0);
            Grid a = new Grid();
            Grid b = new Grid();
            Grid c = new Grid() { BackgroundColor = Color.FromHex("#e6e6e6") };

            for (var i = 0; i < 57; i++)
            {
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (var i = 0; i < 114; i++)
            {
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            b.RowDefinitions.Add(new RowDefinition { Height = new GridLength(6, GridUnitType.Absolute) });
            b.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            b.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            b.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            b.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            c.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            c.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var SBar = new SearchBar()
            {
                BackgroundColor = Color.White,
                Placeholder = "Ara",
                PlaceholderColor = Color.Gray,
                CancelButtonColor = Color.Black
            };
            var top1 = new Image()
            {
                Source = "topluduzenle3.png"
            };
            var top2 = new Image()
            {
                Source = "topluduzenle4.png"
            };
            var top3 = new Image()
            {
                Source = "topluduzenle5.png"
            };
            var top4 = new Image()
            {
                Source = "topluduzenle7.png"
            };
            var geri = new Image()
            {
                Source = "geributonu2.png",
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(10, 10, 0, 10),
                HeightRequest = 30,
                WidthRequest = 30
            };

            var Ust = new Image()
            {
                Source = "UstTabLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 10),
                HeightRequest = 30,
                WidthRequest = 30
            };
            ScrollView Liste = new ScrollView()
            {
                BackgroundColor = Color.White
            };
            var gayagay = new Image() { Source = "gaydirganlik.png", VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay1 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay2 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay3 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay4 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
            gayagay1.IsVisible = true;
            gayagay2.IsVisible = false;
            gayagay3.IsVisible = false;
            gayagay4.IsVisible = false;

            b.Children.Add(gayagay, 0, 0);
            Grid.SetColumnSpan(gayagay, 4);
            b.Children.Add(gayagay1, 0, 0);
            b.Children.Add(gayagay2, 1, 0);
            b.Children.Add(gayagay3, 2, 0);
            b.Children.Add(gayagay4, 3, 0);

            c.Children.Add(geri, 0, 0);
            c.Children.Add(Ust, 0, 0);

            a.Children.Add(c, 0, 0);
            Grid.SetColumnSpan(c, 57);
            Grid.SetRowSpan(c, 8);

            a.Children.Add(b, 0, 19);
            Grid.SetColumnSpan(b, 57);
            Grid.SetRowSpan(b, 2);

            a.Children.Add(top1, 5, 10);
            Grid.SetColumnSpan(top1, 8);
            Grid.SetRowSpan(top1, 8);

            a.Children.Add(top2, 18, 10);
            Grid.SetColumnSpan(top2, 8);
            Grid.SetRowSpan(top2, 8);

            a.Children.Add(top3, 31, 10);
            Grid.SetColumnSpan(top3, 8);
            Grid.SetRowSpan(top3, 8);

            a.Children.Add(top4, 44, 10);
            Grid.SetColumnSpan(top4, 8);
            Grid.SetRowSpan(top4, 8);

            a.Children.Add(SBar, 2, 21);
            Grid.SetColumnSpan(SBar, 53);
            Grid.SetRowSpan(SBar, 8);

            a.Children.Add(Liste, 0, 30);
            Grid.SetColumnSpan(Liste, 57);
            Grid.SetRowSpan(Liste, 83);

            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {

                gayagay1.IsVisible = true;
                gayagay2.IsVisible = false;
                gayagay3.IsVisible = false;
                gayagay4.IsVisible = false;
            };
            top1.GestureRecognizers.Add(tapGestureRecognizer1);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) => {

                gayagay1.IsVisible = false;
                gayagay2.IsVisible = true;
                gayagay3.IsVisible = false;
                gayagay4.IsVisible = false;
            };
            top2.GestureRecognizers.Add(tapGestureRecognizer2);
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {

                gayagay1.IsVisible = false;
                gayagay2.IsVisible = false;
                gayagay3.IsVisible = true;
                gayagay4.IsVisible = false;
            };
            top3.GestureRecognizers.Add(tapGestureRecognizer3);

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += (s, e) => {

                gayagay1.IsVisible = false;
                gayagay2.IsVisible = false;
                gayagay3.IsVisible = false;
                gayagay4.IsVisible = true;
            };
            top4.GestureRecognizers.Add(tapGestureRecognizer4);

            var tapGestureRecognizer5 = new TapGestureRecognizer();
            tapGestureRecognizer5.Tapped += async (s, e) => {

                geri.RotationX = 180;
                await Navigation.PopModalAsync();
            };
            geri.GestureRecognizers.Add(tapGestureRecognizer5);

            a.BackgroundColor = Color.FromHex("#eee");




            SBar.Focus();
            Content = a;
        }
    }
}
