namespace WindowsStore.Exceptions
{
    public class FileMissingCustomException : System.Exception
    {
        public FileMissingCustomException(string fileName) : base (string.Format("File is missing from the app data. {0}", fileName)) { }
    }
}