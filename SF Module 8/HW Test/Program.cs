
internal class Program
{
    private static void Main(string[] args)
    {

        string str = "C:\\Users\\Dima\\Desktop\\dmitriy.ryabov-client-Dmitriy_Ryabov (1)";
        long l = 0;
        DirectoryInfo directoryInfo = new DirectoryInfo(str);

        l = Class1.DirSize(str);
        Class1.DirDeleteOld(str, 30);
        //Class1.DirDeleteOld(directoryInfo, 30);

        Console.WriteLine(l);
    }
}

public class Class1
{
    public static long DirSize(string path)
    {
        long size = 0;
        try
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if (directory.Exists)
            {
                FileInfo[] fi = directory.GetFiles();
                foreach (FileInfo fi2 in fi)
                {
                    //Console.WriteLine(fi2.FullName);
                    size += fi2.Length;
                }

                DirectoryInfo[] dir = directory.GetDirectories();
                foreach (DirectoryInfo di2 in dir)
                {
                    //Console.WriteLine(di2.FullName);
                    size += DirSize(di2.FullName);
                }
            }
            else { Console.WriteLine("Ссылка на директорию отсутствует"); }
        }
        catch { return size; }
        return size;
    }

    public static void DirDeleteOld(DirectoryInfo dir, int time)
    {
        TimeSpan.FromMinutes(time);

        DateTime checkTime = DateTime.Now - TimeSpan.FromMinutes(time);
        Console.WriteLine("метод удаления");

        FileInfo[] fi = dir.GetFiles();
        if (dir.Exists)
        {
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
                bool tmpBool = di2.LastAccessTime < checkTime;
                DirDeleteOld(di2, time);

                //проверка что текущая дериктория пуста
                FileInfo[] fi2 = di2.GetFiles();
                if ((fi2.Length <= 0 || fi2 == null) && tmpBool)
                {
                    Console.WriteLine("Удаление:" + di2.FullName);
                    di2.Delete();
                }
            }
        }
        else
        {
            Console.WriteLine("Ссылка на директорию отсутствует");
        }
    }

    public static void DirDeleteOld(string path, int time)
    {
        TimeSpan.FromMinutes(time);

        DateTime checkTime = DateTime.Now - TimeSpan.FromMinutes(time);
        Console.WriteLine("метод удаления");

        DirectoryInfo directory = new DirectoryInfo(path);

        FileInfo[] fi = directory.GetFiles();
        if (directory.Exists)
        {
            foreach (FileInfo fi2 in fi)
            {
                if (fi2.LastAccessTime < checkTime)
                {
                    Console.WriteLine("Удаление:" + fi2.FullName);
                    fi2.Delete();
                }
            }

            DirectoryInfo[] di = directory.GetDirectories();
            foreach (DirectoryInfo di2 in di)
            {
                bool tmpBool = di2.LastAccessTime < checkTime;
                DirDeleteOld(di2, time);

                //проверка что текущая дериктория пуста
                FileInfo[] fi2 = di2.GetFiles();
                if ((fi2.Length <= 0 || fi2 == null) && tmpBool)
                {
                    Console.WriteLine("Удаление:" + di2.FullName);
                    di2.Delete();
                }
            }
        }
        else
        {
            Console.WriteLine("Ссылка на директорию отсутствует");
        }
    }


    public static void CheckDeleteCheck(string path, int time)
    {
        int deletedFilesCount=0;

        long lCheck1 = DirSize(path);
        DirDeleteOld(path, 30, ref deletedFilesCount);
        long lCheck2 = DirSize(path);
        long lCheck3 = lCheck1 - lCheck2;


        Console.WriteLine($"Вес папки до удаления:\t{lCheck1}");
        Console.WriteLine($"Вес папки после удаления:\t   {lCheck1}");
        Console.WriteLine($"Удалено:\t{deletedFilesCount} файлов. Освобожденно {lCheck1} байт");
    }


    public static void DirDeleteOld(string path, int time, ref int deletedCount)
    {
        TimeSpan.FromMinutes(time);

        DateTime checkTime = DateTime.Now - TimeSpan.FromMinutes(time);
        Console.WriteLine("метод удаления");

        DirectoryInfo directory = new DirectoryInfo(path);

        FileInfo[] fi = directory.GetFiles();
        if (directory.Exists)
        {
            foreach (FileInfo fi2 in fi)
            {
                if (fi2.LastAccessTime < checkTime)
                {
                    Console.WriteLine("Удаление:" + fi2.FullName);
                    //fi2.Delete();
                    deletedCount++;
                }
            }

            DirectoryInfo[] di = directory.GetDirectories();
            foreach (DirectoryInfo di2 in di)
            {
                bool tmpBool = di2.LastAccessTime < checkTime;
                DirDeleteOld(di2, time);

                //проверка что текущая дериктория пуста
                FileInfo[] fi2 = di2.GetFiles();
                if ((fi2.Length <= 0 || fi2 == null) && tmpBool)
                {
                    Console.WriteLine("Удаление:" + di2.FullName);
                    //di2.Delete();
                    deletedCount++;
                }
            }
        }
        else
        {
            Console.WriteLine("Ссылка на директорию отсутствует");
        }

 
    }

    public static bool DirEmptyChecker(DirectoryInfo directoryInfo)
    {
        bool result = false;



        return result;
    }
}

