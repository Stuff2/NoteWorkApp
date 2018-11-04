using NoteWork.Modals;
using NoteWork.Renderer;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
    public partial class Kisiekle2 : ContentPage
    {
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

        public Kisiekle2(string ad, string soyad, string sehir, string unvan, string sirket, string mail, string numara)
        {

            var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
            var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, -6, 0, 0) };
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            var gridb = new Grid() { BackgroundColor = Color.FromHex("#eee") };
            gridb.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridb.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridb.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridb.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            gridb.RowDefinitions.Add(new RowDefinition { Height = new GridLength(4, GridUnitType.Absolute) });
            gridb.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) });

            CPicker picker = new CPicker()
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0),

            };
            
            picker.Items.Add(AppResource.kisieklepicker1);
            picker.Items.Add(AppResource.kisieklepicker2);
            picker.Items.Add(AppResource.kisieklepicker3);
            picker.Items.Add(AppResource.kisieklepicker4);
            picker.Items.Add(AppResource.kisieklepicker5);

            


            stack.Children.Add(new Label
            {
                Text = AppResource.kisiekle2label,
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
                Text = AppResource.kisieklelabel8,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var whenMeet = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };
            stack2.Children.Add(whenMeet);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel9,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var whereMeet = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };
            stack2.Children.Add(whereMeet);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel10,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var firstGlance = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };
            stack2.Children.Add(firstGlance);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel11,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var distinctive = new CEntry
            {
                BackgroundColor = Color.FromHex("#eee"),
                Margin = new Thickness(15, 0, 15, 0)
            };
            stack2.Children.Add(distinctive);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel12,

                Margin = new Thickness(20, 20, 0, 0)
            });
            var gayagay = new Image() { Source = "gaydirganlik.png", VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var gayagay1 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End };
            var gayagay2 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            var gayagay3 = new Image() { Source = "gaydirganlik2.png", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start };
            var btn1 = new Button() { HeightRequest = 50, WidthRequest = 50, BackgroundColor = Color.FromHex("#00aeb3"), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End };
            var btn2 = new Button() { HeightRequest = 50, WidthRequest = 50, BackgroundColor = Color.FromHex("#1a94d2"), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            var btn3 = new Button() { HeightRequest = 50, WidthRequest = 50, BackgroundColor = Color.FromHex("#9e9fa2"), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start };
            var tanis = new Label() { Text = "Tanışıyoruz", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End };
            var notanis = new Label() { Text = "Tanışmıyoruz", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            var wanttanis = new Label() { Text = "Tanışmak İstiyorum", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start };
            gridb.Children.Add(btn1, 0, 0);
            gridb.Children.Add(btn2, 1, 0);
            gridb.Children.Add(btn3, 2, 0);
            gridb.Children.Add(gayagay, 0, 1);
            gridb.Children.Add(gayagay1, 0, 1);
            gridb.Children.Add(gayagay2, 1, 1);
            gridb.Children.Add(gayagay3, 2, 1);
            gridb.Children.Add(tanis, 0, 2);
            gridb.Children.Add(notanis, 1, 2);
            gridb.Children.Add(wanttanis, 2, 2);
			gayagay1.IsVisible = true;
			gayagay2.IsVisible = false;
			gayagay3.IsVisible = false;
			tanis.IsVisible = true;
			notanis.IsVisible = false;
			wanttanis.IsVisible = false;
			btn1.Clicked += (s, e) => 
			{
				gayagay1.IsVisible = true;
				gayagay2.IsVisible = false;
				gayagay3.IsVisible = false;
				tanis.IsVisible = true;
				notanis.IsVisible = false;
				wanttanis.IsVisible = false;
			};
            btn2.Clicked += (s, e) => 
			{
				gayagay1.IsVisible = false;
				gayagay2.IsVisible = true;
				gayagay3.IsVisible = false;
				tanis.IsVisible = false;
				notanis.IsVisible = true;
				wanttanis.IsVisible = false;
			};
            btn3.Clicked += (s, e) => 
			{
				gayagay1.IsVisible = false;
				gayagay2.IsVisible = false;
				gayagay3.IsVisible = true;
				tanis.IsVisible = false;
				notanis.IsVisible = false;
				wanttanis.IsVisible = true;
			};


            


            Grid.SetColumnSpan(gayagay, 3);
            stack2.Children.Add(gridb);
            stack2.Children.Add(new Label
            {
                Text = AppResource.kisieklelabel13,

                Margin = new Thickness(20, 20, 0, 0)
            });
            stack2.Children.Add(picker);
            var butonumuz = new Image()
            {
                Source = "tamamla111.png",
                Margin = new Thickness(0, 0, 15, 0),

            };
            var iptal = new Button()
            {
                Text = AppResource.kisieklebuton,
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black
            };

            iptal.Clicked += OnButtonClicked4;


            string bc = tanis.Text;

          

            var tapGestureRecognizer4 = new TapGestureRecognizer();
            tapGestureRecognizer4.Tapped += async (s, e) => {
                if (tanis.IsVisible == true && notanis.IsVisible == false && wanttanis.IsVisible == false)
                {
                    bc = tanis.Text;
                }
                if (tanis.IsVisible == false && notanis.IsVisible == true && wanttanis.IsVisible == false)
                {
                    bc = notanis.Text;
                }
                if (tanis.IsVisible == false && notanis.IsVisible == false && wanttanis.IsVisible == true)
                {
                    bc = wanttanis.Text;
                }
                
                var pl = new Profile { FirstName = ad, LastName = soyad, City = sehir, JobTitle = unvan, Company = sirket, EMail = mail, TelNo = numara };
                
                var nt = new NetWork { MeetWhen = whenMeet.Text, MeetWhere = whereMeet.Text, FirstImpression = firstGlance.Text, Distinctive = distinctive.Text, MeetState = bc, NetWorks = picker.Items[picker.SelectedIndex] };
                
                GirisSayfasi.manager.SaveLoginAsync2(pl, nt);
                await Navigation.PushModalAsync(new Den());
                
            };
            butonumuz.GestureRecognizers.Add(tapGestureRecognizer4);

            grida.Children.Add(butonumuz, 1, 0);
            grida.Children.Add(iptal, 0, 0);
            picker.SelectedIndex = 0;

            var p = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
            var r = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
			r.Children.Add(p);
			r.Children.Add(grida);

			Content = r;

        }


    }
}
