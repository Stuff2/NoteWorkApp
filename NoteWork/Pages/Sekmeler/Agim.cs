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
    public class Agim : ContentPage
    {
        ListView list = new ListView();

        public Agim()
        {    
            this.Icon = "Agim.png";
            Grid a = new Grid();
            ObservableCollection<Profile> plist = new ObservableCollection<Profile>();
            List<NetWork> k=new List<NetWork>();
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
                Text = "AĞIM",
                TextColor = Color.FromHex("#00aeb3"),
                FontSize = 16,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var agimda = new Image()
            {
                Source = "agimda.png"
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

            a.Children.Add(agimText, 21, 3);
            Grid.SetColumnSpan(agimText, 15);
            Grid.SetRowSpan(agimText, 5);

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
                
                var x = await GirisSayfasi.manager.GetNetWorksAsync(GirisSayfasi.manager.prof);
                plist = x.Item1;
                k = x.Item2;
                if (plist != null)
                {
                    foreach(var z in plist)
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

            list.ItemSelected += async (s, e) =>
            {
                var yeniProfil = e.SelectedItem as NoteWork.Modals.Profile;
                var nets = k.Find(items => items.SPID == yeniProfil.ID);
                var bool1 = await GirisSayfasi.manager.IsNetWork(yeniProfil);
                await Navigation.PushModalAsync(new BaskasininProfili(yeniProfil, nets, bool1));
            };
           
            a.Children.Add(list, 2, 35);
            Grid.SetColumnSpan(list, 53);
            Grid.SetRowSpan(list, 60);

            SBar.Focus();
            SBar.TextChanged += (s, e)=>{


                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    list.ItemsSource = plist;
                else
                    //|| i.LastName.Contains(e.NewTextValue)|| i.MiddleName.Contains(e.NewTextValue)
                    try
                    {
                        string[] slist = e.NewTextValue.Split(' ');
                        List<Profile> prlist = new List<Profile>();
                        for (var z =0;z<slist.Length;z++)
                        { 
                            if (!string.IsNullOrWhiteSpace(slist[z].ToLower())) {

                                //prlist2.AddRange(plist.Where(i => i.FirstName.ToLower().Contains(slist[z].ToLower()) || i.LastName.ToLower().Contains(slist[z].ToLower())).OrderBy(c => c.FirstName).Except(prlist.ToList()).ToList());
                                
                                prlist.AddRange(plist.Where(i => i.FirstName.ToLower().Contains(slist[z].ToLower())
                                    || (i.LastName !=null && i.LastName.ToLower().Contains(slist[z].ToLower()))
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

                                var ld = k.Where(j =>(j.MeetWhen != null && j.MeetWhen.ToLower().Contains(slist[z].ToLower()))
                                    || (j.MeetWhere != null && j.MeetWhere.ToLower().Contains(slist[z].ToLower()))
                                    || (j.MeetState != null && j.MeetState.ToLower().Contains(slist[z].ToLower()))
                                    || (j.NetWorks != null && j.NetWorks.ToLower().Contains(slist[z].ToLower()))
                                    || (j.Distinctive != null && j.Distinctive.ToLower().Contains(slist[z].ToLower()))
                                    || (j.FirstImpression != null && j.FirstImpression.ToLower().Contains(slist[z].ToLower()))).Select(dd => dd.SPID).ToList();

                                foreach (var bb in ld)
                                {
                                    prlist.AddRange(plist.Where(bd => bd.ID == bb).Except(prlist.ToList()).ToList());
                                }
                            }
                        }

                        list.ItemsSource = prlist;

                    }
                    catch (Exception ex)
                    {
                        // DisplayAlert("", ex.Message, "ok");
                    }

            };
            list.BeginRefresh();
            Content = a;
        }

        
    }
}
