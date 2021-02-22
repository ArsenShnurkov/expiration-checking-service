using System;
//using System.Collections;
using System.Collections.Generic;
using System.Globalization;

class Domain
{
	public static string static_encoding(string s)
	{
		IdnMapping idnMapping = new IdnMapping();
		string punycodeDomainName = idnMapping.GetAscii(s);
		return punycodeDomainName;
	}
	public static string static_decoding(string s)
	{
		IdnMapping idnMapping = new IdnMapping();
		string unicodeDomainName = idnMapping.GetUnicode(s);
		return unicodeDomainName;
	}

	string Url;
	public string Name { get { return Url; } set { Url=value; } }
	public Domain(string d)
	{
	    Url = d;
	}
}

class DomainCollection : List<Domain>
{
}

class DomainCollectionLoader
{
	static string[] array = { 
	    Domain.static_encoding("план-а.программирование-по-русски.рф"),
	    "xmpp.bbs.io"
	};
	
	public DomainCollection Load()
	{
	    DomainCollection res = new DomainCollection();
	    res.Add(new Domain(array[0]));
	    res.Add(new Domain(array[1]));
	    return res;
	}
}

public class EntryPoint
{
	public static int Main(string[] args)
	{
		DomainCollectionLoader loader = new DomainCollectionLoader();
		foreach  (Domain D in loader.Load())
		{
			Console.WriteLine(D.Name + "\t" + Domain.static_decoding(D.Name));
		}
		return 0;
	}
}
