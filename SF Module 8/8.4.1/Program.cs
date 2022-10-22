internal class Program
{
    private static void Main(string[] args)
    {
        string strPath = @"C:\Users\Dima\Desktop\BinaryFile.bin";


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
                using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine(binaryReader.ReadString());
                }
            }
            catch { }
        }
    }
}