<Query Kind="Program" />

void Main()
{
	PrettyPrint(Spiral(1));
	Console.WriteLine("-----");
	PrettyPrint(Spiral(2));
	Console.WriteLine("-----");
	PrettyPrint(Spiral(4));
	Console.WriteLine("-----");
	PrettyPrint(Spiral(5));
//	PrettyPrint(Spiral(1000));
}


static int[][] Spiral(int n)
{
	if(n < 1)
	{
		throw new Exception("Must be greater than 1");
	}
	
	var result = new int[n][];
	for(var j = 0; j < n; j++)
	{
		result[j] = new int[n];
	}

	// from top left + 0 to top right - 0
	// from top right + 1 to bottom right - 0
	// from bottom right + 1 to bottom left -0
	// from bottom left + 1 to top left - 1
	// from top left + 2 to right -1
	// from top right + 2 to bottom right -1
	// from bottom right + 2 to left - 1
	// from left to top - 2
	// ... until - n

	var lo = 0;
	var hi = 0;
	var count = 1;
	var limit = n * n;
	while (count < limit + 1)
	{
		// 0 0 0 1
		// 4 4 5 1
		// 3 6 5 1
		// 3 2 2 2

		//    0 0 0 0 0  lo - 1
		//    3 4 4 4 1
		//    3 7 8 5 1
		//    3 6 6 5 1
        // -1 2 2 2 2 1

		// top left -> top right
		for(var i = lo; i < n - hi; i++)
			result[lo][i] = count++;
		
		lo++;
		
		// top right -> bottom right
		for(var i = lo; i < n - hi; i++)
			result[i][n -1 - hi] = count++;

		
		// bottom right -> bottom left
		for(var i = n - lo - 1; i >= lo - 1; i--)
			result[n - lo][i] = count++;
		
		hi++;
		
		// bottom left -> top left
		for(var i = n - lo - 1; i > hi - 1; i--)
			result[i][lo - 1] = count++;		
	}
	
	return result;
}

static void PrettyPrint(int[][] matrix)
{
	foreach(var vector in matrix)
	{
		Console.WriteLine(string.Join(" ", vector));
	}
}