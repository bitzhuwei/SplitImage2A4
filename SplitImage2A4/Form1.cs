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
		string configFilename = "SplitImage2A4.conf";

		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!System.IO.File.Exists(configFilename))
			{
				ConfigFile.DumpInitialConfigFile(configFilename);
			}

			ConfigFile config = ConfigFile.Load(configFilename);
			foreach (var item in config.SizeList)
			{
				this.cmbSolution.Items.Add(item);
			}
			if (config.SizeList.Count > 0)
			{
				this.cmbSolution.SelectedIndex = 0;
			}
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
					//this.imgSource.SizeMode = PictureBoxSizeMode.Zoom;

					this.UpdateImageInfo();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void UpdateImageInfo()
		{
			if (this.sourceImage == null) { return; }

			float xDpi = this.sourceImage.HorizontalResolution;
			float yDpi = this.sourceImage.VerticalResolution;
			float width = this.sourceImage.Width;
			float height = this.sourceImage.Height;
			CanvasSize size;
			if (this.cmbSolution.SelectedIndex >= 0)
			{ size = (CanvasSize)this.cmbSolution.SelectedItem; }
			else
			{ size = new CanvasSize() { width = width, height = height, unit = eUnit.inch }; }
			bool 纵向 = this.rdoVertical.Checked;
			// A4: 8.267 x 11.692 inches
			float hTarget = yDpi * (纵向 ? size.width : size.height);
			float vTarget = xDpi * (纵向 ? size.height : size.width);

			int pH = (int)Math.Ceiling(width / hTarget);
			int pV = (int)Math.Ceiling(height / vTarget);
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

			{
				Image old = this.imgSource.Image;
				this.imgSource.Image = null;
				if (old != null) { old.Dispose(); }
			}

			var newImage = new Bitmap(this.sourceImage);
			float cursorX = 0;
			float cursorY = 0;
			int indexX = 0;
			int indexY = 0;
			using (var g = Graphics.FromImage(newImage))
			{
				while (cursorY <= height)
				{
					while (cursorX <= width)
					{
						g.DrawRectangle(Pens.Red, cursorX, cursorY, hTarget, vTarget);
						indexX++;
						cursorX = cursorX + hTarget;
					}
					indexY++;
					cursorX = 0;
					cursorY = cursorY + vTarget;
				}
			}

			this.imgSource.Image = newImage;
		}

		private void btnSplit_Click(object sender, EventArgs e)
		{
			if (this.sourceImage == null)
			{
				MessageBox.Show("Please Select an image first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (this.cmbSolution.SelectedIndex < 0)
			{
				MessageBox.Show("Please Select/Create a solution first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			this.btnSplit.Enabled = false;

			float xDpi = this.sourceImage.HorizontalResolution;
			float yDpi = this.sourceImage.VerticalResolution;
			float width = this.sourceImage.Width;
			float height = this.sourceImage.Height;
			bool 纵向 = this.rdoVertical.Checked;

			var size = (CanvasSize)this.cmbSolution.SelectedItem;
			// A4: 8.267 x 11.692 inches
			float hTarget = yDpi * (纵向 ? size.width : size.height);
			float vTarget = xDpi * (纵向 ? size.height : size.width);
			float cursorX = 0;
			float cursorY = 0;
			int indexX = 0;
			int indexY = 0;
			while (cursorY <= height)
			{
				while (cursorX <= width)
				{
					Bitmap bmpPart = null;
					//float pW = 0; float pH = 0;
					//if (cursorX + hA4 <= width) { pW = hA4; }
					//else { pW = width - cursorX; }
					//if (cursorY + vA4 <= height) { pH = vA4; }
					//else { pH = height - cursorY; }
					//bmpPart = new Bitmap((int)pW, (int)pH);
					bmpPart = new Bitmap((int)hTarget, (int)vTarget);
					bmpPart.SetResolution(xDpi, yDpi);
					using (var g = Graphics.FromImage(bmpPart))
					{
						g.DrawImage(this.sourceImage,
							new RectangleF(0, 0, hTarget, vTarget),
							new RectangleF(cursorX, cursorY, hTarget, vTarget),
							 GraphicsUnit.Pixel);
					}
					bmpPart.Save(string.Format($"{this.filename}_{indexY:00}_{indexX:00}.jpg"));
					bmpPart.Dispose();
					indexX++;
					cursorX = cursorX + hTarget;
				}
				indexY++;
				cursorX = 0;
				cursorY = cursorY + vTarget;
			}

			this.btnSplit.Enabled = true;
		}

		private void rdoVertical_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateImageInfo();
		}

		private void rdoHorizontal_CheckedChanged(object sender, EventArgs e)
		{
			this.UpdateImageInfo();
		}
	}
}

