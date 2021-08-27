using System.Threading.Tasks;

namespace Interview.DataAccess
{
    public interface IFileReaderWriter
    {
        Task<string> Read(string filePath);
        Task Write(string filePath, string data);
    }
}
