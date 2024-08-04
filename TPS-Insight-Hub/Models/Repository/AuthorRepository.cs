namespace TPS_Insight_Hub.Models.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly HubDbContext _dbContext;
        public AuthorRepository(HubDbContext dbContext) 
        { 
        
            _dbContext = dbContext;
        
        }
        public void create(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public void delete(int Id)
        {
            Author author = (from obj in _dbContext.Authors

                             where obj.Id == Id
                             select obj
                             ).FirstOrDefault();

            if (author != null)
            {
                author.IsDeleted = true;
                _dbContext.SaveChanges();
            }
        }

        public bool exists(string Name)
        {
            List<Author> list = (from obj in _dbContext.Authors
                                 
                                 select obj
                                  ).ToList();
            foreach (Author author in list)
            {
                if (author.Name == Name)
                {
                    if (!author.IsDeleted) 
                        { 
                            return true;
                        }
                }

            }
                return false;
        }

        public List<Author> GetAllAuthors()
        {
            List <Author> list = (from obj in _dbContext.Authors
                                  where obj.IsDeleted == false
                                  select obj
                                  ).ToList();

            return list;
        }

        public Author getAuthorById(int id)
        {
            Author author= (from obj in _dbContext.Authors
                            
                            where obj.Id == id
                            select obj).FirstOrDefault();
            return author;
        }

        public void update(Author author)
        {
            Author existAuthor = (from obj in _dbContext.Authors

                                  where obj.Id == author.Id
                                  select obj
                             ).FirstOrDefault();

            if (existAuthor != null)
            {
                existAuthor.Name = author.Name;

                _dbContext.Update(existAuthor);
                _dbContext.SaveChanges();

            }
        }
    }
}
