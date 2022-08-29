using iTextSharp.text.pdf;
using ReadContractData.Model;
using System.Text.RegularExpressions;

namespace ReadContractData.Services.Readers
{
    public class ReadPdfFilesService
    {
        public List<FileDetails> ReadPDFsFormFields(List<FileDetails> files)
        {
            var allFileDetails = new List<FileDetails>();
            try
            {
                foreach (FileDetails file in files)
                {
                    var formFields = GetPDFsFormFields(file);
                    file.Fields = GetListOfFormFieldNames(formFields);
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

        private IDictionary<string, AcroFields.Item> GetPDFsFormFields(FileDetails fileDetails)
        {
            PdfReader pdfReader = new PdfReader(fileDetails.Path);
            return pdfReader.AcroFields.Fields;
        }


        private List<string> GetListOfFormFieldNames(IDictionary<string, AcroFields.Item> formFields)
        {
            var fields = new List<string>();

            foreach (KeyValuePair<string, AcroFields.Item> field in formFields)
            {
                var fieldName = Regex.Replace(field.Key, "\\#[0-9]+", "");
                fields.Add(fieldName);
            }

            return fields.Distinct().OrderBy(line => line).ToList();
        }
    }
}
