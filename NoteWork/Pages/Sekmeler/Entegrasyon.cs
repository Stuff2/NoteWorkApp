using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using NoteWork.Modals;
using NoteWork.Renderer;
using NoteWork.Resx;
using Plugin.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Entegrasyon : ContentPage
    {
       static private long fb = ;
        private string FacebookClientId = fb.ToString();
        private string GoogleClientId = "";
        private string GoogleScope = "https://www.googleapis.com/auth/contacts";
        private string GoogleName = "";


        public Entegrasyon()
        {

            List<Plugin.Contacts.Abstractions.Contact> contacts=new List<Plugin.Contacts.Abstractions.Contact>();
            var o = new int(); Device.OnPlatform(iOS: () => o = 20, Android: () => o = 0);
            Padding = new Thickness(0, o, 0, 0);
            Grid a = new Grid();
            Grid b = new Grid() { BackgroundColor = Color.FromHex("#e6e6e6"), };


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
                Placeholder = AppResource.entegrasyonplaceholder,
                PlaceholderColor = Color.Gray,
                CancelButtonColor = Color.Black
            };
            var agimda = new Image()
            {
                Source = "rehber.png"
            };
            var stats = new Image()
            {
                Source = "face.png"
            };
            var stats2 = new Image()
            {
                Source = "gmail.png"
            };

            var temizle = new Button()
            {
                Text = "Çıkış",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 0, 10, 0),
                BackgroundColor = Color.FromRgb(0,174,179),
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
            var gayagay2 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
            var gayagay3 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.EndAndExpand, HorizontalOptions = LayoutOptions.StartAndExpand };
            gayagay1.IsVisible = true;
            gayagay2.IsVisible = false;
            gayagay3.IsVisible = false;
            temizle.IsVisible = false;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                geri.RotationX = 180;
                await Navigation.PopModalAsync();
            };
            geri.GestureRecognizers.Add(tapGestureRecognizer);

            ListView Liste = new ListView();
            
            if (CrossContacts.Current.RequestPermission().IsCompleted)
            {

                
                CrossContacts.Current.PreferContactAggregation = false;
               
                    if (CrossContacts.Current.Contacts == null)
                        return;

                    contacts = CrossContacts.Current.Contacts.ToList();
                    foreach(var d in contacts)
                    {
                    if (d.FirstName == null)
                        d.FirstName = "";

                    if (d.MiddleName == null)
                        d.MiddleName = "";

                    if (d.LastName == null)
                        d.LastName = "";
                    }

                    contacts = contacts.OrderBy(c => c.FirstName).ToList();
                
                    Liste.ItemsSource = contacts;
                    Liste.ItemTemplate = new DataTemplate(() =>
                    {

                        //var nativeCell = new NativeCell();
                        // nativeCell.SetBinding(NativeCell.NameProperty, "FirstName");
                        // nativeCell.SetBinding(NativeCell.CategoryProperty, "LastName");
                        // nativeCell.ImageFilename = "Agim.png";
                        // //nativeCell.SetBinding(NativeCell.ImageFilenameProperty, "Agim.png");
                        //nativeCell.SetBinding(NativeCell.ImageFilenameProperty, "ImageFilename");
                        Label nameLabel = new Label();
                        Label nameLabel1 = new Label();
                        
                        nameLabel.SetBinding(Label.TextProperty, "FirstName");
                        nameLabel1.SetBinding(Label.TextProperty, "LastName");
                       
                        return new ViewCell {View= new StackLayout
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


               
            }
            
            Liste.ItemSelected += async (s, e) =>

            {

                var x = Liste.SelectedItem as Plugin.Contacts.Abstractions.Contact;
                string no;
                string mail;
                Profile z;

                try
                {

                    no = x.Phones.First().Number;

                }
                catch (Exception exx)
                {
                    no = " ";
                }

                try
                {

                    mail = x.Emails.First().Address;
                }
                catch (Exception ex)
                {

                    mail = " ";
                }
                z = new Profile { FirstName = x.FirstName, LastName = x.LastName, TelNo = no, EMail = mail };
                if (await GirisSayfasi.manager.NoControlAsync(GirisSayfasi.manager.prof, z))
                {
                    await GirisSayfasi.manager.SaveLoginAsync2(z, new Modals.NetWork());
                }
                else
                        await DisplayAlert("Dikkat", "Bu Kişi Ağınızda Bulunmaktadır", "Tamam");

            };
            
            a.Children.Add(agimda, 1, 14);
            Grid.SetColumnSpan(agimda, 18);
            Grid.SetRowSpan(agimda, 18);

            a.Children.Add(stats, 20, 14);
            Grid.SetColumnSpan(stats, 18);
            Grid.SetRowSpan(stats, 18);

            a.Children.Add(stats2, 39, 14);
            Grid.SetColumnSpan(stats2, 18);
            Grid.SetRowSpan(stats2, 18);

            a.Children.Add(gayagay, 0, 29);
            Grid.SetColumnSpan(gayagay, 57);
            Grid.SetRowSpan(gayagay, 2);

            a.Children.Add(gayagay1, 3, 29);
            Grid.SetColumnSpan(gayagay1, 14);
            Grid.SetRowSpan(gayagay1, 2);

            a.Children.Add(gayagay2, 22, 29);
            Grid.SetColumnSpan(gayagay2, 14);
            Grid.SetRowSpan(gayagay2, 2);

            a.Children.Add(gayagay3, 41, 29);
            Grid.SetColumnSpan(gayagay3, 14);
            Grid.SetRowSpan(gayagay3, 2);

            a.Children.Add(SBar, 2, 9);
            Grid.SetColumnSpan(SBar, 53);
            Grid.SetRowSpan(SBar, 8);

            a.Children.Add(Liste, 0, 30);
            Grid.SetColumnSpan(Liste, 57);
            Grid.SetRowSpan(Liste, 83);

            b.Children.Add(temizle, 0, 0);

            b.Children.Add(geri, 0, 0);

            b.Children.Add(Ust, 0, 0);

            a.Children.Add(b, 0, 0);
            Grid.SetColumnSpan(b, 57);
            Grid.SetRowSpan(b, 8);

            a.BackgroundColor = Color.FromHex("#eee");
            
            ListView lv = new ListView();
            ListProfile ax = new ListProfile();
            lv.ItemsSource = ax.datas;
            a.Children.Add(lv, 0, 30);
            Grid.SetColumnSpan(lv, 57);
            Grid.SetRowSpan(lv, 83);
            lv.IsVisible = false;

            List<Profile> lst = new List<Profile>();
            ListView lv2 = new ListView();
            
            a.Children.Add(lv2, 0, 30);
            Grid.SetColumnSpan(lv2, 57);
            Grid.SetRowSpan(lv2, 83);
            lv2.IsVisible = false;

            var webView = new Wrenderer
            {
                HeightRequest = 1
            };
            
            a.Children.Add(webView, 0, 30);
            Grid.SetColumnSpan(webView, 57);
            Grid.SetRowSpan(webView, 83);
            webView.IsVisible = false;

            var webView2 = new Wrenderer
            {
                HeightRequest = 1
            };
            a.Children.Add(webView2, 0, 30);
            Grid.SetColumnSpan(webView2, 57);
            Grid.SetRowSpan(webView2, 83);
            webView2.IsVisible = false;


            //webView.Clears = true; hesaplardan çıkış yap dediğinde kullanılcak
            //webView2.Clears = true;


            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {

                temizle.IsVisible = false;
                gayagay1.IsVisible = true;
                gayagay2.IsVisible = false;
                gayagay3.IsVisible = false;
                Liste.IsVisible = true;
                webView.IsVisible = false;
                lv.IsVisible = false;
                webView2.IsVisible = false;
                lv2.IsVisible = false;
               
                

            };
            agimda.GestureRecognizers.Add(tapGestureRecognizer1);
          
            
            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) => {

                temizle.IsVisible = true;
                gayagay1.IsVisible = false;
                gayagay2.IsVisible = true;
                gayagay3.IsVisible = false;
                Liste.IsVisible = false;
                webView2.IsVisible = false;
                lv2.IsVisible = false;
                

                var apiRequest =
                "https://www.facebook.com/dialog/oauth?client_id="
                + FacebookClientId
                + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

                webView.Source = apiRequest;
                webView.IsVisible = true;
                webView.Navigated += async (s1,e1)=>
                {
                    var accessToken = ExtractAccessTokemFromUrl(e1.Url);

                    if (!String.IsNullOrEmpty(accessToken))
                    {

                        string link = "https://graph.facebook.com/v2.8/me/taggable_friends?fields=first_name,last_name,middle_name,picture&access_token=" + accessToken;

                        ax = new ListProfile() { datas = await GirisSayfasi.manager.Get(link) };


                        // lv.BindingContext = profile;
                        ax.datas = ax.datas.OrderBy(item => item.FirstName).ToList();
                        lv.ItemsSource = ax.datas;
                        lv.ItemTemplate = new DataTemplate(() => {
                            ImageCell im = new ImageCell();
                            im.SetValue(ImageCell.TextColorProperty,Color.Black);
                            im.SetBinding(ImageCell.ImageSourceProperty, "Picture.Data.Url");
                            im.SetBinding(ImageCell.TextProperty, "FirstName");
                            im.SetBinding(ImageCell.DetailProperty, "LastName");
                            return im;
                        });

                        webView.IsVisible = false;
                        webView.Source = "";
                        lv.IsVisible = true;
                        


                    }



                };

               
            };
            stats.GestureRecognizers.Add(tapGestureRecognizer2);

            


           
            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) =>
            {
                temizle.IsVisible = true;
                gayagay1.IsVisible = false;
                gayagay2.IsVisible = false;
                gayagay3.IsVisible = true;
                Liste.IsVisible = false;
                webView.IsVisible = false;
                webView2.IsVisible = true;
                lv.IsVisible = false;
                lv2.IsVisible = false;
                webView2.Source = "https://accounts.google.com/o/oauth2/v2/auth?scope=https://www.googleapis.com/auth/contacts&include_granted_scopes=true&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&client_id=221560077437-n7jvn0m14cu5u0j42c34oskfipo3rml1.apps.googleusercontent.com";

                webView2.Navigated += (s1, e1) =>
                {

                    var accessToken = ExtractAccessTokemFromUrl1(e1.Url);
                    if (!String.IsNullOrEmpty(accessToken))
                    {
                        lst.Clear();
                        webView2.Source = "https://www.googleapis.com/oauth2/v3/tokeninfo?access_token=" + accessToken;

                        RequestSettings a1 = new RequestSettings(GoogleName);
                        a1.OAuth2Parameters = new OAuth2Parameters();
                        a1.OAuth2Parameters.AccessToken = accessToken;
                        a1.OAuth2Parameters.ClientId = GoogleClientId;
                        a1.OAuth2Parameters.Scope = GoogleScope;
                        a1.OAuth2Parameters.RefreshToken = " ";
                        ContactsRequest cr = new ContactsRequest(a1);


                        ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
                        query.NumberToRetrieve = 99999;
                        // query.ShowDeleted = true;

                        //query.StartDate = new DateTime(2008, 1, 1);
                        Feed<Google.Contacts.Contact> feed = cr.Get<Google.Contacts.Contact>(query);
                        foreach (Google.Contacts.Contact entry in feed.Entries)
                        {   
                            if (entry.Emails.Count > 0 || entry.Name.GivenName != null || entry.Name.FamilyName != null)
                            {
                                if (entry.Emails.Count > 0)
                                {
                                    lst.Add(new Profile()
                                    {   
                                        FirstName = entry.Name.GivenName,
                                        LastName = entry.Name.FamilyName,

                                        EMail = entry.Emails[0].Address
                                    });
                                }
                                else
                                {
                                    lst.Add(new Profile()
                                    {
                                        FirstName = entry.Name.GivenName,
                                        LastName = entry.Name.FamilyName,
                                        
                                    });
                                }
                                 
                            }
                        }

                        lst = lst.OrderBy(items => items.FirstName).ToList();
                        lst.OrderByDescending(items => items.FirstName);

                        lv2.ItemsSource = lst;
                        lv2.ItemTemplate = new DataTemplate(() =>
                        {
                            TextCell im = new TextCell();
                            im.SetValue(TextCell.TextColorProperty, Color.Black);
                            im.SetBinding(TextCell.TextProperty, "FirstName");
                            im.SetBinding(TextCell.DetailProperty, "EMail");
                            return im;
                            
                        });

                        webView2.IsVisible = false;
                        webView2.Source = "";
                    
                        lv2.IsVisible = true;




                    }

                };
            };
            stats2.GestureRecognizers.Add(tapGestureRecognizer3);

            

            SBar.TextChanged += (s, e) =>
            {
                if (Liste.IsVisible == true)
                {
                    Liste.BeginRefresh();

                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        Liste.ItemsSource = contacts;
                    else
                        //|| i.LastName.Contains(e.NewTextValue)|| i.MiddleName.Contains(e.NewTextValue)
                        try
                        {

                            Liste.ItemsSource = contacts.Where(i => i.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) || i.LastName.ToLower().Contains(e.NewTextValue.ToLower()) || i.MiddleName.ToLower().Contains(e.NewTextValue.ToLower())).OrderBy(c => c.FirstName).ToList();

                        }
                        catch (Exception ex)
                        {
                            // DisplayAlert("", ex.Message, "ok");

                        }

                    Liste.EndRefresh();
                }

                else if (lv.IsVisible == true)
                {
                    lv.BeginRefresh();

                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        lv.ItemsSource = ax.datas;
                    else
                        //|| i.LastName.Contains(e.NewTextValue)|| i.MiddleName.Contains(e.NewTextValue)
                        try
                        {

                            lv.ItemsSource = ax.datas.Where(i => i.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) || i.LastName.ToLower().Contains(e.NewTextValue.ToLower())).OrderBy(c => c.FirstName).ToList();

                        }
                        catch (Exception ex)
                        {
                            // DisplayAlert("", ex.Message, "ok");

                        }

                    lv.EndRefresh();
                }

                else if (lv2.IsVisible == true)
                {
                    lv2.BeginRefresh();

                    foreach (var d in lst)
                    {
                        if (d.FirstName == null)
                            d.FirstName = "";

                        if (d.EMail == null)
                            d.EMail = "";

                        if (d.LastName == null)
                            d.LastName = "";
                    }

                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        lv2.ItemsSource = lst;
                    else
                        //|| i.LastName.Contains(e.NewTextValue)|| i.MiddleName.Contains(e.NewTextValue)
                        try
                        {

                            lv2.ItemsSource = lst.Where(i => i.FirstName.ToLower().Contains(e.NewTextValue.ToLower()) || i.LastName.ToLower().Contains(e.NewTextValue.ToLower()) || i.EMail.ToLower().Contains(e.NewTextValue.ToLower())).OrderBy(c => c.FirstName).ToList();

                        }
                        catch (Exception ex)
                        {
                            // DisplayAlert("", ex.Message, "ok");

                        }

                    lv2.EndRefresh();
                }


            };

            lv.ItemSelected += async (s, e) =>
            {

                var x = lv.SelectedItem as ListProfile.Datas ;
                string name;
                string lastName;
                string mail;
                Profile z;

                try
                {

                    name = x.FirstName;

                }
                catch (Exception exx)
                {
                    name = " ";
                }

                try
                {

                    lastName = x.LastName;

                }
                catch (Exception exx)
                {
                    lastName = " ";
                }

                z = new Profile { FirstName = name, LastName = lastName };

                    await GirisSayfasi.manager.SaveLoginAsync2(z, new Modals.NetWork());

            };

            lv2.ItemSelected += async (s, e) =>
            {

                var x = lv2.SelectedItem as Profile;
                if (x.FirstName == null && x.LastName == null && x.EMail != null)
                    x.FirstName = x.EMail;
                    
                    await GirisSayfasi.manager.SaveLoginAsync2(x, new Modals.NetWork());

            };

            temizle.Clicked += (s, e) =>
            {
                if (gayagay2.IsVisible == true)
                {
                    webView.Clears = true;
                }
                else if (gayagay3.IsVisible == true)
                {
                    webView2.Clears = true;
                }
            };
            

            SBar.Focus();
            Content = a;

        }
        private string ExtractAccessTokemFromUrl(string uri)
        {
            if (uri.Contains("access_token") && uri.Contains("&expires_in="))
            {
                var http = "https";
                if (Xamarin.Forms.Device.OS == TargetPlatform.Windows || Xamarin.Forms.Device.OS == TargetPlatform.WinPhone)
                    http = "http";
                uri = uri.Replace(http + "://www.facebook.com/connect/login_success.html#access_token=", "");
                var accessToken = uri.Remove(uri.IndexOf("&expires_in="));
                return accessToken;
            }

            return "";
        }

        private string ExtractAccessTokemFromUrl1(string uri)
        {
            if (uri.Contains("access_token") && uri.Contains("&expires_in="))
            {
                var http = "https";
                if (Xamarin.Forms.Device.OS == TargetPlatform.Windows || Xamarin.Forms.Device.OS == TargetPlatform.WinPhone)
                    http = "http";
                uri = uri.Replace(http + "://www.facebook.com/connect/login_success.html#access_token=", "");
                var accessToken = uri.Remove(uri.IndexOf("&token_type="));
                return accessToken;
            }

            return "";
        }


    }
    
   
}
