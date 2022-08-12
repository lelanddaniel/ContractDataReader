using ReadContractData.Model;
using System.Text.RegularExpressions;

namespace ReadContractData.Services.Readers
{
    public class ReadRazorFilesService
    {
        public List<FileDetails> ReadRazorFormFields(List<FileDetails> files)
        {
            var allFileDetails = new List<FileDetails>();
            try
            {
                foreach (FileDetails file in files)
                {
                    file.Fields = GetFileModelBinding(file);
                    file.Name = GetFilesName(file);
                    allFileDetails.Add(file);
                }
            }
            catch (Exception ex)
            {

            }

            return allFileDetails;
        }

        private string GetFilesName(FileDetails fileDetails)
        {
            var filePath2 = fileDetails.Path.Split("\\");
            var fileName = filePath2[filePath2.Length - 1].Split(".")[0];
            var fileDirectory = filePath2[filePath2.Length - 2];
            return fileDirectory + " - " + fileName + ".txt";
        }

        private List<string> GetFileModelBinding(FileDetails fileDetails)
        {
            string pattern = @"([a-zA-Z]+(\.[a-zA-Z]+)+)";
            var modelLines = new List<string>();

            foreach (var line in File.ReadAllLines(fileDetails.Path))
            {
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    if (match.Success && match.Groups.Count > 0)
                    {
                        if (match.Groups[1].Value.Contains("Model."))
                        {
                            modelLines.Add(RemoveModelFromLine(match.Groups[1].Value));
                        }
                    }
                }
            }

            return modelLines.Distinct().OrderBy(line => line).ToList();
        }

        private string RemoveModelFromLine(string line)
        {
            return line.Replace("Model.", "");
        }
    }
}
