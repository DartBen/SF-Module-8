internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class DiskInformation

{

   private string name;
   private long maxVolume;
   private long freeSpace;

    public string Name()
    {
        return name;
    }
    public long MaxVolume()
    {
        return maxVolume;
    }

    public long FreeSpace()
    {
        return freeSpace;
    }

    public DiskInformation(string name, long maxVolume, long freeSpace)
    {
        this.name = name;
        this.maxVolume = maxVolume;
        this.freeSpace = freeSpace;
    }   
}