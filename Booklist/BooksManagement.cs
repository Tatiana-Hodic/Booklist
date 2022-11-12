using System;
namespace Booklist
{
    public class BooksManagement
    {
        private List<IBook> _books { get; set; }

        private void LoadBooks(string file)
        {
            //to be implemented
        }

        public List<IBook> GetBooks()
        {
            return this._books;
        }

        public string File { get; private set; }

        public BooksManagement()
        {
            _books = new List<IBook>();
            File = "";
        }

        public BooksManagement(string file)
        {
            File = file;
            _books = new List<IBook>();
            this.LoadBooks(file);
        }

        public void SetFile(string file)
        {
            File = file;
            this.LoadBooks(file);
        }

        public void AddBook(LiteratureEnum type, string name)
        {
            switch(type)
            {
                //to be implemented
            }
        }

        public void DeleteBook(string name)
        {
            _books.RemoveAll(o => o.Name == name);
        }
    }
}

