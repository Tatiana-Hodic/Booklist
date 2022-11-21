using System;
namespace Booklist
{
    public class Book:BookBase
    {
        public Book(string name, string house, List<string> authors, LiteratureEnum literature, int pages, int year)
            :base(name, house, authors)
        {
            Literature = literature;
            Pages = pages;
            Year = year;
        }

        public LiteratureEnum Literature { get; private set; }

        public int Pages { get; private set; }

        public int Year { get; private set; }

        public override string ToString()
        {
            return
                base.ToString() +
                ";" +
                this.Literature.ToString() +
                ";" +
                this.Pages.ToString() +
                ";" +
                this.Year.ToString()
                ;
        }
    }
}

