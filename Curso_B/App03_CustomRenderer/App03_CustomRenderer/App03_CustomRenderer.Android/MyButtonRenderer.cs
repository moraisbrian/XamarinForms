﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App03_CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(App03_CustomRenderer.Customs.MyButton), typeof(App03_CustomRenderer.Droid.MyButtonRenderer))]
namespace App03_CustomRenderer.Droid
{
    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.button_round);
            }
        }
    }
}