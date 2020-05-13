using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(App03_CustomRenderer.Customs.MyButton), typeof(App03_CustomRenderer.iOS.MyButtonRenderer))]
namespace App03_CustomRenderer.iOS
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 10;
                Control.ClipsToBounds = true;
                Control.BackgroundColor = UIColor.Blue;
            }
        }
    }
}