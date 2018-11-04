using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Profilim : ContentPage
    {
        private bool thebool = true;
        private bool thebool2 = false;
        private bool thebool3 = false;
        private bool thebool4 = false;
        public Profilim()
        {
            this.Icon = "profil.png";
            Grid a = new Grid();
            Grid b = new Grid();
            Grid d = new Grid();
            //ScrollView c = new ScrollView();
        
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

            var AdSoyad = new Button()
            {
                HeightRequest = 50,
                WidthRequest = 50,
                BackgroundColor = Color.FromHex("#1a94d2"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            var adsoyad = new ExtendedListView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = Device.OnPlatform(410, 350, 350)
            };
            adsoyad.Items = new List<EntityClass>()
            {
                new EntityClass()
                {
                  Id =1,
                  Title = "Ad Soyad: " +GirisSayfasi.manager.prof.FirstName+" "+GirisSayfasi.manager.prof.LastName,

                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Şirket:  "+GirisSayfasi.manager.prof.Company,
                },
                new EntityClass()
                {
                    Id =1,
                    Title= "Ünvan:  "+GirisSayfasi.manager.prof.JobTitle,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Şehir:  "+GirisSayfasi.manager.prof.City,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Telefon:  "+GirisSayfasi.manager.prof.TelNo,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "e-mail:  "+GirisSayfasi.manager.prof.EMail,
                }
            };

            var SosyalAg = new Button()
            {
                HeightRequest = 50,
                WidthRequest = 50,
                BackgroundColor = Color.FromHex("#00aeb3"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            var sosyalAg = new ExtendedListView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = Device.OnPlatform(410, 350, 350)
            };
            sosyalAg.Items = new List<EntityClass>()
            {
                new EntityClass()
                {
                  Id =0,
                  Title="Facebook:  "+GirisSayfasi.manager.prof.FaceAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="LinkedIn:  "+GirisSayfasi.manager.prof.LinkedAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Twitter:  "+GirisSayfasi.manager.prof.TwitterAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Instagram:  "+GirisSayfasi.manager.prof.InstaAccount,

                }
            };

            var TBilgi = new Button()
            {
                HeightRequest = 50,
                WidthRequest = 50,
                BackgroundColor = Color.FromHex("#9e9fa2"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            var Temel = new ExtendedListView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = Device.OnPlatform(410, 350, 350)
            };
            Temel.Items = new List<EntityClass>()
            {
                new EntityClass()
                {
                  Id =0,
                  Title=AppResource.profilentitychildclassname10,

                  ChildItems=new List<EntityClass>()
                  {
                      new EntityClass()
                      {
                          Id =1,
                          Title="Ad Soyad:  "+GirisSayfasi.manager.prof.FirstName+" "+GirisSayfasi.manager.prof.LastName,

                      },
                      new EntityClass()
                      {
                          Id =2,
                          Title="Şehir:  "+GirisSayfasi.manager.prof.City
                      },
                      new EntityClass()
                      {
                          Id =3,
                          Title = "Memleket:  "+GirisSayfasi.manager.prof.Hometown
                      },
                      new EntityClass()
                      {
                          Id =4,
                          Title = "Doğum Günü:  "+GirisSayfasi.manager.prof.BirthDate.ToString()
                      }

                  }

                },
                new EntityClass()
                {
                    Id =5,
                    Title=AppResource.profilentitychildclassname11,
                    ChildItems =new List<EntityClass>()
                        {
                            new EntityClass()
                            {
                                Id =6,
                                Title="Telefon:  "+GirisSayfasi.manager.prof.TelNo
                            },
                            new EntityClass()
                            {
                                Id =7,
                                Title="e-mail:  "+GirisSayfasi.manager.prof.EMail
                            },
                            new EntityClass()
                            {
                                Id =8,
                                Title="Ofis Adresi:  "+GirisSayfasi.manager.prof.OfficeAddress
                            },
                            new EntityClass()
                            {
                                Id =9,
                                Title="Asistan İsmi:  "+GirisSayfasi.manager.prof.AssistantName
                            }

                        }

                },
                new EntityClass()
                {
                    Id =10,
                    Title=AppResource.profilentitychildclassname12,
                    ChildItems =new List<EntityClass>()
                        {
                            new EntityClass()
                            {
                                Id =11,
                                Title="Şirket:  "+GirisSayfasi.manager.prof.Company,

                            },
                            new EntityClass()
                            {
                                Id =12,
                                Title="Ünvan:  "+GirisSayfasi.manager.prof.JobTitle
                            },
                            new EntityClass()
                            {
                                Id =13,
                                Title="Önceki Şirketler:  "+GirisSayfasi.manager.prof.PreviousCompanies
                            },
                            new EntityClass()
                            {
                                Id =14,
                                Title="Uzmanlıklar:  "+GirisSayfasi.manager.prof.Profficiencies
                            },
                            new EntityClass()
                            {
                                Id =15,
                                Title="Projeler:  "+GirisSayfasi.manager.prof.Projects
                            },
                            new EntityClass()
                            {
                                Id =16,
                                Title="Sertifikalar:  "+GirisSayfasi.manager.prof.Sertificates
                            },

                        }

            },
                 new EntityClass()
                {
                    Id =17,
                    Title=AppResource.profilentitychildclassname13,
                    ChildItems =new List<EntityClass>()
                        {
                            new EntityClass()
                            {
                                Id =18,
                                Title="Üniversite:  "+GirisSayfasi.manager.prof.Universities,
                            },
                            new EntityClass()
                            {
                                Id =19,
                                Title="Lise:  "+GirisSayfasi.manager.prof.HighSchool
                            }
                        }

            }
            };

            var KisiselBil = new Button()
            {
                HeightRequest = 50,
                WidthRequest = 50,
                BackgroundColor = Device.OnPlatform(Color.FromHex("#c5c2c2"), Color.FromHex("#fff"), Color.FromHex("#fff")),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
            };
            var KisiselBilgi = new ExtendedListView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = Device.OnPlatform(410, 350, 350)
            };
            KisiselBilgi.Items = new List<EntityClass>()
            {
                new EntityClass()
                {
                  Id =0,
                  Title="Eş ve Çocuklar:  "+GirisSayfasi.manager.prof.FamilyMembers,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Ev Adresi:  "+GirisSayfasi.manager.prof.HomeAddress,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Vakıf ve Dernekler:  "+GirisSayfasi.manager.prof.FoundAssociates,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="İlgilenilen Sporlar:"+GirisSayfasi.manager.prof.Sports,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Hobiler:  "+GirisSayfasi.manager.prof.Hobbies,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Facori takım:  "+GirisSayfasi.manager.prof.Team,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Seyehatler:  "+GirisSayfasi.manager.prof.Travels,

                }
            };
            
            for (var i = 0; i < 57; i++)
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (var i = 0; i < 114; i++)
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var img = new Image()
            {
                Source = "doldurbar.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var img1 = new Image()
            {
                Source = "kendiprofil.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand

            };

            var img2 = new Image()
            {
                Source = "profilduzenle.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30

            };

            var lockKey = new Image()
            {
                Source = "lock.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30

            };

            var light = new Image()
            {
                Source = "light.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30
            };

            var book = new Image()
            {
                Source = "book.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30

            };
            
            var sosyalag = new Image()
            {
                Source = "sosyalag.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30

            };

            var bt3 = new StackLayout()
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#eee")
            };

            d.Children.Add(adsoyad, 0, 0);

            /*void OnButtonClicked(object sender, EventArgs e)
            {

                if (thebool == false)
                {
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);
                    if (thebool4 == true)
                        d.Children.Remove(KisiselBilgi);
                    d.Children.Add(adsoyad, 0, 0);
                    

                    

                    thebool = true;
                    thebool2 = false;
                    thebool3 = false;
                    thebool4 = false;

                    gayagay1.IsVisible = true;
                    gayagay2.IsVisible = false;
                    gayagay3.IsVisible = false;
                    gayagay4.IsVisible = false;
                }


            };


            void OnButtonClicked2(object sender, EventArgs e)
            {


                if (thebool2 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);
                    if (thebool4 == true)
                        d.Children.Remove(KisiselBilgi);
                    d.Children.Add(sosyalAg, 0, 0);

                    

                    thebool = false;
                    thebool2 = true;
                    thebool3 = false;
                    thebool4 = false;

                    gayagay1.IsVisible = false;
                    gayagay2.IsVisible = true;
                    gayagay3.IsVisible = false;
                    gayagay4.IsVisible = false;
                }


            };


            void OnButtonClicked3(object sender, EventArgs e){


                if (thebool3 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool4==true)
                    d.Children.Remove(KisiselBilgi);
                    d.Children.Add(Temel, 0, 0);

                    

                    thebool = false;
                    thebool2 = false;
                    thebool3 = true;
                    thebool4 = false;

                    gayagay1.IsVisible = false;
                    gayagay2.IsVisible = false;
                    gayagay3.IsVisible = true;
                    gayagay4.IsVisible = false;
                }


            };


            void OnButtonClicked4(object sender, EventArgs e)
            {

               
                    if (thebool4 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);
                    
                        d.Children.Add(KisiselBilgi, 0, 0);
                        
                        

                        thebool = false;
                        thebool2 = false;
                        thebool3 = false;
                        thebool4 = true;

                        gayagay1.IsVisible = false;
                        gayagay2.IsVisible = false;
                        gayagay3.IsVisible = false;
                        gayagay4.IsVisible = true;
                    }
                

            };*/

            

            a.Children.Add(d, 0, 45);
            Grid.SetColumnSpan(d, 57);
            Grid.SetRowSpan(d, 42);

            a.Children.Add(img, 19, 7);
            Grid.SetColumnSpan(img, 20);
            Grid.SetRowSpan(img, 22);

            a.Children.Add(img1, 22, 10);
            Grid.SetColumnSpan(img1, 14);
            Grid.SetRowSpan(img1, 16);

            a.Children.Add(img2, 47, 3);
            Grid.SetColumnSpan(img2, 8);
            Grid.SetRowSpan(img2, 9);  

            a.Children.Add(AdSoyad, 3, 35);
            Grid.SetColumnSpan(AdSoyad, 8);
            Grid.SetRowSpan(AdSoyad, 8);

            a.Children.Add(book, 3, 35);
            Grid.SetColumnSpan(book, 8);
            Grid.SetRowSpan(book, 8);

            a.Children.Add(SosyalAg, 17, 35);
            Grid.SetColumnSpan(SosyalAg, 8);
            Grid.SetRowSpan(SosyalAg, 8);

            a.Children.Add(sosyalag, 17, 35);
            Grid.SetColumnSpan(sosyalag, 8);
            Grid.SetRowSpan(sosyalag, 8);

            a.Children.Add(TBilgi, 32, 35);
            Grid.SetColumnSpan(TBilgi, 8);
            Grid.SetRowSpan(TBilgi, 8);

            a.Children.Add(light, 32, 35);
            Grid.SetColumnSpan(light, 8);
            Grid.SetRowSpan(light, 8);

            a.Children.Add(KisiselBil, 46, 35);
            Grid.SetColumnSpan(KisiselBil, 8);
            Grid.SetRowSpan(KisiselBil, 8);

            a.Children.Add(lockKey, 46, 35);
            Grid.SetColumnSpan(lockKey, 8);
            Grid.SetRowSpan(lockKey, 8);

            a.Children.Add(b, 0, 44);
            Grid.SetColumnSpan(b, 57);
            Grid.SetRowSpan(b, 2);

            a.Children.Add(bt3, 0, 113);
            Grid.SetColumnSpan(bt3, 57);

            var tapGestureRecognizers = new TapGestureRecognizer();
            tapGestureRecognizers.Tapped += (s, e) => {
                if (thebool == false)
                {
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);
                    if (thebool4 == true)
                        d.Children.Remove(KisiselBilgi);
                    d.Children.Add(adsoyad, 0, 0);




                    thebool = true;
                    thebool2 = false;
                    thebool3 = false;
                    thebool4 = false;

                    gayagay1.IsVisible = true;
                    gayagay2.IsVisible = false;
                    gayagay3.IsVisible = false;
                    gayagay4.IsVisible = false;
                }
            };
            book.GestureRecognizers.Add(tapGestureRecognizers);

            var tapGestureRecognizers1 = new TapGestureRecognizer();
            tapGestureRecognizers1.Tapped += (s, e) => {
                if (thebool2 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);
                    if (thebool4 == true)
                        d.Children.Remove(KisiselBilgi);
                    d.Children.Add(sosyalAg, 0, 0);



                    thebool = false;
                    thebool2 = true;
                    thebool3 = false;
                    thebool4 = false;

                    gayagay1.IsVisible = false;
                    gayagay2.IsVisible = true;
                    gayagay3.IsVisible = false;
                    gayagay4.IsVisible = false;
                }
            };
            sosyalag.GestureRecognizers.Add(tapGestureRecognizers1);

            var tapGestureRecognizers2 = new TapGestureRecognizer();
            tapGestureRecognizers2.Tapped += (s, e) => {
                if (thebool3 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool4 == true)
                        d.Children.Remove(KisiselBilgi);
                    d.Children.Add(Temel, 0, 0);



                    thebool = false;
                    thebool2 = false;
                    thebool3 = true;
                    thebool4 = false;

                    gayagay1.IsVisible = false;
                    gayagay2.IsVisible = false;
                    gayagay3.IsVisible = true;
                    gayagay4.IsVisible = false;
                }
            };
            light.GestureRecognizers.Add(tapGestureRecognizers2);

            var tapGestureRecognizers3 = new TapGestureRecognizer();
            tapGestureRecognizers3.Tapped += (s, e) => {
                if (thebool4 == false)
                {
                    if (thebool == true)
                        d.Children.Remove(adsoyad);
                    if (thebool2 == true)
                        d.Children.Remove(sosyalAg);
                    if (thebool3 == true)
                        d.Children.Remove(Temel);

                    d.Children.Add(KisiselBilgi, 0, 0);



                    thebool = false;
                    thebool2 = false;
                    thebool3 = false;
                    thebool4 = true;

                    gayagay1.IsVisible = false;
                    gayagay2.IsVisible = false;
                    gayagay3.IsVisible = false;
                    gayagay4.IsVisible = true;
                }
            };
            lockKey.GestureRecognizers.Add(tapGestureRecognizers3);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new ProfilDuzenle(GirisSayfasi.manager.prof));
            };
            img2.GestureRecognizers.Add(tapGestureRecognizer);

            Content = a;
        }
    }
}
