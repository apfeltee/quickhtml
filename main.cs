using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

class DumbOpts
{
    public List<string> rawargs;
    public List<string> positional;
    public Dictionary<string, string> parsed;

    public DumbOpts(string[] args)
    {
        rawargs = new List<string>(args);
        parsed = new Dictionary<string, string>();
        positional = new List<string>();
        parse();
    }

    private void CheckAndInject(string arg)
    {
        int i;
        string actual;
        for(i=0; i<arg.Length; i++)
        {
            if(arg[i] != '-')
            {
                break;
            }
        }
        actual = arg.Substring(i);
        parsed.Add(actual, "");
    }

    public DumbOpts parse()
    {
        int i;
        string arg;
        for(i=0; i!=rawargs.Count; i++)
        {
            arg = rawargs[i];
            if(arg[0] == '-')
            {
                CheckAndInject(arg);
            }
            else
            {
                positional.Add(arg);
            }
        }
        return this;
    }

    public bool Has(params string[] ops)
    {
        foreach(var op in ops)
        {
            if(parsed.ContainsKey(op))
            {
                return true;
            }
        }
        return false;
    }
};

class Options
{
    public bool wrappre = false;
    public DumbOpts dopts;


    private bool getOption(string name, string normalopt, params string[] patterns)
    {
        var rt = dopts.Has(patterns);
        Console.WriteLine("option {0} ({1}) = {2}", name, normalopt, rt);
        return rt;
    }

    public Options(string[] args)
    {
        dopts = new DumbOpts(args);
        wrappre = getOption("wrap-inpre", "-pre", "e", "p", "pre");
        
        var json = new JavaScriptSerializer().Serialize(dopts.parsed);
        Console.WriteLine("parsed={0}", json);

    }
};

class QuickHTMLForm: Form
{
    private Options m_opts;
    private string m_item;
    private System.ComponentModel.IContainer m_comps = null;
    private System.Windows.Forms.WebBrowser m_browser;

    public QuickHTMLForm(Options opts, string item)
    {
        m_opts = opts;
        m_item = item;
        InitializeComponent();
    }

    private void EventLoadDoc(object sender, EventArgs e)
    {
        if(Regex.Match(m_item, @"\b\w+://").Success)
        {
            LoadUrl(m_item);
        }
        else
        {
            LoadFile(m_item);
        }
    }

    private void EventAutoSize(object sender, EventArgs e)
    {
        Console.WriteLine("EventAutoSize running");
         this.ClientSize = new Size(
            m_browser.Document.Body.Parent.ScrollRectangle.Width,
            m_browser.Document.Body.Parent.ScrollRectangle.Height); 
    }

    private void LoadUrl(string url)
    {
        m_browser.Url = new Uri(url);
    }

    private void LoadFile(string path)
    {
        var reader = new StreamReader(path);
        var text = reader.ReadToEnd();
        if(m_opts.wrappre)
        {
            var tmp = string.Format("<pre>\n{0}\n</pre>", text);
            m_browser.DocumentText = tmp;
        }
        else
        {
            m_browser.DocumentText = text;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (m_comps != null))
        {
            m_comps.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        m_browser = new System.Windows.Forms.WebBrowser();
        this.SuspendLayout();
        m_browser.Dock = System.Windows.Forms.DockStyle.Fill;
        m_browser.Location = new System.Drawing.Point(0, 0);
        m_browser.MinimumSize = new System.Drawing.Size(20, 20);
        m_browser.Name = "QuickBrowser";
        //m_browser.Size = new System.Drawing.Size(87, 311);
        m_browser.TabIndex = 0;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Controls.Add(m_browser);
        this.Name = "QuickHTMLForm";
        this.Text = "QuickHTMLForm";
        this.Load += new EventHandler(this.EventLoadDoc);
        m_browser.DocumentCompleted += this.EventAutoSize;
        this.ResumeLayout(false);

    }
}

static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        string arg;
        var opts = new Options(args);
        if(opts.dopts.positional.Count == 0)
        {
            Console.WriteLine("usage: quickhtml <url>\n");
        }
        else
        {
            arg = opts.dopts.positional[0];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuickHTMLForm(opts, arg));
        }
    }
}

