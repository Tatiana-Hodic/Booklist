using System;
using System.IO;

namespace Booklist
{
    public class BooksManagement
    {
        private List<IBook> _books { get; set; }

        private void LoadBooks()
        {
            if (File.Exists(this.MemoryFile))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(this.MemoryFile))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                LineToIBook(line);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                File.WriteAllText(this.MemoryFile, "");
            }
        }

        public void SaveBooks()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(MemoryFile))
                {
                    foreach (var b in this._books)
                    {
                        string line = b.ToString();
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<IBook> GetBooks()
        {
            return this._books;
        }

        public string MemoryFile { get; private set; }

        public BooksManagement()
        {
            _books = new List<IBook>();
            MemoryFile = "";
        }

        public BooksManagement(string file)
        {
            MemoryFile = file;
            _books = new List<IBook>();
            this.LoadBooks();
        }

        public void SetFile(string file)
        {
            MemoryFile = file;
            this.LoadBooks();
        }

        public void AddBook(string name, string house, List<string> authors, LiteratureEnum literature, int pages, int year)
        {
            _books.Add(new Book(name, house, authors, literature, pages, year));
        }

        public void AddMagazine(string name, string house, List<string> authors, int year, int number)
        {
            _books.Add(new Magazine(name, house, authors, year, number));
        }

        public void AddPoster(string name, string house, List<string> authors, string content)
        {
            _books.Add(new Poster(name, house, authors, content));
        }

        public void AddNewspaper(string name, string house, List<string> authors, DateTime dateAndYear)
        {
            _books.Add(new Newspaper(name, house, authors, dateAndYear));
        }

        public void DeleteBook(string name)
        {
            _books.RemoveAll(o => o.Name == name);
        }

        private void LineToIBook(string line)
        {
            string[] props = line.Split(";");
            string name = props[0];
            string house = props[1];
            List<string> autors = props[2].Split(",").ToList();

            if (props.Length == 6)
            {
                LiteratureEnum literature;

                if (props[3].Contains("Novel")) literature = LiteratureEnum.Novel;
                else if (props[3].Contains("Poems")) literature = LiteratureEnum.Poems;
                else if (props[3].Contains("Stories")) literature = LiteratureEnum.Stories;
                else literature = LiteratureEnum.Unknown;
                Book book = new Book(
                    name,
                    house,
                    autors,
                    literature,
                    int.Parse(props[4]),
                    int.Parse(props[5])
                    );
                this._books.Add(book);
            }
            else if (props.Length == 5)
            {
                Magazine magazine = new Magazine(
                    name,
                    house,
                    autors,
                    int.Parse(props[3]),
                    int.Parse(props[4])
                    );
                this._books.Add(magazine);
            }
            else if (props.Length == 4)
            {
                DateTime dateValue;
                if (DateTime.TryParse(props[3], out dateValue))
                {
                    Newspaper newspaper = new Newspaper(
                        name,
                        house,
                        autors,
                        dateValue
                        );
                    this._books.Add(newspaper);
                }
                else
                {
                    Poster poster = new Poster(
                        name,
                        house,
                        autors,
                        props[3]
                        );
                    this._books.Add(poster);
                }
                
            }
            else
            {
                throw new Exception("Unknown title type");
            }
        }
    }
}

