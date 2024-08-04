namespace TPS_Insight_Hub.Models.Repository
{
    public interface IAuthorRepository
    {
        public List <Author> GetAllAuthors ();

        public void create (Author author);

        public void update (Author author);

        public void delete (int Id);

        public bool exists (String Name);

        public Author getAuthorById (int id);
    }
}
