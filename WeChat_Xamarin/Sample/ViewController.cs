using System;
using Foundation;
using UIKit;

namespace Sample
{
    public partial class ViewController : UIViewController
    {
        WeChatApi weChat;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            weChat = new WeChatApi();
            this.View.BackgroundColor = UIColor.Red;
            System.Diagnostics.Debug.WriteLine(weChat.CurrentVersion);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            if(UIApplication.SharedApplication.CanOpenUrl(NSUrl.FromString("weixin://")))
            {
                weChat.SendText("Hello xamarin!");
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
