using ReadContractData.Model;

namespace ReadContractData.Services.Readers
{
    internal class ReadDirectoryService
    {
        List<FileDetails> files = new List<FileDetails>();

        public List<FileDetails> SearchDirectory(string directory, List<string> fileTypes)
        {
            fileTypes.ForEach(fileType => {
                DirectorySearch(directory, fileType);
            });

            return files;
        }


        private void DirectorySearch(string directory, string fileType)
        {
            try
            {
                foreach (string f in Directory.GetFiles(directory, $"*{fileType}"))
                {
                    files.Add(FileDetails.CreateFrom(f, fileType));
                }

                foreach (string d in Directory.GetDirectories(directory))
                {
                    foreach (string f in Directory.GetFiles(d, $"*{fileType}"))
                    {
                        files.Add(FileDetails.CreateFrom(f, fileType));
                    }

                    foreach (string f in Directory.GetDirectories(d))
                    {
                        DirectorySearch(f, fileType);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
