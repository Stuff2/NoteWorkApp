using NoteWork.Resx;
using NoteWork.Store;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NoteWork.Modals;

namespace NoteWork.Pages.Sekmeler
{
    public class BaskasininProfili : ContentPage
    {
        private bool thebool = true;
        private bool thebool2 = false;
        private bool thebool3 = false;
        private bool thebool4 = false;
        
        public BaskasininProfili(NoteWork.Modals.Profile baskaProfil,NetWork nts, bool bool1)
        {
            
            
            this.Icon = "profil.png";
            Grid a = new Grid();
            Grid b = new Grid();
            Grid d = new Grid();

            for (var i = 0; i < 57; i++)
                a.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (var i = 0; i < 113; i++)
            {
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
                a.RowDefinitions.Add(new RowDefinition { Height = new GridLength(6, GridUnitType.Absolute) });

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
            adsoyad.Focus();
            adsoyad.Items = new List<EntityClass>()
            {
                new EntityClass()
                {
                  Id =1,
                  Title = "Ad Soyad: " +baskaProfil.FirstName+" "+baskaProfil.LastName,

                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Şirket:  "+baskaProfil.Company,
                },
                new EntityClass()
                {
                    Id =1,
                    Title= "Ünvan:  "+baskaProfil.JobTitle,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Şehir:  "+baskaProfil.City,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Telefon:  "+baskaProfil.TelNo,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "e-mail:  "+baskaProfil.EMail,
                },
                new EntityClass()
                {
                    Id =1,
                    Title = "Ben ve O",
                    ChildItems=new List<EntityClass>()
                    {
                        new EntityClass()
                        {
                            Id =1,
                            Title="Nerede tanıştınız:  "+ nts.MeetWhere,

                        },
                        new EntityClass()
                        {
                            Id =2,
                            Title="Ne Zaman Tanıştınız:  "+nts.MeetWhen,
                        },
                        new EntityClass()
                        {
                            Id =3,
                            Title = "İlk izlenim:  "+nts.FirstImpression,
                        },
                        new EntityClass()
                        {
                            Id =3,
                            Title = "Ayırt Edici Özellik:  "+nts.Distinctive,
                        },
                        new EntityClass()
                        {
                            Id =4,
                            Title = "Tanışıklık:  "+nts.MeetState
                        },
                        new EntityClass()
                        {
                            Id =5,
                            Title = "Çevre:  "+nts.NetWorks
                        }
                    }
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
                  Title="Facebook:  "+baskaProfil.FaceAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="LinkedIn:  "+baskaProfil.LinkedAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Twitter:  "+baskaProfil.TwitterAccount,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Instagram:  "+baskaProfil.InstaAccount,

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
                          Title="Ad Soyad:  "+baskaProfil.FirstName+" "+baskaProfil.LastName,

                      },
                      new EntityClass()
                      {
                          Id =2,
                          Title="Şehir:  "+baskaProfil.City
                      },
                      new EntityClass()
                      {
                          Id =3,
                          Title = "Memleket:  "+baskaProfil.Hometown
                      },
                      new EntityClass()
                      {
                          Id =4,
                          Title = "Doğum Günü:  "+baskaProfil.BirthDate.ToString()
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
                                Title="Telefon:  "+baskaProfil.TelNo
                            },
                            new EntityClass()
                            {
                                Id =7,
                                Title="e-mail:  "+baskaProfil.EMail
                            },
                            new EntityClass()
                            {
                                Id =8,
                                Title="Ofis Adresi:  "+baskaProfil.OfficeAddress
                            },
                            new EntityClass()
                            {
                                Id =9,
                                Title="Asistan İsmi:  "+baskaProfil.AssistantName
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
                                Title="Şirket:  "+baskaProfil.Company,

                            },
                            new EntityClass()
                            {
                                Id =12,
                                Title="Ünvan:  "+baskaProfil.JobTitle
                            },
                            new EntityClass()
                            {
                                Id =13,
                                Title="Önceki Şirketler:  "+baskaProfil.PreviousCompanies
                            },
                            new EntityClass()
                            {
                                Id =14,
                                Title="Uzmanlıklar:  "+baskaProfil.Profficiencies
                            },
                            new EntityClass()
                            {
                                Id =15,
                                Title="Projeler:  "+baskaProfil.Projects
                            },
                            new EntityClass()
                            {
                                Id =16,
                                Title="Sertifikalar:  "+baskaProfil.Sertificates
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
                                Title="Üniversite:  "+baskaProfil.Universities,
                            },
                            new EntityClass()
                            {
                                Id =19,
                                Title="Lise:  "+baskaProfil.HighSchool
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
                  Title="Eş ve Çocuklar:  "+baskaProfil.FamilyMembers,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Ev Adresi:  "+baskaProfil.HomeAddress,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="Vakıf ve Dernekler:  "+baskaProfil.FoundAssociates,
                },
                new EntityClass()
                {
                    Id =1,
                    Title="İlgilenilen Sporlar:"+baskaProfil.Sports,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Hobiler:  "+baskaProfil.Hobbies,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Facori takım:  "+baskaProfil.Team,

                },
                new EntityClass()
                {
                    Id =1,
                    Title="Seyehatler:  "+baskaProfil.Travels,

                }
            };
            

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

            var img9 = new Image()
            {
                Source = "Ekle.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30

            };

            var img3 = new Image()
            {
                Source = "Sil.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var img4 = new Image()
            {
                Source = "ortakbaglanti.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var img5 = new Image()
            {
                Source = "telarama.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var img6 = new Image()
            {
                Source = "mesajlasma.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var img7 = new Image()
            {
                Source = "geributonu2.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var img8 = new Image()
            {
                Source = "ortakbaglanti.png",
                // HorizontalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var bt3 = new StackLayout()
            {

                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#eee")
            };
            var lockKey = new Image()
            {
                Source = "lock.png",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 30,
                WidthRequest = 30,
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

            d.Children.Add(adsoyad, 0, 0);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {

                var phoneCallTask = MessagingPlugin.PhoneDialer;
                if (phoneCallTask.CanMakePhoneCall && baskaProfil.TelNo != null)
                    phoneCallTask.MakePhoneCall(baskaProfil.TelNo);
            };
            img5.GestureRecognizers.Add(tapGestureRecognizer);

            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) => {
                
                var smsMessenger = MessagingPlugin.SmsMessenger;
                if (smsMessenger.CanSendSms && baskaProfil.TelNo != null)
                    smsMessenger.SendSms(baskaProfil.TelNo, "Say 'Hello' to your friends from NoteWork!");
            };
            img6.GestureRecognizers.Add(tapGestureRecognizer1);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped  += (s, e) => {

                GirisSayfasi.manager.DeleteNetWorkAsync(baskaProfil);
                Navigation.PopModalAsync();
                
            };
            img3.GestureRecognizers.Add(tapGestureRecognizer2);

            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) => {
                
                Navigation.PushModalAsync(new Agim2(baskaProfil));

            };
            img8.GestureRecognizers.Add(tapGestureRecognizer3);

            var tapGestureRecognizerss3 = new TapGestureRecognizer();
            tapGestureRecognizerss3.Tapped += async (s, e) =>
            {
               
                Navigation.PushModalAsync(new Notlar(baskaProfil, nts));

            };
            img4.GestureRecognizers.Add(tapGestureRecognizerss3);

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += (s, e) => {

                img7.RotationX = 180;
                Navigation.PopModalAsync();

            };
            img7.GestureRecognizers.Add(tapGestureRecognizer4);

            a.Children.Add(d, 0, 51);
            Grid.SetColumnSpan(d, 57);
            Grid.SetRowSpan(d, 42);

            a.Children.Add(AdSoyad, 3, 41);
            Grid.SetColumnSpan(AdSoyad, 8);
            Grid.SetRowSpan(AdSoyad, 8);

            a.Children.Add(book, 3, 41);
            Grid.SetColumnSpan(book, 8);
            Grid.SetRowSpan(book, 8);

            a.Children.Add(SosyalAg, 17, 41);
            Grid.SetColumnSpan(SosyalAg, 8);
            Grid.SetRowSpan(SosyalAg, 8);

            a.Children.Add(sosyalag, 17, 41);
            Grid.SetColumnSpan(sosyalag, 8);
            Grid.SetRowSpan(sosyalag, 8);

            a.Children.Add(TBilgi, 32, 41);
            Grid.SetColumnSpan(TBilgi, 8);
            Grid.SetRowSpan(TBilgi, 8);

            a.Children.Add(light, 32, 41);
            Grid.SetColumnSpan(light, 8);
            Grid.SetRowSpan(light, 8);

            a.Children.Add(KisiselBil, 46, 41);
            Grid.SetColumnSpan(KisiselBil, 8);
            Grid.SetRowSpan(KisiselBil, 8);

            a.Children.Add(lockKey, 46, 41);
            Grid.SetColumnSpan(lockKey, 8);
            Grid.SetRowSpan(lockKey, 8);

            a.Children.Add(img, 19, 7);
            Grid.SetColumnSpan(img, 20);
            Grid.SetRowSpan(img, 22);

            a.Children.Add(img1, 22, 10);
            Grid.SetColumnSpan(img1, 14);
            Grid.SetRowSpan(img1, 16);

            a.Children.Add(img2, 47, 3);
            Grid.SetColumnSpan(img2, 7);
            Grid.SetRowSpan(img2, 8);

            a.Children.Add(img3, 47, 25);
            Grid.SetColumnSpan(img3, 7);
            Grid.SetRowSpan(img3, 8);

            a.Children.Add(img4, 3, 25);
            Grid.SetColumnSpan(img4, 7);
            Grid.SetRowSpan(img4, 8);

            a.Children.Add(img5, 19, 33);
            Grid.SetColumnSpan(img5, 7);
            Grid.SetRowSpan(img5, 8);

            a.Children.Add(img6, 32, 33);
            Grid.SetColumnSpan(img6, 7);
            Grid.SetRowSpan(img6, 8);

            a.Children.Add(img7, 3, 3);
            Grid.SetColumnSpan(img7, 7);
            Grid.SetRowSpan(img7, 8);

            a.Children.Add(img8, 3, 14);
            Grid.SetColumnSpan(img8, 7);
            Grid.SetRowSpan(img8, 8);

            a.Children.Add(img9, 47, 3);
            Grid.SetColumnSpan(img9, 7);
            Grid.SetRowSpan(img9, 8);

            a.Children.Add(b, 0, 50);
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

            if (bool1 == true)
            {
                img2.IsVisible = true;
                img9.IsVisible = false;
                
            }
            else if (GirisSayfasi.manager.prof.LID == baskaProfil.LID) 
            {
                img2.IsVisible = false;
                img9.IsVisible = false;

            }
            else
            {
                img2.IsVisible = false;
                img9.IsVisible = true;

            }
            var tapGestureRecognizer5 = new TapGestureRecognizer();
            tapGestureRecognizer5.Tapped += async (s, e) => {

                await Navigation.PushModalAsync(new ProfilDuzenle(baskaProfil));
            };
            img2.GestureRecognizers.Add(tapGestureRecognizer5);

            var tapGestureRecognizer6 = new TapGestureRecognizer();
            tapGestureRecognizer6.Tapped += async (s, e) => {
                await GirisSayfasi.manager.SaveLoginAsync3(baskaProfil, new Modals.NetWork());
                await Navigation.PopModalAsync();
            };
            img9.GestureRecognizers.Add(tapGestureRecognizer6);

            Content = a;
        }

        private void Adsoyad_ChildAdded(object sender, ElementEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
