internal class Program
{
    private static void Main(string[] args)
    {
        string strPath = @"C:\Users\Dima\Desktop\BinaryFile.bin";
        string str = $"Файл изменен {DateTime.Now} на компьютере {Environment.OSVersion}";

        BinaryTest.AddLastChange(strPath, str);
        BinaryTest.ReadFile(strPath);

    }
}



class BinaryTest
{
    public static void ReadFile(string path)
    {
        FileInfo fileInfo = new FileInfo(path);

        if (fileInfo.Exists)
        {
            try
            {
                using (BinaryReader stream = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine(stream.ReadString());
                }
            }
            catch { }
        }
    }

    public static void AddLastChange(string path, string message)
    {
        FileInfo fileInfo = new FileInfo(path);

        if (fileInfo.Exists)
        {
            try
            {
                using (BinaryWriter stream = new BinaryWriter(File.Open(path, FileMode.Open)))
                {
                    stream.Write(message);
                }
            }
            catch { }
        }
    }

}