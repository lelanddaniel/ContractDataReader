using ReadContractData.Model;

namespace ReadContractData.Services.Readers
{
    public class ReadFilesService
    {
        ReadPdfFilesService readPdfFiles = new ReadPdfFilesService();
        ReadRazorFilesService readRazorFiles = new ReadRazorFilesService();

        public List<FileDetails> ReadFileData(List<FileDetails> files)
        {
            var pdfFiles = readPdfFiles.ReadPDFsFormFields(files.FindAll(file => file.IsPdf)).ToList();
            var razorFiles = readRazorFiles.ReadRazorFormFields(files.FindAll(file => file.IsRazor)).ToList();

            return pdfFiles.Concat(razorFiles).ToList();
        }
    }
}
