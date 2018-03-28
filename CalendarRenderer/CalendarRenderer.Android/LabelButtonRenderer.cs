using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CalendarRenderer.Controls;
using CalendarRenderer.Droid;

//[assembly: ExportRenderer(typeof(LabelButton), typeof(LabelButtonRenderer))]
//namespace CalendarRenderer.Droid
//{
//    //public class LabelButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
//    //{
//    //    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
//    //    {
//    //        base.OnElementChanged(e);

//    //        if (Control != null)
//    //        {
//    //           // Control.SetBackgroundColor(Android.Graphics.Color.Black);
//    //            if (e.NewElement == null) return;

//    //            var labelButton = e.NewElement as LabelButton;
//    //            labelButton.Text = labelButton.ProgressColor;
//    //            labelButton.BackgroundColor = Color.Green;
//    //            labelButton.FontSize =2;

//    //        }
//    //    }
//    //}
//}