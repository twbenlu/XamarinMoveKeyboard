using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace movekeyboard
{
	public partial class movekeyboardViewController : UIViewController
	{
		public movekeyboardViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		//宣告類別變數來記錄UIView需要被抬高的距離範圍
		private float scroll_amount = 0.0f;    // amount to scroll 


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.


			this.closekeyboard.TouchUpInside += (sender, e) => {
				this.textbox.EndEditing(true);
			};

			// Keyboard popup
			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.WillShowNotification, KeyBoardWillUpNotification);

			// Keyboard Down
			NSNotificationCenter.DefaultCenter.AddObserver
			(UIKeyboard.WillHideNotification,KeyBoardDownNotification);
		}
			
		//鍵盤開啟或變更時的事件觸發處理常式
		private void KeyBoardWillUpNotification(NSNotification notification)
		{
			Console.WriteLine ("每次切換鍵盤都會觸發這個方法");
			//取得目前鍵盤的高度
			var val = new NSValue(notification.UserInfo.ValueForKey(UIKeyboard.FrameEndUserInfoKey).Handle);
			//RectangleF r = val.RectangleFValue;
			//Console.WriteLine ("r=" + r);
			var kbsize = val.CGRectValue;
			Console.WriteLine ("高度 = " + kbsize.Height + "寬度 = " + kbsize.Width);
			//要把整個View上抬的距離
			scroll_amount = kbsize.Height;
			//scroll_amount = uiviewhight - (uiviewhight-kbsize.Height);
			Console.WriteLine ("scroll_amount ="+ scroll_amount);
			//呼叫ScrollTheView來上抬UIView
			ScrollTheView ();
		}

		//鍵盤關閉時的事件觸發處理常式
		private void KeyBoardDownNotification(NSNotification notification)
		{
			//關閉鍵盤，設定UIView的Y軸移動距離
			scroll_amount = 0;
			ScrollTheView ();
		}


		//移動UIView的方法
		private void ScrollTheView()
		{
			// scroll the view up or down
			UIView.BeginAnimations (string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration (0.3);
			//取得目前UIView的Frame
			RectangleF frame = View.Frame;
			Console.WriteLine ("RectangleF frame = " + frame );
			//設定目前frame的y軸移動距離為虛擬鍵盤的高度
			frame.Y = -(scroll_amount);
			Console.WriteLine ("RectangleF frame = " + frame );
			//指定UIView的Y軸
			View.Frame = frame;
			UIView.CommitAnimations();
		}



		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}
		#endregion
	}
}

