using NoteWork.Modals;
using NoteWork.Renderer;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace NoteWork.Pages.Sekmeler
{
    public class ProfilDuzenle2 : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
        public ProfilDuzenle2(NoteWork.Modals.Profile biProfil2 ,string ad, string soyad, string sehir, string unvan, string sirket, string mail, string numara, string memleket, string dogumgünü, string ofisadres, string asistan, string universite)
        {
            var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, -6, 0, 0) };
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });



            stack.Children.Add(new Label
            {
                Text = "Kişisel Bilgilerinizi Buradan Düzenleyebilirsiniz",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(0, 20, 0, 0),
                HeightRequest = 40,
            });
            stack.Children.Add(stack2);
            stack2.Children.Add(new Label
            {
                Text = "LinkedIn Account",

                Margin = new Thickness(20, 20, 0, 0)
            });
            var linkedInAcc = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.LinkedAccount
            };
            stack2.Children.Add(linkedInAcc);
            stack2.Children.Add(new Label
            {
                Text = "Facebook Account",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var faceAcc = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.FaceAccount
            };
            stack2.Children.Add(faceAcc);
            stack2.Children.Add(new Label
            {
                Text = "Twitter Account",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var twitAcc = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.TwitterAccount
            };
            stack2.Children.Add(twitAcc);
            stack2.Children.Add(new Label
            {
                Text = "Instagram Account",

                Margin = new Thickness(20, 20, 0, 0)
            });
            var instAcc = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.InstaAccount
            };
            stack2.Children.Add(instAcc);
            stack2.Children.Add(new Label
            {
                Text = "Eş ve Çocukların İsimleri",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var famMem = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.FamilyMembers
            };
            stack2.Children.Add(famMem);
            stack2.Children.Add(new Label
            {
                Text = "Ev Adresi",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var homeAdd = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.HomeAddress
            };
            stack2.Children.Add(homeAdd);
            stack2.Children.Add(new Label
            {
                Text = "Üye Olunan Dernek ve Vakıflar",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var foundAssc = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.FoundAssociates
            };
            stack2.Children.Add(foundAssc);
            stack2.Children.Add(new Label
            {
                Text = "İlgilenilen Sporlar",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var sport = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.Sports
            };
            stack2.Children.Add(sport);
            stack2.Children.Add(new Label
            {
                Text = "Hobiler",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var hobby = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.Hobbies
            };
            stack2.Children.Add(hobby);
            stack2.Children.Add(new Label
            {
                Text = "Tutulan Takım",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var team = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.Team
            };
            stack2.Children.Add(team);
            stack2.Children.Add(new Label
            {
                Text = "Seyehatler",
                Margin = new Thickness(20, 20, 0, 0)
            });
            var travel = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),
                Text = biProfil2.Travels
            };
            stack2.Children.Add(travel);


            var butonumuz = new Image()
            {
                Source = "kaydet111.png",
                Margin = new Thickness(0, 0, 15, 0),

            };
            var geri = new Button()
            {
                Text = "Geri",
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black
            };

            geri.Clicked += OnButtonClicked4;

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += async (s, e) => {
                

                biProfil2.FirstName = ad;
                biProfil2.LastName = soyad;
                biProfil2.City = sehir;
                biProfil2.JobTitle = unvan;
                biProfil2.Company = sirket;
                biProfil2.EMail = mail;
                GirisSayfasi.manager.login.Mail = mail;
                biProfil2.TelNo = numara;
                biProfil2.Hometown = memleket;
                //biProfil2.BirthDate = dogumgünü;
                biProfil2.OfficeAddress = ofisadres;
                biProfil2.AssistantName = asistan;
                biProfil2.Universities = universite;
                biProfil2.LinkedAccount = linkedInAcc.Text;
                biProfil2.FaceAccount = faceAcc.Text;
                biProfil2.TwitterAccount = twitAcc.Text;
                biProfil2.InstaAccount = instAcc.Text;
                biProfil2.FamilyMembers = famMem.Text;
                biProfil2.HomeAddress = homeAdd.Text;
                biProfil2.FoundAssociates = foundAssc.Text;
                biProfil2.Sports = sport.Text;
                biProfil2.Hobbies = hobby.Text;
                biProfil2.Team = team.Text;
                biProfil2.Travels = travel.Text;

                

                GirisSayfasi.manager.UpdateProfile(biProfil2);
                await Navigation.PushModalAsync(new Den());


            };
            butonumuz.GestureRecognizers.Add(tapGestureRecognizer4);

            grida.Children.Add(butonumuz, 1, 0);
            grida.Children.Add(geri, 0, 0);


            var a = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
            var b = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            b.Children.Add(a);
            b.Children.Add(grida);

            Content = b;
        }
        
    }
}
