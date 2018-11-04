using Xamarin.Forms;
using NoteWork;
using NoteWork.iOS;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer (typeof(ExtendedListView), typeof(RendererListView))]
namespace NoteWork.iOS
{
	public class RendererListView:ViewRenderer<ExtendedListView, UITableView>
	{
		public RendererListView ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ExtendedListView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				SetNativeControl (new UITableView () {					
					BackgroundColor = UIColor.White,
					RowHeight = NativeListCell.HEIGHT,
					AutoresizingMask = UIViewAutoresizing.All,
					SeparatorStyle = UITableViewCellSeparatorStyle.None,
					Bounces = true,
					BouncesZoom = true,
					ScrollEnabled = true,
					SectionFooterHeight = 0,
					SectionHeaderHeight = NativeListCell.HEIGHT,

					//The following two lines are written to disable the default behaviour of section header movement with cells
					TableHeaderView = new UIView (new CGRect (0, 0, 100, NativeListCell.HEIGHT)),
					ContentInset = new UIEdgeInsets (-NativeListCell.HEIGHT, 0, 0, 0)
				});
			}

			if (e.OldElement != null) {
				// unsubscribe
			}

			if (e.NewElement != null) {
				// subscribe
				var s = new SettingsListSource (e.NewElement);
				Control.Source = s;
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == ExtendedListView.ItemsProperty.PropertyName) {
				// update the Items list in the UITableViewSource
				var s = new SettingsListSource (Element);
				Control.Source = s;
			}
		}

		public override SizeRequest GetDesiredSize (double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest (widthConstraint, heightConstraint, 44, 44);
		}
	}
}