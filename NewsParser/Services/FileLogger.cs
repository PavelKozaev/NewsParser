using NewsParser.Interfaces;

namespace NewsParser.Services
{
    public class FileLogger(string filePath) : ILogger
    {
        private readonly string _filePath = filePath;

        public void Log(string message)
        {
            File.AppendAllText(_filePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
