
internal class Program
{
    private static void Main(string[] args)
    {

        string str = "C:\\Users\\Dima\\Desktop\\dmitriy.ryabov-client-Dmitriy_Ryabov (1)";
        long l = 0;
        DirectoryInfo directoryInfo = new DirectoryInfo(str);

        l = Class1.DirSize(directoryInfo);
        Class1.DirDeleteOld(directoryInfo, 30);

        Console.WriteLine(l);
    }
}

public class Class1
{
    public static long DirSize(DirectoryInfo dir)
    {
        long size = 0;

        FileInfo[] fi = dir.GetFiles();
        foreach (FileInfo fi2 in fi)
        {
            Console.WriteLine(fi2.FullName);
            size += fi2.Length;
        }

        DirectoryInfo[] di = dir.GetDirectories();
        foreach (DirectoryInfo di2 in di)
        {
            Console.WriteLine(di2.FullName);
            size += DirSize(di2);
        }
        return size;
    }

    public static void DirDeleteOld(DirectoryInfo dir, int time)
    {
        TimeSpan.FromMinutes(time);

        DateTime checkTime = DateTime.Now - TimeSpan.FromMinutes(time);
        Console.WriteLine("метод удаления");

        FileInfo[] fi = dir.GetFiles();
        foreach (FileInfo fi2 in fi)
        {
            if (fi2.LastAccessTime < checkTime)
            {
                Console.WriteLine("Удаление:" + fi2.FullName);
                fi2.Delete();
            }
        }

        DirectoryInfo[] di = dir.GetDirectories();
        foreach (DirectoryInfo di2 in di)
        {
            DirDeleteOld(di2, time);

            //проверка что текущая дериктория пуста
            FileInfo[] fi2 = di2.GetFiles();
            if (fi2.Length <= 0)
            //&& di2.LastAccessTime < checkTime) 
            {
                Console.WriteLine("Удаление:" + di2.FullName);
                di2.Delete();
            }
        }
    }

    public static bool DirEmptyChecker(DirectoryInfo directoryInfo)
    {
        bool result = false;



        return result;
    }
}

