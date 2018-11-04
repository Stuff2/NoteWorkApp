using Microsoft.CSharp.RuntimeBinder;
using System;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Anasayfa : ContentPage
    {
        public Anasayfa()
        {
          


                Icon = "Anasayfa.png";

            var count = new int(); count = 0;
            Grid a = new Grid() { BackgroundColor = Color.FromHex("#fff"), Margin = new Thickness(0,0,0,-10) };
            StackLayout b = new StackLayout(){ BackgroundColor = Color.FromHex("#fff")};



            for (var i = 0; i < 57; i++)
            { 
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (var i = 0; i < 113; i++)
            {
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            a.RowDefinitions.Add(new RowDefinition
            {
                Height = new GridLength(6, GridUnitType.Absolute),
                
            });




            var SBarImg = new Image()
            {
                Source = "arama.png"
            };
            var bt1 = new Image()
            {
                Source = "Ekle.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var bt2 = new Image()
            {
                Source = "duzenle.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand 
            };
            var bt4 = new Image()
            {
                Source = "kisiolustur.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var bt5 = new Image()
            {
                Source = "entegret.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var img = new Image()
            {
                Source = "OrtaLogo.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
                
            };
            var bt3 = new StackLayout()
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#eee")
            };
          

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new Arama());
            };
            SBarImg.GestureRecognizers.Add(tapGestureRecognizer);

            
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) =>
            {
                if (count % 2 == 0)
                {
                    count++;
                    a.Children.Add(bt4, 18, 68);
                    a.Children.Add(bt5, 7, 68);

                    Grid.SetColumnSpan(bt4, 12);
                    Grid.SetRowSpan(bt4, 13);

                    Grid.SetColumnSpan(bt5, 12);
                    Grid.SetRowSpan(bt5, 13);
                    }
                else
                {
                    count++;
                    a.Children.Remove(bt4);
                    a.Children.Remove(bt5);
                }
            };
            bt1.GestureRecognizers.Add(tapGestureRecognizer2);

            var tapGestureRecognizer5 = new TapGestureRecognizer();
            tapGestureRecognizer5.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new TopluDuzenle());
            };
            bt2.GestureRecognizers.Add(tapGestureRecognizer5);

            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new Kisiekle());
            };
            bt4.GestureRecognizers.Add(tapGestureRecognizer3);

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new Entegrasyon());
            };
            bt5.GestureRecognizers.Add(tapGestureRecognizer4);
            
            a.Children.Add(img, 16, 18);
            Grid.SetColumnSpan(img, 24);
            Grid.SetRowSpan(img, 16);

            a.Children.Add(SBarImg, 2, 43);
            Grid.SetColumnSpan(SBarImg, 53);
            Grid.SetRowSpan(SBarImg, 8);
          
            a.Children.Add(bt1, 14, 58);
            Grid.SetColumnSpan(bt1, 9);
            Grid.SetRowSpan(bt1, 10);

            a.Children.Add(bt2, 33, 58);
            Grid.SetColumnSpan(bt2, 9);
            Grid.SetRowSpan(bt2, 10);

            a.Children.Add(bt3, 0, 113);
            Grid.SetColumnSpan(bt3, 57);
            
            Content = a;

        }
    }
}