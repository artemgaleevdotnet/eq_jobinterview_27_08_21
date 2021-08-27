using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.DataAccess
{
    internal class FileReaderWriter : IFileReaderWriter
    {
        private static SemaphoreSlim _locker = new SemaphoreSlim(1);
        public async Task<string> Read(string filePath)
        {            
            if (!File.Exists(filePath))
            {
                //write log 

                return string.Empty;
            }
            await _locker.WaitAsync();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                using (var sr = new StreamReader(fs))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _locker.Release();
            }
        }

        public async Task Write(string filePath, string data)
        {
            await _locker.WaitAsync();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                using (var sw = new StreamWriter(fs))
                {
                    await sw.WriteAsync(data);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _locker.Release();
            }
        }
    }
}
