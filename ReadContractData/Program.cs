// See https://aka.ms/new-console-template for more information
using ReadContractData.Services.Readers;
using ReadContractData.Services.Writers;

ReadDirectoryService readDirectory = new ReadDirectoryService();
WriteFileService writeFile = new WriteFileService();
ReadFilesService readFile = new ReadFilesService();

List<string> fileTypes = new List<string>() { ".cshtml", ".pdf" };
string fileSaveDirectory = @"C:\Users\LDaniel\Desktop\Contracts\TextDocs\";
string targetDirectory = @"C:\Users\LDaniel\Desktop\Contracts\Contracts";

var files = readDirectory.SearchDirectory(targetDirectory, fileTypes);

var fileDetailList = readFile.ReadFileData(files);

writeFile.WriteFieldsToFile(fileDetailList, fileSaveDirectory);