namespace TTSCleanup;

public static class Program
{
    public static void Main(string[] args)
    {
	    var filePath = @"%USERPROFILE%\Documents\My Games\Tabletop Simulator\Saves";
	    filePath = Environment.ExpandEnvironmentVariables(filePath);
	    
	    if (args.Length > 0)
	    {
		    if (!Directory.Exists(args[0]))
		    {
			    Console.WriteLine($"{args[0]} not a valid directory");
			    return;
		    }

		    filePath = args[0];
	    }

	    if (!Directory.Exists(filePath))
	    {
		    Console.WriteLine($"File path {filePath} does not exist");
		    return;
	    }
        
        var files = Directory.GetFiles(filePath, "*.json", new EnumerationOptions { RecurseSubdirectories = true });
        var badUrl = "obje.glitch.me";
	       
        int totalRemovals = 0;
	       
        foreach (var file in files)
        {
            int fileRemovals = 0;
		      
            var lines = File.ReadLines(file).ToArray();
		      
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(badUrl))
                {
                    var index = lines[i].IndexOf("          --[[Object base code]]");
                    lines[i] = lines[i].Remove(index).TrimEnd() + "\",";
                    fileRemovals++;
                    totalRemovals++;
                }
            }
        
            if (fileRemovals > 0)
                Console.WriteLine($"{file}: {fileRemovals}");
			     
            File.WriteAllLines(file, lines);
        }
        
        Console.WriteLine($"Done!\nTotal instances removed: {totalRemovals}");
    }
}