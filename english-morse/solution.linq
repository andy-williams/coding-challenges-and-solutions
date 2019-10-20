<Query Kind="Program" />

void Main()
{
	TranslateToMorse("S O S").Dump();
	TranslateToMorse("Hello World").Dump();
}

public static string TranslateToMorse(string english)
{
	var result = new StringBuilder();
	foreach(var ch in english.ToLowerInvariant())
	{
		if (!CharToMorseMapping.ContainsKey(ch))
			throw new Exception($"{ch} character does not map to any morse code.");
		
		result.Append(CharToMorseMapping[ch]);
	}
	
	return result.ToString();
}

private static IDictionary<char, string> _charToMorseMap;
private static IDictionary<string, char> _morseToCharMap;

private static IDictionary<string, char> MorseToCharMap
{
	get
	{
		if(_morseToCharMap == null)
		{
			foreach(var kv in CharToMorseMapping)
			{
				_morseToCharMap.Add(kv.Value, kv.Key);
			}
		}
		
		return _morseToCharMap;
	}
}
private static IDictionary<char, string> CharToMorseMapping
{
	get
	{
		if (_charToMorseMap == null)
		{
			_charToMorseMap = new Dictionary<char, string>();
			_charToMorseMap.Add('a', ".-");
			_charToMorseMap.Add('b', "-...");
			_charToMorseMap.Add('c', "-.-.");
			_charToMorseMap.Add('d', "-..");
			_charToMorseMap.Add('e', ".");
			_charToMorseMap.Add('f', "..-.");
			_charToMorseMap.Add('g', "--.");
			_charToMorseMap.Add('h', "....");
			_charToMorseMap.Add('i', "..");
			_charToMorseMap.Add('j', ".---");
			_charToMorseMap.Add('k', "-.-");
			_charToMorseMap.Add('l', ".-..");
			_charToMorseMap.Add('m', ".--");
			_charToMorseMap.Add('n', "-.");
			_charToMorseMap.Add('o', "---");
			_charToMorseMap.Add('p', ".--.");
			_charToMorseMap.Add('q', "--.-");
			_charToMorseMap.Add('r', ".-.");
			_charToMorseMap.Add('s', "...");
			_charToMorseMap.Add('t', "-");
			_charToMorseMap.Add('u', "..-");
			_charToMorseMap.Add('v', "...-");
			_charToMorseMap.Add('w', ".--");
			_charToMorseMap.Add('x', "-..-");
			_charToMorseMap.Add('y', "-.--");
			_charToMorseMap.Add('z', "--..");
			_charToMorseMap.Add(' ', " ");

			_charToMorseMap.Add('1', ".----");
			_charToMorseMap.Add('2', "..---");
			_charToMorseMap.Add('3', "...--");
			_charToMorseMap.Add('4', "....-");
			_charToMorseMap.Add('5', ".....");
			_charToMorseMap.Add('6', "-....");
			_charToMorseMap.Add('7', "--...");
			_charToMorseMap.Add('8', "---..");
			_charToMorseMap.Add('9', "----.");
			_charToMorseMap.Add('0', "-----");
		}

		return _charToMorseMap;
	}
}

// Define other methods and classes here
