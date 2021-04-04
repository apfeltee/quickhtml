using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// Token: 0x02000004 RID: 4
internal partial class QuickHTMLForm : Form
{
	// Token: 0x06000007 RID: 7 RVA: 0x0000223A File Offset: 0x0000043A
	public QuickHTMLForm(Options opts, string item)
	{
		this.m_opts = opts;
		this.m_item = item;
		this.InitializeComponent();
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002260 File Offset: 0x00000460
	private void EventLoadDoc(object sender, EventArgs e)
	{
		bool success = Regex.Match(this.m_item, "\\b\\w+://").Success;
		if (success)
		{
			this.LoadUrl(this.m_item);
		}
		else
		{
			this.LoadFile(this.m_item);
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000022A8 File Offset: 0x000004A8
	private void EventAutoSize(object sender, EventArgs e)
	{
		Console.WriteLine("EventAutoSize running");
		base.ClientSize = new Size(this.m_browser.Document.Body.Parent.ScrollRectangle.Width, this.m_browser.Document.Body.Parent.ScrollRectangle.Height);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002311 File Offset: 0x00000511
	private void LoadUrl(string url)
	{
		this.m_browser.Url = new Uri(url);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002328 File Offset: 0x00000528
	private void LoadFile(string path)
	{
		StreamReader streamReader = new StreamReader(path);
		string text = streamReader.ReadToEnd();
		bool wrappre = this.m_opts.wrappre;
		if (wrappre)
		{
			string documentText = string.Format("<pre>\n{0}\n</pre>", text);
			this.m_browser.DocumentText = documentText;
		}
		else
		{
			this.m_browser.DocumentText = text;
		}
	}

	// Token: 0x04000006 RID: 6
	private Options m_opts;

	// Token: 0x04000007 RID: 7
	private string m_item;
}
