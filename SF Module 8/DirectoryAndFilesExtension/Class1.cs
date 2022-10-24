namespace DirectoryAndFilesExtension
{
    public class Class1
    {
        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;

            FileInfo[] fi = dir.GetFiles();
            foreach (FileInfo fi2 in fi)
            {
                size+=fi2.Length;
            }

            DirectoryInfo[] di = dir.GetDirectories();
            foreach (DirectoryInfo di2 in di)
            {
                size += DirSize(di2);
            }
            return size;
        }

        public static void DirDeleteOld(DirectoryInfo dir,int time)
        {
            TimeSpan.FromMinutes(time);

            FileInfo[] fi = dir.GetFiles();
            foreach (FileInfo fi2 in fi)
            {
                DateTime checkTime = DateTime.Now-TimeSpan.FromMinutes(time);
               if(fi2.LastAccessTime < checkTime)
                {
                    fi2.Delete();
                }
            }

            DirectoryInfo[] di = dir.GetDirectories();
            foreach (DirectoryInfo di2 in di)
            {
               
            }
        }

    }
}