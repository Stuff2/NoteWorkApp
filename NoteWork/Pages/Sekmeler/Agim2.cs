using NoteWork.Modals;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Agim2 : ContentPage
    {
        ListView list = new ListView();

        public Agim2(Profile profs)
        {
            this.Icon = "Agim.png";
            Grid a = new Grid();
            Grid b = new Grid() { BackgroundColor = Color.FromHex("#e6e6e6"), };
            List<NetWork> k = new List<NetWork>();
            ObservableCollection<Profile> plist = new ObservableCollection<Profile>();
            for (var i = 0; i < 57; i++)
            {
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (var i = 0; i < 114; i++)
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var SBar = new SearchBar()
            {
                BackgroundColor = Color.White,
                Placeholder = AppResource.agimplaceholder,
                PlaceholderColor = Color.Gray,
                CancelButtonColor = Color.Black
            };
            var agimText = new Label()
            {
                Text = profs.FirstName+"'s Network",
                TextColor = Color.FromHex("#00aeb3"),
                FontSize = 16,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 0, 10),
                HeightRequest = 30,
                WidthRequest = 30
            };
            var agimda = new Image()
            {
                Source = "agimda.png"
            };
            var geri = new Image()
            {
                Source = "geributonu2.png",
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(10, 10, 0, 10),
                HeightRequest = 30,
                WidthRequest = 30
            };
            ScrollView Liste = new ScrollView()
            {
                BackgroundColor = Color.White
            };

            var gayagay = new Image() { Source = "gaydirganlik.png", VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay1 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.EndAndExpand };
            var gayagay2 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.StartAndExpand };
            gayagay1.IsVisible = true;
            gayagay2.IsVisible = false;
            
            a.Children.Add(agimda, 19, 4);
            Grid.SetColumnSpan(agimda, 18);
            Grid.SetRowSpan(agimda, 18);

            a.Children.Add(gayagay, 0, 19);
            Grid.SetColumnSpan(gayagay, 57);
            Grid.SetRowSpan(gayagay, 2);

            /*a.Children.Add(gayagay1, 22, 19);
            Grid.SetColumnSpan(gayagay1, 14);
            Grid.SetRowSpan(gayagay1, 2);*/

            a.Children.Add(SBar, 2, 21);
            Grid.SetColumnSpan(SBar, 53);
            Grid.SetRowSpan(SBar, 8);

            a.Children.Add(Liste, 0, 30);
            Grid.SetColumnSpan(Liste, 57);
            Grid.SetRowSpan(Liste, 83);

            a.Children.Add(b, 0, 0);
            Grid.SetColumnSpan(b, 57);
            Grid.SetRowSpan(b, 8);

            a.BackgroundColor = Color.FromHex("#eee");

            list.ItemTemplate = new DataTemplate(() =>
            {
                Label nameLabel = new Label();
                Label nameLabel1 = new Label();
                nameLabel.SetBinding(Label.TextProperty, "FirstName");
                nameLabel1.SetBinding(Label.TextProperty, "LastName");


                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                                {

                                        new StackLayout
                                        {
                                            VerticalOptions = LayoutOptions.Center,
                                            Orientation = StackOrientation.Horizontal,
                                            Spacing = 10,
                                            Children =
                                            {
                                                nameLabel,
                                                nameLabel1

                                            }
                                        }
                                }
                    }
                };
            });
            list.IsPullToRefreshEnabled = true;
            list.Refreshing += async (s, e) => {

                var x = await GirisSayfasi.manager.GetNetWorksAsync(profs);
                plist = x.Item1;
                k = x.Item2;
                if (plist != null)
                {
                    foreach (var z in plist)
                    {
                        if (z.FirstName == null)
                            z.FirstName = "";

                        if (z.LastName == null)
                            z.LastName = "";

                    }
                    list.ItemsSource = plist;

                }

                list.EndRefresh();
            };

            list.ItemSelected += async(s, e) =>
            {
                var yeniProfil = list.SelectedItem as NoteWork.Modals.Profile;
                var bool1 = await GirisSayfasi.manager.IsNetWork(yeniProfil);
                var nets = k.Find(item => item.SPID == yeniProfil.ID);
                Navigation.PushModalAsync(new BaskasininProfili(yeniProfil, nets, bool1));
            };

            a.Children.Add(list, 2, 35);
            Grid.SetColumnSpan(list, 53);
            Grid.SetRowSpan(list, 60);

            SBar.Focus();
            SBar.TextChanged += (s, e) => {


                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    list.ItemsSource = plist;
                else
                    //|| i.LastName.Contains(e.NewTextValue)|| i.MiddleName.Contains(e.NewTextValue)
                    try
                    {
                        string[] slist = e.NewTextValue.Split(' ');
                        List<Profile> prlist = new List<Profile>();
                        for (var z = 0; z < slist.Length; z++)
                        {
                            if (!string.IsNullOrWhiteSpace(slist[z].ToLower()))
                            {

                                prlist.AddRange(plist.Where(i => i.FirstName.ToLower().Contains(slist[z].ToLower()) || i.LastName.ToLower().Contains(slist[z].ToLower())).OrderBy(c => c.FirstName).Except(prlist.ToList()).ToList());
                            }
                        };
                        list.ItemsSource = prlist;

                    }
                    catch (Exception ex)
                    {
                        // DisplayAlert("", ex.Message, "ok");
                    }

            };
            list.BeginRefresh();

            b.Children.Add(geri, 0, 0);
            b.Children.Add(agimText, 0, 0);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                geri.RotationX = 180;
                await Navigation.PopModalAsync();
            };
            geri.GestureRecognizers.Add(tapGestureRecognizer);

            Content = a;
        }


    }
}
