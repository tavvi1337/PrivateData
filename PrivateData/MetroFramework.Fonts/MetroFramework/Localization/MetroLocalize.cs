using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MetroFramework.Localization
{
	// Token: 0x02000062 RID: 98
	internal class MetroLocalize
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x0000E558 File Offset: 0x0000C758
		public string DefaultLanguage()
		{
			return "en";
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x0000E560 File Offset: 0x0000C760
		public string CurrentLanguage()
		{
			string text = Application.CurrentCulture.TwoLetterISOLanguageName;
			if (text.Length == 0)
			{
				text = this.DefaultLanguage();
			}
			return text.ToLower();
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x0000E58D File Offset: 0x0000C78D
		public MetroLocalize(string ctrlName)
		{
			this.importManifestResource(ctrlName);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000E59C File Offset: 0x0000C79C
		public MetroLocalize(Control ctrl)
		{
			this.importManifestResource(ctrl.Name);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		private void importManifestResource(string ctrlName)
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			string name = string.Concat(new string[]
			{
				callingAssembly.GetName().Name,
				".Localization.",
				this.CurrentLanguage(),
				".",
				ctrlName,
				".xml"
			});
			Stream manifestResourceStream = callingAssembly.GetManifestResourceStream(name);
			if (manifestResourceStream == null)
			{
				name = string.Concat(new string[]
				{
					callingAssembly.GetName().Name,
					".Localization.",
					this.DefaultLanguage(),
					".",
					ctrlName,
					".xml"
				});
				manifestResourceStream = callingAssembly.GetManifestResourceStream(name);
			}
			if (this.languageDataset == null)
			{
				this.languageDataset = new DataSet();
			}
			if (manifestResourceStream != null)
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(manifestResourceStream);
				this.languageDataset.Merge(dataSet);
				manifestResourceStream.Close();
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000E69E File Offset: 0x0000C89E
		private string convertVar(object var)
		{
			if (var == null)
			{
				return "";
			}
			return var.ToString();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000E6B0 File Offset: 0x0000C8B0
		public string translate(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return "";
			}
			if (this.languageDataset == null)
			{
				return "~" + key;
			}
			if (this.languageDataset.Tables["Localization"] == null)
			{
				return "~" + key;
			}
			DataRow[] array = this.languageDataset.Tables["Localization"].Select("Key='" + key + "'");
			if (array.Length <= 0)
			{
				return "~" + key;
			}
			return array[0]["Value"].ToString();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000E754 File Offset: 0x0000C954
		public string translate(string key, object var1)
		{
			string text = this.translate(key);
			return text.Replace("#1", this.convertVar(var1));
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000E77C File Offset: 0x0000C97C
		public string translate(string key, object var1, object var2)
		{
			string text = this.translate(key);
			text = text.Replace("#1", this.convertVar(var1));
			return text.Replace("#2", this.convertVar(var2));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000E7B8 File Offset: 0x0000C9B8
		public string getValue(string key, object var1, object var2, object var3)
		{
			string text = this.translate(key);
			text = text.Replace("#1", this.convertVar(var1));
			text = text.Replace("#2", this.convertVar(var2));
			return text.Replace("#3", this.convertVar(var3));
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000E808 File Offset: 0x0000CA08
		public string getValue(string key, object var1, object var2, object var3, object var4)
		{
			string text = this.translate(key);
			text = text.Replace("#1", this.convertVar(var1));
			text = text.Replace("#2", this.convertVar(var2));
			text = text.Replace("#3", this.convertVar(var3));
			return text.Replace("#4", this.convertVar(var4));
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000E86C File Offset: 0x0000CA6C
		public string getValue(string key, object var1, object var2, object var3, object var4, object var5)
		{
			string text = this.translate(key);
			text = text.Replace("#1", this.convertVar(var1));
			text = text.Replace("#2", this.convertVar(var2));
			text = text.Replace("#3", this.convertVar(var3));
			text = text.Replace("#4", this.convertVar(var4));
			return text.Replace("#5", this.convertVar(var5));
		}

		// Token: 0x04000116 RID: 278
		private DataSet languageDataset;
	}
}
