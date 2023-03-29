namespace employeeProject.Models
{
    public class Files
    {
        public int Id { get; set; }

        public string File_Name { get; set; }
        
        public int Uploaded_By_id { get; set; }
        
        public string Uploaded_To_Folder { get; set; }
        
        public string Uploaded_Path { get; set; }

        /*
         *           File_Name = file_Name,
                     Uploaded_By_id = 1,
                     Uploaded_To_Folder= uploaded_by_name,
                     Uploaded_Path = path,
         * 
         */
    }
}
