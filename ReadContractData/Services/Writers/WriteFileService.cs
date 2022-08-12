using ReadContractData.Model;

namespace ReadContractData.Services.Writers
{
    internal class WriteFileService
    {
        public void WriteFieldsToFile(List<FileDetails> ListOfFileDetails, string targetDirectory)
        {
            foreach (var fileDetails in ListOfFileDetails)
            {
                using (var file = File.CreateText(targetDirectory + fileDetails.Name))
                {

                    foreach (var field in fileDetails.Fields)
                    {
                        file.WriteLine(string.Join(",", field));
                    }
                }
            }
        }
    }
}
