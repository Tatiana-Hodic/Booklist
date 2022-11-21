using System;
namespace Booklist
{
    public class BookBase:IBook
    {
        public BookBase()
        {
            Authors = new List<string>();   
        }

        public BookBase(string name, string house, List<string> authors)
        {
            Name = name;
            HouseOfPublication = house;
            Authors = authors;
        }

        public string Name { get; private set; }
        public string HouseOfPublication { get; set; }
        public List<string> Authors { get; private set; }

        public override string ToString()
        {
            var authors = this.Authors.Aggregate((a, b) => a + "," + b);
            return
                this.Name +
                ";" +
                this.HouseOfPublication +
                ";" +
                authors.ToString();
        }
    }
}

