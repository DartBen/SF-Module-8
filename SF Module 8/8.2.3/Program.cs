using System.IO;
using System.Runtime;
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

        //WriteLine($"насчитали: {DiskInformation.CreateAndGetDirectoreCount(@"C:\", @"C:\F2")}");

        string str1 = @"C:\Users\Dima\Desktop\";
        string str2 = "newFolder";

        var pathOfFolder = DiskInformation.CreateDirectory(str1, str2);
        if (Directory.Exists(pathOfFolder)) DiskInformation.TranferToGarbage(str1, str2);


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
    public static long CreateAndGetDirectoreCount(string directory, string newFolder)
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

            //Directory.Delete(newFolder,true);
        }
        return dirCount;
    }


    public static string CreateDirectory(string directory, string newFolderName)
    {
        string result = "";
        if (Directory.Exists(directory))
        {
            try
            {
                result = directory + newFolderName;
                Directory.CreateDirectory(result);
            }
            catch { }
        }
        return result;

    }
    public static bool TranferToNewDirectory(string directory, string folder, string newPath)
    {
        bool result = false;
        DirectoryInfo dirInfo = new DirectoryInfo(directory + folder);
        try
        {
            if (dirInfo.Exists && Directory.Exists(newPath))
            {
                dirInfo.MoveTo(newPath + folder); result = true;
            }
        }
        catch { }
        return result;
    }

    public static bool TranferToGarbage(string directory, string Folder)
    {
        var Garbage = @"C:\$RECYCLE.BIN\";
        var result = TranferToNewDirectory(directory, Folder, Garbage);
        return result;
    }

}

public class Folder
{
    public List<string> Files { get; set; } = new List<string>();
}

