using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Tests.Common.Interfaces
{
    public abstract class DependencyTestBase : IDisposable
    {
        protected IServiceScope _serviceScope;
        protected List<string> filesCreated;
        protected const string DEFAULT_API_URL = "https://api.testnet.shimmer.network";
        protected const string DEFAULT_FAUCET_URL = @"https://faucet.testnet.shimmer.network";
        protected const string ANOTHER_WALLET_ADDRESS = "rms1qz8wf6jrchvsfmcnsfhlf6s53x3u85y0j4hvwth9a5ff3xhrxtmvvyc9ae7";
        protected const int SLEEP_DURATION_SECONDS_TRANSACTION = 15;
        protected const int SLEEP_DURATION_SECONDS_FAUCET = 30;
        protected const int SLEEP_DURATION_SECONDS_API_RATE_LIMIT = 0;

        private void DeleteStrongholdAndDatabaseFiles()
        {
            foreach (string filename in filesCreated)
            {
                if (Directory.Exists(filename))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(filename);
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    Directory.Delete(filename);
                }
                else //it is just a file
                    File.Delete(filename);
            }
        }
        private string GetRandomFileName(int lengthLimit = 8)
        {
            string path = Path.GetRandomFileName().Replace(".", "");
            return path.Substring(0, lengthLimit);

        }

        private string GetRandomStrongholdFilename() => $"{GetRandomFileName()}.stronghold";
        private string GetRandomDatabaseFilename() => $"{GetRandomFileName()}.db";

        public void Dispose()
        {
            _serviceScope.Dispose();

            //Force garbage collection
            GC.Collect();

            //Give enough time for services to close
            Thread.Sleep(100);

            DeleteStrongholdAndDatabaseFiles();
        }
    }
}
