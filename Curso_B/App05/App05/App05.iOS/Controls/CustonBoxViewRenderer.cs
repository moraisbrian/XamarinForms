using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App05.Controls;
using App05.iOS.Controls;
using CoreGraphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustonBoxViewRenderer))]
namespace App05.iOS.Controls
{
    public class CustonBoxViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            CustomBoxView control = Element as CustomBoxView;

            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetStrokeColor(new CGColor(0, 0, 0));
                context.SetLineWidth((float)control.Espessura);

                var rectPath = new CGRect(0, 0, 200, 200);
                context.AddRect(rectPath);
                context.DrawPath(CGPathDrawingMode.Stroke);
            }

            // base.Draw(rect);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomBoxView.EspessuraProperty.PropertyName)
            {
                SetNeedsDisplay();
            }

            // base.OnElementPropertyChanged(sender, e);
        }
    }
}