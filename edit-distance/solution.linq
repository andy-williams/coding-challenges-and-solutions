<Query Kind="Program" />

// we identify our base case - if the length of s1 and s2 are different by more than 1, we fail immediately
// we try to compare the two strings in unison, character by character
// if we see our first edit, we would flag it
// if we've already seen an edit last time, but the length are different, then we don't immediately fail,
// we ignore this instead as we allow one character being off, so long as all other characters pass

void Main()
{
	OneEditApart("cat", "dog").Dump();
	OneEditApart("cat", "cats").Dump();
	OneEditApart("cat", "cut").Dump();
	OneEditApart("cat", "cast").Dump();
	OneEditApart("cat", "at").Dump();
	OneEditApart("cat", "act").Dump();
	OneEditApart("cat", "cact").Dump();
	OneEditApart("cat", "cact").Dump();
}

static bool OneEditApart(string s1, string s2)
{
	string baseString;
	string otherString;
	
	if(s1.Length >= s2.Length)
	{
		baseString = s1;
		otherString = s2;
	}
	else
	{
		baseString = s2;
		otherString = s1;
	}
	
	// base case
	if(baseString.Length - otherString.Length > 1)
		return false;
		
	var foundEdit = false;
	var j = 0;
	for(var i = 0; i < baseString.Length; i++)
	{
		var c1 = baseString[i];
		var c2 = otherString[j];
		
		if(c1 != c2)
		{
			if(!foundEdit || baseString.Length == otherString.Length)
			{
				if(foundEdit)
					return false;
				foundEdit = true;
			}
		}

		if (j < otherString.Length - 1)
			j++;
	}

	return foundEdit;
}