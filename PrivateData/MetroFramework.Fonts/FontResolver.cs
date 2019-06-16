using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace MetroFramework.Fonts
{
	// Token: 0x02000002 RID: 2
	public class FontResolver : MetroFonts.IMetroFontResolver
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		public Font ResolveFont(string familyName, float emSize, FontStyle fontStyle, GraphicsUnit unit)
		{
			Font font = new Font(familyName, emSize, fontStyle, unit);
			if (font.Name == familyName || !FontResolver.TryResolve(ref familyName, ref fontStyle))
			{
				return font;
			}
			font.Dispose();
			FontFamily fontFamily = this.GetFontFamily(familyName);
			return new Font(fontFamily, emSize, fontStyle, unit);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000211C File Offset: 0x0000031C
		private static bool TryResolve(ref string familyName, ref FontStyle fontStyle)
		{
			if (familyName == "Segoe UI Light")
			{
				familyName = "Open Sans Light";
				if (fontStyle != FontStyle.Bold)
				{
					fontStyle = FontStyle.Regular;
				}
				return true;
			}
			if (!(familyName == "Segoe UI"))
			{
				return false;
			}
			if (fontStyle == FontStyle.Bold)
			{
				familyName = "Open Sans Bold";
				return true;
			}
			familyName = "Open Sans";
			return true;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002170 File Offset: 0x00000370
		private FontFamily GetFontFamily(string familyName)
		{
			FontFamily result;
			lock (this.fontCollection)
			{
				foreach (FontFamily fontFamily in this.fontCollection.Families)
				{
					if (fontFamily.Name == familyName)
					{
						return fontFamily;
					}
				}
				string name = base.GetType().Namespace + ".Resources." + familyName.Replace(' ', '_') + ".ttf";
				Stream stream = null;
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					stream = base.GetType().Assembly.GetManifestResourceStream(name);
					int num = (int)stream.Length;
					intPtr = Marshal.AllocCoTaskMem(num);
					byte[] array = new byte[num];
					stream.Read(array, 0, num);
					Marshal.Copy(array, 0, intPtr, num);
					this.fontCollection.AddMemoryFont(intPtr, num);
					result = this.fontCollection.Families[this.fontCollection.Families.Length - 1];
				}
				finally
				{
					if (stream != null)
					{
						stream.Dispose();
					}
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(intPtr);
					}
				}
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private const string OPEN_SANS_REGULAR = "Open Sans";

		// Token: 0x04000002 RID: 2
		private const string OPEN_SANS_LIGHT = "Open Sans Light";

		// Token: 0x04000003 RID: 3
		private const string OPEN_SANS_BOLD = "Open Sans Bold";

		// Token: 0x04000004 RID: 4
		private readonly PrivateFontCollection fontCollection = new PrivateFontCollection();
	}
}
