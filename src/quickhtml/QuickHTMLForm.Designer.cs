// Token: 0x02000004 RID: 4
internal partial class QuickHTMLForm : global::System.Windows.Forms.Form
{
	// Token: 0x0600000C RID: 12 RVA: 0x00002380 File Offset: 0x00000580
	protected override void Dispose(bool disposing)
	{
		bool flag = disposing && this.m_comps != null;
		if (flag)
		{
			this.m_comps.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000023B8 File Offset: 0x000005B8
	private void InitializeComponent()
	{
		this.m_browser = new global::System.Windows.Forms.WebBrowser();
		base.SuspendLayout();
		this.m_browser.Dock = global::System.Windows.Forms.DockStyle.Fill;
		this.m_browser.Location = new global::System.Drawing.Point(0, 0);
		this.m_browser.MinimumSize = new global::System.Drawing.Size(20, 20);
		this.m_browser.Name = "QuickBrowser";
		this.m_browser.TabIndex = 0;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(800, 600);
		base.Controls.Add(this.m_browser);
		base.Name = "QuickHTMLForm";
		this.Text = "QuickHTMLForm";
		base.Load += new global::System.EventHandler(this.EventLoadDoc);
		this.m_browser.DocumentCompleted += new global::System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.EventAutoSize);
		base.ResumeLayout(false);
	}

	// Token: 0x04000008 RID: 8
	private global::System.ComponentModel.IContainer m_comps = null;

	// Token: 0x04000009 RID: 9
	private global::System.Windows.Forms.WebBrowser m_browser;
}
