using System;
namespace Booklist
{
    public class BookBase
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
    }
}

