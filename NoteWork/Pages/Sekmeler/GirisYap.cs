using NoteWork.Renderer;
using NoteWork.Resx;
using NoteWork.Store;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace NoteWork.Pages.Sekmeler
{
	public class GirisYap : ContentPage
	{
		async void OnButtonClicked4(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
		public GirisYap()
		{
			{
				bool gi;
				const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
				@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
				var stack = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
				var stack2 = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6"), Margin = new Thickness(0, 40, 0, 0) };
				var grida = new Grid() { BackgroundColor = Color.FromHex("#f6f6f6"), VerticalOptions = LayoutOptions.EndAndExpand };
				grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				grida.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				grida.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
				//Den den = null;
				/*if (den == null)
                {
                    den = new Den();
                }*/
				var mail = new CEntry
				{
					BackgroundColor = Color.FromHex("#eee"),
					Margin = new Thickness(15, 0, 15, 0),
					Keyboard = Keyboard.Email,
					//Text = "b@b.co"

				};
				var sifre = new CEntry
				{
					BackgroundColor = Color.FromHex("#eee"),
					IsPassword = true,
					Margin = new Thickness(15, 0, 15, 0),
					//Text = "bbbbbbb"
				};
				stack.Children.Add(stack2);

				stack2.Children.Add(new Label
				{
					Text = AppResource.girisyaplabelmail,

					Margin = new Thickness(20, 20, 0, 0)
				});
				stack2.Children.Add(mail);
				stack2.Children.Add(new Label
				{
					Text = AppResource.girisyaplabelsifre,

					Margin = new Thickness(20, 20, 0, 0)
				});
				stack2.Children.Add(sifre);



				var butonumuz = new Image()
				{
					Source = "girisyap112.png",
					Margin = new Thickness(0, 0, 15, 0),

				};
				var iptal = new Button()
				{
					Text = AppResource.iptalbuton,
					BackgroundColor = Color.Transparent,
					TextColor = Color.Black
				};

				iptal.Clicked += OnButtonClicked4;

				var tapGestureRecognizer = new TapGestureRecognizer();
				tapGestureRecognizer.Tapped += async (s, e) =>
				{

					if (string.IsNullOrEmpty(mail.Text) || string.IsNullOrEmpty(sifre.Text) || sifre.Text.Length < 6)
					{
						await DisplayAlert("Dikkat", "Lütfen boşlukları doğru bir şekilde doldurunuz!", "Tamam");
						return;
					}

					var mailValid = (Regex.IsMatch(mail.Text, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));


					if (mailValid)
					{
						gi = false;
						if (await GirisSayfasi.manager.LoginAsync(mail.Text, sifre.Text))
						{
							if (gi == false)
							{
								gi = true;
								await Navigation.PushModalAsync(new Den());

							}

						}
						else
							await DisplayAlert("Dikkat", "Yanlış Email Şifre Kombinasyonu", "Tamam");
					}
					else
					{
						await DisplayAlert("Dikkat", "Bilgilerinizde eksik veya yanlış girdi tespit edilmiştir. Lütfen tekrar bilgilerinizi giriniz!", "Tamam");
					}


				};
				butonumuz.GestureRecognizers.Add(tapGestureRecognizer);


				grida.Children.Add(butonumuz, 1, 0);
				grida.Children.Add(iptal, 0, 0);

				var a = new ScrollView { Content = stack, Padding = new Thickness(0, 0, 0, 20) };
				var b = new StackLayout() { BackgroundColor = Color.FromHex("#f6f6f6") };
				b.Children.Add(a);
				b.Children.Add(grida);

				Content = b;

			}
		}
	}
}
