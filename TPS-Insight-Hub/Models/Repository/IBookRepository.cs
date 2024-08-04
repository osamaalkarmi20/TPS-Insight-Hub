namespace TPS_Insight_Hub.Models.Repository
{
    public interface IBookRepository
    {
        public List<Book>? GetAllBooks();

        public void Create(Book book);

        public void Delete(int id);
        public void Update(Book book);
        public Book GetBookById(int id);
        public bool IsNameExist(String name);

    }
}
