using System;
using System.Web.Script.Serialization;

// Token: 0x02000003 RID: 3
internal class Options
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002188 File Offset: 0x00000388
	private bool getOption(string name, string normalopt, params string[] patterns)
	{
		bool flag = this.dopts.Has(patterns);
		Console.WriteLine("option {0} ({1}) = {2}", name, normalopt, flag);
		return flag;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000021BC File Offset: 0x000003BC
	public Options(string[] args)
	{
		this.dopts = new DumbOpts(args);
		this.wrappre = this.getOption("wrap-inpre", "-pre", new string[]
		{
			"e",
			"p",
			"pre"
		});
		string arg = new JavaScriptSerializer().Serialize(this.dopts.parsed);
		Console.WriteLine("parsed={0}", arg);
	}

	// Token: 0x04000004 RID: 4
	public bool wrappre = false;

	// Token: 0x04000005 RID: 5
	public DumbOpts dopts;
}
