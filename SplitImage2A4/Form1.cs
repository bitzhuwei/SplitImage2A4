using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitImage2A4
{
	public partial class Form1 : Form
	{
		Bitmap sourceImage;
		string filename;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				string filename = this.dlgOpenFile.FileName;
				try
				{
					this.sourceImage = new Bitmap(filename);
					this.filename = (new FileInfo(filename)).FullName;
					this.imgSource.Image = this.sourceImage;
					this.imgSource.SizeMode = PictureBoxSizeMode.Zoom;
					float xDpi = this.sourceImage.HorizontalResolution;
					float yDpi = this.sourceImage.VerticalResolution;
					float width = this.sourceImage.Width;
					float height = this.sourceImage.Height;
					// A4: 8.267 x 11.692 inches
					float hA4 = yDpi * 8.267f;
					float vA4 = xDpi * 11.692f;
					int pH =(int) Math.Ceiling( width / hA4);
					int pV =(int)Math.Ceiling( height / vA4);
					var builder = new StringBuilder();
					//builder.AppendFormat($"fullname:{this.filename}");
					//builder.AppendLine();
					builder.AppendFormat($"DPI:{xDpi}, {yDpi}");
					//builder.AppendLine();
					builder.AppendFormat($", Size:{width}, {height}");
					builder.AppendLine();
					builder.AppendFormat($"=>:{pH}*{pV} parts.");
					builder.AppendLine();
					this.txtImageInfo.Text = builder.ToString();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnSplit_Click(object sender, EventArgs e)
		{
			if (this.sourceImage == null)
			{
				MessageBox.Show("Please Select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.btnSplit.Enabled = false;
			
			float xDpi = this.sourceImage.HorizontalResolution;
			float yDpi = this.sourceImage.VerticalResolution;
			float width = this.sourceImage.Width;
			float height = this.sourceImage.Height;

			// A4: 8.267 x 11.692 inches
			float hA4 = yDpi * 8.267f;
			float vA4 = xDpi * 11.692f;
			float cursorX = 0;
			float cursorY = 0;
			int indexX = 0;
			int indexY = 0;
			while (cursorY <= height)
			{
				while (cursorX <= width)
				{
					Bitmap bmpPart = null;
					float pW = 0; float pH = 0;
					//if (cursorX + hA4 <= width) { pW = hA4; }
					//else { pW = width - cursorX; }
					//if (cursorY + vA4 <= height) { pH = vA4; }
					//else { pH = height - cursorY; }
					//bmpPart = new Bitmap((int)pW, (int)pH);
					bmpPart = new Bitmap((int)hA4, (int)vA4);
					bmpPart.SetResolution(xDpi, yDpi);
					using (var g = Graphics.FromImage(bmpPart))
					{
						g.DrawImage(this.sourceImage,
							new RectangleF(0, 0, hA4, vA4),
							new RectangleF(cursorX, cursorY, hA4, vA4),
							 GraphicsUnit.Pixel);
					}
					bmpPart.Save(string.Format($"{this.filename}_{indexY:00}_{indexX:00}.png"));
					bmpPart.Dispose();
					indexX++;
					cursorX = cursorX + hA4;
				}
				indexY++;
				cursorX = 0;
				cursorY = cursorY + vA4;
			}

			this.btnSplit.Enabled = true;
		}
	}
}
