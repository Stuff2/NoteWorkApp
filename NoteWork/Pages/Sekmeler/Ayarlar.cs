using NoteWork.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public class Ayarlar : ContentPage
    {
        public Ayarlar()
        {
            this.Icon = "ayarlar.png";

            var o = new int(); Device.OnPlatform(iOS: () => o = 20, Android: () => o = 0);
            Padding = new Thickness(0, o, 0, 0);
            var c = new Grid() { BackgroundColor = Color.FromHex("#e6e6e6")};
            var b = new Grid();
            b.RowDefinitions.Add(new RowDefinition { Height = new GridLength(45, GridUnitType.Absolute) });
            b.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var a = new CTableView
            {
                Margin = new Thickness(0, Device.OnPlatform(-6, -6, 0), 0, 0),
                RowHeight = 45,
                Intent = TableIntent.Menu,
                Root = new TableRoot(AppResource.ayarlartableroot)
                    {
                        new TableSection (AppResource.ayarlartablesection1)
                        {
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell1,TextColor = Color.Black,
                                Command=new Command(()=>funcs())
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell2,TextColor = Color.Black,
                                Command=new Command(()=>funcs2())
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell3,TextColor = Color.Black
                            },
                        },
                        new TableSection (AppResource.ayarlartablesection2)
                        {
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell4,TextColor = Color.Black
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell5,TextColor = Color.Black,
                                Command=new Command(()=>funcs3())
                            },
                        },
                        new TableSection (AppResource.ayarlartablesection3)
                        {
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell6,TextColor = Color.Black,
                                Command=new Command(()=>funcs4())
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell7,TextColor = Color.Black
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell8,TextColor = Color.Black,
                                Command=new Command(()=>funcs5())
                            },
                        },
                        new TableSection
                        {
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell9,TextColor = Color.FromHex("#76c5c4")
                            },
                            new TextCell
                            {
                                Text = AppResource.ayarlartextcell10,TextColor = Color.FromHex("#76c5c4"),
                                Command=new Command(()=>funcs6())
                            },
                        }
                    }
                };

            
            var Ust = new Image()
            {
                Source = "UstTabLogo.png",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 10),
                HeightRequest = 30,
                WidthRequest = 30
            };
            c.Children.Add(Ust,0,0);
            b.Children.Add(c,0,0);
            b.Children.Add(a,0,1);

            Content = b;
        }

        private void funcs()
        {

            Navigation.PushModalAsync(new SifreDegistir());
            
        }
        private void funcs2()
        {

            Navigation.PushModalAsync(new HesapSil());

        }
        private void funcs3()
        {

            Navigation.PushModalAsync(new sikayet());

        }
        private void funcs4()
        {

            Navigation.PushModalAsync(new Hakkinda());

        }
        private void funcs5()
        {

            Navigation.PushModalAsync(new GizlilikVeGuvenlik());

        }
        private async void funcs6()
        {
            Navigation.PopModalAsync();

        }
    }
}
