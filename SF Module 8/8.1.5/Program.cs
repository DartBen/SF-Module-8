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
}

public class Folder
{
    public List<string> Files { get; set; } = new List<string>();
}

