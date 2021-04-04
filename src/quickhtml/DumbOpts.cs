using System;
using System.Collections.Generic;

// Token: 0x02000002 RID: 2
internal class DumbOpts
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public DumbOpts(string[] args)
	{
		this.rawargs = new List<string>(args);
		this.parsed = new Dictionary<string, string>();
		this.positional = new List<string>();
		this.parse();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
	private void CheckAndInject(string arg)
	{
		int i;
		for (i = 0; i < arg.Length; i++)
		{
			bool flag = arg[i] != '-';
			if (flag)
			{
				break;
			}
		}
		string key = arg.Substring(i);
		this.parsed.Add(key, "");
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020D8 File Offset: 0x000002D8
	public DumbOpts parse()
	{
		for (int num = 0; num != this.rawargs.Count; num++)
		{
			string text = this.rawargs[num];
			bool flag = text[0] == '-';
			if (flag)
			{
				this.CheckAndInject(text);
			}
			else
			{
				this.positional.Add(text);
			}
		}
		return this;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002144 File Offset: 0x00000344
	public bool Has(params string[] ops)
	{
		foreach (string key in ops)
		{
			bool flag = this.parsed.ContainsKey(key);
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000001 RID: 1
	public List<string> rawargs;

	// Token: 0x04000002 RID: 2
	public List<string> positional;

	// Token: 0x04000003 RID: 3
	public Dictionary<string, string> parsed;
}
