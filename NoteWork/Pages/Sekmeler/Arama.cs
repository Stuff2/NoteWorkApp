using NoteWork.Modals;
using NoteWork.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Arama : ContentPage
    {
        ListView list = new ListView();
        ListView list2 = new ListView();

        public Arama()
        {
            var o = new int(); Device.OnPlatform(iOS: () => o = 20, Android: () => o = 0);
            Padding = new Thickness(0, o, 0, 0);
            Grid a = new Grid();
            Grid b = new Grid() { BackgroundColor = Color.FromHex("#e6e6e6"),  };
            ObservableCollection<Profile> plist = new ObservableCollection<Profile>();
            ObservableCollection<Profile> plist2 = new ObservableCollection<Profile>();
            List<NetWork> k = new List<NetWork>();

            for (var i = 0; i < 57; i++)
            {
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (var i = 0; i < 114; i++)
            {
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
                b.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                b.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            var SBar = new SearchBar()
            {
                BackgroundColor = Color.White,
                Placeholder = AppResource.agimplaceholder,
                PlaceholderColor = Color.Gray,
                CancelButtonColor = Color.Black
            };
            var agimda = new Image()
            {
                Source = "agimda.png"
            };
            var stats = new Image()
            {
                Source = "world.png"
            };
            ScrollView Liste = new ScrollView()
            {
                BackgroundColor = Color.White
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

            var gayagay = new Image() { Source = "gaydirganlik.png", VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay1 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.EndAndExpand };
            var gayagay2 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.StartAndExpand };
            gayagay1.IsVisible = true;
            gayagay2.IsVisible = false;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                geri.RotationX = 180;
                await Navigation.PopModalAsync();
            };
            geri.GestureRecognizers.Add(tapGestureRecognizer);

            a.Children.Add(agimda, 10, 14);
            Grid.SetColumnSpan(agimda, 18);
            Grid.SetRowSpan(agimda, 18);

            a.Children.Add(stats, 28, 14);
            Grid.SetColumnSpan(stats, 18);
            Grid.SetRowSpan(stats, 18);

            a.Children.Add(gayagay, 0, 29);
            Grid.SetColumnSpan(gayagay, 57);
            Grid.SetRowSpan(gayagay, 2);

            a.Children.Add(gayagay1, 12, 29);
            Grid.SetColumnSpan(gayagay1, 14);
            Grid.SetRowSpan(gayagay1, 2);

            a.Children.Add(gayagay2, 30, 29);
            Grid.SetColumnSpan(gayagay2, 14);
            Grid.SetRowSpan(gayagay2, 2);

            a.Children.Add(SBar, 2, 9);
            Grid.SetColumnSpan(SBar, 53);
            Grid.SetRowSpan(SBar, 8);

            a.Children.Add(Liste, 0, 30);
            Grid.SetColumnSpan(Liste, 57);
            Grid.SetRowSpan(Liste, 83);

            b.Children.Add(geri, 0, 0);

            b.Children.Add(Ust, 0, 0);

            a.Children.Add(b, 0, 0);
            Grid.SetColumnSpan(b, 57);
            Grid.SetRowSpan(b, 8);

            a.BackgroundColor = Color.FromHex("#eee");

            //ağım listesi
            list2.ItemTemplate = new DataTemplate(() =>
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
            list2.IsPullToRefreshEnabled = true;
            list2.Refreshing += async (s, e) => {

                 var x = await GirisSayfasi.manager.GetNetWorksAsync(GirisSayfasi.manager.prof);
                plist2 = x.Item1;
                k = x.Item2;
                if (plist2 != null)
                {
                    foreach(var z in plist2)
                    {
                        if (z.FirstName == null)
                            z.FirstName = "";

                        if (z.LastName == null)
                            z.LastName = "";

                    }   
                    list2.ItemsSource = plist2;
                    
                }

                list2.EndRefresh();
            };

            list2.ItemSelected += async(s, e) => 
            {
                var yeniProfil = list2.SelectedItem as NoteWork.Modals.Profile;
                var nets = k.Find(items => items.FPID == GirisSayfasi.manager.prof.ID && items.SPID == yeniProfil.ID);
                var bool1 = await GirisSayfasi.manager.IsNetWork(yeniProfil);
                Navigation.PushModalAsync(new BaskasininProfili(yeniProfil, nets, bool1));
            };

            a.Children.Add(list2, 2, 35);
            Grid.SetColumnSpan(list2, 53);
            Grid.SetRowSpan(list2, 60);
            //ağım listesi sonu


            //dünya listesi
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

            
                list.Refreshing += async (s, e) =>
                {
                    plist = await GirisSayfasi.manager.GetProfileAsync();

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

            var bos = new NetWork()
            {
                ID = "",
                SPID = "",
                FPID = "",
                Distinctive = "",
                FirstImpression = "",
                MeetState = "",
                MeetWhen = "",
                MeetWhere = "",
                NetWorks = "",
                
            };
            
            list.ItemSelected += async(s, e) =>
            {
                var yeniProfil = list.SelectedItem as NoteWork.Modals.Profile;
                var nets = bos;
                var bool1 = await GirisSayfasi.manager.IsNetWork(yeniProfil);
                await Navigation.PushModalAsync(new BaskasininProfili(yeniProfil, nets, bool1));
            };

            a.Children.Add(list, 2, 35);
            Grid.SetColumnSpan(list, 53);
            Grid.SetRowSpan(list, 60);
            //dünya listesi sonu

            list.IsVisible = false;
            list2.IsVisible = true;
            
            //butonlar
            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                gayagay1.IsVisible = true;
                gayagay2.IsVisible = false;
                list.IsVisible = false;
                list2.IsVisible = true;
            };
            agimda.GestureRecognizers.Add(tapGestureRecognizer1);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) => {
                gayagay1.IsVisible = false;
                gayagay2.IsVisible = true;
                list.IsVisible = true;
                list2.IsVisible = false;
            };
            stats.GestureRecognizers.Add(tapGestureRecognizer2);
            //butonların sonu


            SBar.Focus();
            SBar.TextChanged += (s, e) => {

                if (list.IsVisible == true)
                {
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
                }

                if (list2.IsVisible == true)
                {
                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        list2.ItemsSource = plist2;
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

                                prlist.AddRange(plist2.Where(i => i.FirstName.ToLower().Contains(slist[z].ToLower())
                                    || (i.LastName != null && i.LastName.ToLower().Contains(slist[z].ToLower()))
                                    || (i.AssistantName != null && i.AssistantName.ToLower().Contains(slist[z].ToLower()))
                                    || (i.City != null && i.City.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Company != null && i.Company.ToLower().Contains(slist[z].ToLower()))
                                    || (i.EMail != null && i.EMail.ToLower().Contains(slist[z].ToLower()))
                                    || (i.HighSchool != null && i.HighSchool.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Hobbies != null && i.Hobbies.ToLower().Contains(slist[z].ToLower()))
                                    || (i.HomeAddress != null && i.HomeAddress.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Hometown != null && i.Hometown.ToLower().Contains(slist[z].ToLower()))
                                    || (i.JobState != null && i.JobState.ToLower().Contains(slist[z].ToLower()))
                                    || (i.JobTitle != null && i.JobTitle.ToLower().Contains(slist[z].ToLower()))
                                    || (i.OfficeAddress != null && i.OfficeAddress.ToLower().Contains(slist[z].ToLower()))
                                    || (i.PreviousCompanies != null && i.PreviousCompanies.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Profficiencies != null && i.Profficiencies.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Projects != null && i.Projects.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Sertificates != null && i.Sertificates.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Sports != null && i.Sports.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Team != null && i.Team.ToLower().Contains(slist[z].ToLower()))
                                    || (i.TelNo != null && i.TelNo.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Travels != null && i.Travels.ToLower().Contains(slist[z].ToLower()))
                                    || (i.Universities != null && i.Universities.ToLower().Contains(slist[z].ToLower()))
                                    ).OrderBy(c => c.FirstName).Except(prlist.ToList()).ToList());

                                var ld = k.Where(j => (j.MeetWhen != null && j.MeetWhen.ToLower().Contains(slist[z].ToLower()))
                                    || (j.MeetWhere != null && j.MeetWhere.ToLower().Contains(slist[z].ToLower()))
                                    || (j.MeetState != null && j.MeetState.ToLower().Contains(slist[z].ToLower()))
                                    || (j.NetWorks != null && j.NetWorks.ToLower().Contains(slist[z].ToLower()))
                                    || (j.Distinctive != null && j.Distinctive.ToLower().Contains(slist[z].ToLower()))
                                    || (j.FirstImpression != null && j.FirstImpression.ToLower().Contains(slist[z].ToLower()))).Select(dd => dd.SPID).ToList();

                                    foreach (var bb in ld)
                                    {
                                        prlist.AddRange(plist2.Where(bd => bd.ID == bb).Except(prlist.ToList()).ToList());

                                    }
                                }
                            };
                            list2.ItemsSource = prlist;
                        }
                        catch (Exception ex)
                        {
                            // DisplayAlert("", ex.Message, "ok");
                        }
                }
            };
            list.BeginRefresh();
            list2.BeginRefresh();
            Content = a;

        }
    }
}
