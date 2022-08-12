namespace ReadContractData.Model
{
    public class FileDetails
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Path { get; set; }
        public List<string> Fields { get; set; } = new List<string>();
        public bool IsPdf => Type.Contains(".pdf");
        public bool IsRazor => Type.Contains(".cshtml");

        public static FileDetails CreateFrom(string Path, string Type)
        {
            return new FileDetails()
            {
                Path = Path,
                Type = Type,
            };
        }
    }
}
