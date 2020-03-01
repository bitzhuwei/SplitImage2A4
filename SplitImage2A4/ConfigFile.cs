using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitImage2A4
{
	class ConfigFile
	{
		public readonly IList<CanvasSize> SizeList=new List<CanvasSize>();

		private static readonly char[] separator = new char[] { ',' };
		public static ConfigFile Load(string filename)
		{
			var result = new ConfigFile();
			var list = result.SizeList;
			using(var sr = new System.IO.StreamReader(filename))
			{
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					if (line.Trim().StartsWith("#")) { continue; }
					string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					if (parts.Length < 4) { continue; }

					float w = float.Parse(parts[0]);
					float h = float.Parse(parts[1]);
					eUnit u = (eUnit)Enum.Parse(typeof(eUnit), parts[2]);
					string n = parts[3];
					var item = new CanvasSize() {name=n, width = w, height = h, unit = u };
					list.Add(item);
				}
			}

			return result;
		}

		public static void DumpInitialConfigFile(string filename)
		{
			using(var sw= new System.IO.StreamWriter(filename,false))
			{
				{
					sw.WriteLine("# A4 paper.");
					var size = new CanvasSize() {name="A4", width = 8.267f, height = 11.692f, unit = eUnit.inch };
					sw.WriteLine($"{size.width}, {size.height}, {size.unit}, {size.name}");
				}
				{
					sw.WriteLine("# HuaWei M6.");
					var size = new CanvasSize() { name="HuaWei M6", width = 5.724f, height = 9.1584f, unit = eUnit.inch };
					sw.WriteLine($"{size.width}, {size.height}, {size.unit}, {size.name}");
				}
			}
		}
	}

	enum eUnit
	{
		inch,
		cm,
	}
	struct CanvasSize
	{
		public string name;
		public float width;
		public float height;
		public eUnit unit;

		public override string ToString()
		{
			return $"{name}: {width}*{height} {unit}";
		}
	}
}

