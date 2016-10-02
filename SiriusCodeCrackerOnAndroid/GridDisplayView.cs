using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SiriusCodeCrackerOnAndroid
{
	public class GridDisplayView : View
	{
		public GridDisplayView(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize();
		}

		public GridDisplayView(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			Initialize();
		}

		private void Initialize()
		{
		}

		public override void Draw(Canvas canvas)
		{
			Paint paint = new Paint(); 
			
			canvas.DrawPaint(paint); 
			paint.Color = Color.Black; 
			//paint.setTextSize(16); 
			canvas.DrawText("ARGH", 100, 100, paint);
		}
	}
}