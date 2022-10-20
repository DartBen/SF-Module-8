using static System.Console;
internal class Program
{
    private static void Main(string[] args)
    {
        //// получим системные диски
        //DriveInfo[] drives = DriveInfo.GetDrives();

        //// Пробежимся по дискам и выведем их свойства
        //foreach (DriveInfo drive in drives)
        //{
        //    Console.WriteLine($"Название: {drive.Name}");
        //    Console.WriteLine($"Тип: {drive.DriveType}");
        //    if (drive.IsReady)
        //    {
        //        Console.WriteLine($"Объем: {drive.TotalSize}");
        //        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
        //        Console.WriteLine($"Метка: {drive.VolumeLabel}");
        //    }
        //}

        //long test = DiskInformation.GetDirectoreCount(@"C:\", @"C:\F2");

        WriteLine($"насчитали: {DiskInformation.GetDirectoreCount(@"C:\", @"C:\F2")}");


    }

    Dictionary<string, Folder> folder = new Dictionary<string, Folder>();

    public void CreateFolder(string name)
    {
        folder.Add(name, new Folder());
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

    public static long GetDirectoreCount(string directory)
    {
        long dirCount = 0;
        if (Directory.Exists(directory))
        {
            string[] dir = Directory.GetDirectories(directory);
            string[] files = Directory.GetFiles(directory);

            dirCount = dir.Length + files.Length;
        }
        return dirCount;
    }
    public static long GetDirectoreCount(string directory, string newFolder)
    {
        long dirCount = 0;
        if (Directory.Exists(directory))
        {
            Directory.CreateDirectory(newFolder);

            string[] dir = Directory.GetDirectories(directory);
            string[] files = Directory.GetFiles(directory);

            WriteLine("Dir");
            foreach (var item in dir) { WriteLine(item); }
            WriteLine("Files");
            foreach (var item in files) { WriteLine(item); }
            
            dirCount = dir.Length + files.Length;
            WriteLine($"All:{dirCount}");
        }
        return dirCount;
    }

}

public class Folder
{
    public List<string> Files { get; set; } = new List<string>();
}

