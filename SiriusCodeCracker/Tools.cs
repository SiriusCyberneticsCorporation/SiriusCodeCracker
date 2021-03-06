﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace SiriusCodeCracker
{
	public class Tools
	{
		static public Font FindBestFitFont(Graphics g, String text, Font font, SizeF proposedSize)
		{
			// Compute actual size, shrink if needed
			while (true)
			{
				SizeF size = g.MeasureString(text, font);

				// It fits, back out
				if (size.Height <= proposedSize.Height &&
					 size.Width <= proposedSize.Width)
				{
					return font;
				}

				// Try a smaller font (90% of old size)
				Font oldFont = font;
				font = new Font(font.Name, (float)(font.Size * .9), font.Style);
				oldFont.Dispose();
			}
		}

		static public void DrawRoundedRectangle(Graphics g, RectangleF bounds, Pen borderPen, Color fillColour)
		{
			int CornerRadius = (int)(Math.Min(bounds.Width, bounds.Height) * 0.2);
			int strokeOffset = Convert.ToInt32(Math.Ceiling(borderPen.Width));
			bounds = RectangleF.Inflate(bounds, -strokeOffset, -strokeOffset);

			GraphicsPath gfxPath = new GraphicsPath();
			gfxPath.AddArc(bounds.X, bounds.Y, CornerRadius, CornerRadius, 180, 90);
			gfxPath.AddArc(bounds.X + bounds.Width - CornerRadius, bounds.Y, CornerRadius, CornerRadius, 270, 90);
			gfxPath.AddArc(bounds.X + bounds.Width - CornerRadius, bounds.Y + bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
			gfxPath.AddArc(bounds.X, bounds.Y + bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
			gfxPath.CloseAllFigures();

			GraphicsPath gradientPath = new GraphicsPath();
			gradientPath.AddEllipse(RectangleF.Inflate(bounds, bounds.Width/2, bounds.Height/2));

			PathGradientBrush gradientBrush = new PathGradientBrush(gradientPath);
			gradientBrush.CenterPoint = new PointF(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
			gradientBrush.CenterColor = Color.AliceBlue;
			gradientBrush.SurroundColors = new Color[] { Color.DimGray };
			g.FillPath(gradientBrush, gfxPath);

			// Use the following line for plain buttons
//			g.FillPath(new SolidBrush(fillColour), gfxPath);

			g.DrawPath(borderPen, gfxPath);
		}
	}
}
