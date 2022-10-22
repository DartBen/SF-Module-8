using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {



        string strPath = @"C:\Users\Dima\Google Диск\Repos\SF Module 8\SF Module 8\8.3.2\Program.cs";
        FileWriter.SourceWriterOnConsoleWithDate(strPath);


    }
}

class FileWriter
{
    public static void SourceWriterOnConsole(string sourcePath)
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


    public static void SourceWriterOnConsoleWithDate(string sourcePath)
    {
        try
        {
            DateTime dtNow = DateTime.Now;
            string strTmp = dtNow.ToString();

            var fileInfo = new FileInfo(sourcePath);
            using (StreamWriter sw = fileInfo.AppendText())
            {
                sw.WriteLine("//Время запуска: " + strTmp);

            }

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
//Время запуска: 22.10.2022 21:15:30
