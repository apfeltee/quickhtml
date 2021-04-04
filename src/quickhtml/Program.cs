using System;
using System.Windows.Forms;

// Token: 0x02000005 RID: 5
internal static class Program
{
	// Token: 0x0600000E RID: 14 RVA: 0x000024BC File Offset: 0x000006BC
	[STAThread]
	private static void Main(string[] args)
	{
		Options options = new Options(args);
		bool flag = options.dopts.positional.Count == 0;
		if (flag)
		{
			Console.WriteLine("usage: quickhtml <url>\n");
		}
		else
		{
			string item = options.dopts.positional[0];
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new QuickHTMLForm(options, item));
		}
	}
}
