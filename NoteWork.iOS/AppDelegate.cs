
using Foundation;
using UIKit;

namespace NoteWork.iOS
{
    [Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public static DeviceType deviceType = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? DeviceType.IPHONE : DeviceType.IPAD;
		public static double DeviceWidth = UIScreen.MainScreen.Bounds.Width * 2;
		public static double DeviceHeight = UIScreen.MainScreen.Bounds.Height * 2;

        public enum DeviceType
        {
            IPHONE = 0,
            IPAD = 1
        }

        public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

            // Initialization for Azure Mobile Apps
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            // This MobileServiceClient has been configured to communicate with the Azure Mobile App and
            // Azure Gateway using the application url. You're all set to start working with your Mobile App!
            Microsoft.WindowsAzure.MobileServices.MobileServiceClient ntwkClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
            "");
            global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

