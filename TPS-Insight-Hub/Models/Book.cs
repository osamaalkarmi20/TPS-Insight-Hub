namespace TPS_Insight_Hub.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AuthorID { get; set; }   

        public Author Author { get; set; }  

        public bool IsDeleted { get; set; }

    }
}
