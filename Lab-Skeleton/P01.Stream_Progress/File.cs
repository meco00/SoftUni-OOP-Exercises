namespace P01.Stream_Progress
{
    public class File:StreamProgressInfo
    {
        private string name;

        public File(string name, int length, int bytesSent):base(length,bytesSent)
        {
            this.name = name;
          
        }

       
    }
}
