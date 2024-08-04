namespace TPS_Insight_Hub.Models.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly HubDbContext _myDbConnection;

        public BookRepository(HubDbContext myDbConnection)
        {
            _myDbConnection = myDbConnection;

        }
        public void Create(Book book)
        {
            _myDbConnection.Books.Add(book);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = (from Obj in _myDbConnection.Books
                         where Obj.Id == id
                         select Obj).FirstOrDefault();
            if (book != null)
            {
                book.IsDeleted = true;

                _myDbConnection.SaveChanges();
            }
        }

        public List<Book>? GetAllBooks()
        {
            List<Book> books = (from Obj in _myDbConnection.Books
                                where Obj.IsDeleted != true
                                select Obj).ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = (from Obj in _myDbConnection.Books
                         where Obj.Id == id
                         select Obj).FirstOrDefault();
            return book;
        }

        public bool IsNameExist(string name)
        {
            List<Book> books = (from obj in _myDbConnection.Books select obj).ToList();
            foreach (Book u in books)
            {
                if (u.Name == name)
                {
                    if (u.IsDeleted == false) return true;
                }
            }
            return false;
        }

        public void Update(Book book)
        {
            var existingBook = _myDbConnection.Books.Find(book.Id);
            if (existingBook != null)
            {
                existingBook.Name = book.Name;
                existingBook.AuthorID= book.AuthorID;


                // Update the entity
                _myDbConnection.Update(existingBook);
                _myDbConnection.SaveChanges();
            }
        }
    }
}
