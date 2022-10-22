internal class Program
{
    private static void Main(string[] args)
    {



        string strPath = @"C:\Users\Dima\Google Диск\Repos\SF Module 8\SF Module 8\8.3.1\Program.cs";
        FileWriter.SourceWriter(strPath);


    }
}

class FileWriter
{
    public static void SourceWriter(string sourcePath)
    {
        try
        {
            // Откроем файл и прочитаем его содержимое
            using (StreamReader sr = File.OpenText(sourcePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                {
                    Console.WriteLine(str);
                }
            }
        }
        catch { }
    }
}