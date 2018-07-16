<Query Kind="Program" />

// the key to understanding the problem is the name of the puzzle, look and say.
// starting from our base of "1", we follow up by saying "one 1", written out as "11"
// from "11", we say two 1's, so we write it out as "21"
// from "21", we say "one 2, one one", so we write it out as "1211"
// we can only count up to three, then we start our count back to 0.
// for example, if we see 1111, we don't say "four 1's", we say "three 1, one 1", so we write this out as "3111"

void Main()
{
	LookAndSay(20);
}


static void LookAndSay(int n)
{
	var val = "1";
	
	for(var i = 1; i <= n; i++)
	{
		Console.WriteLine(val);
		val = NextSequence(val.ToString());
	}
}

static string NextSequence(string value)
{
	var nextValue = new StringBuilder();
	
	var last = "";
	var count = 0;
	for(var i = 0; i < value.Length; i++)
	{
		var current = value[i].ToString();
		if(count == 3)
		{
			nextValue.Append($"{count}{last}");
			last = current;
			count = 1;
		}
		else if(string.IsNullOrWhiteSpace(last))
		{
			last = current;
			count++;
		}
		else if(current == last)
		{
			count++;
		}
		else
		{
			nextValue.Append($"{count}{last}");
			last = current;
			count = 1;
		}
		if (i == value.Length - 1)
		{
			nextValue.Append($"{count}{last}");
		}
	}
	
		
	return nextValue.ToString();
}