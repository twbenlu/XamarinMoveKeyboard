// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace movekeyboard
{
	[Register ("movekeyboardViewController")]
	partial class movekeyboardViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton closekeyboard { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField textbox { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (closekeyboard != null) {
				closekeyboard.Dispose ();
				closekeyboard = null;
			}
			if (textbox != null) {
				textbox.Dispose ();
				textbox = null;
			}
		}
	}
}
