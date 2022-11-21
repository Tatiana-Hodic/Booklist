using System;
using System.Xml.Linq;

namespace Booklist
{
    public class Newspaper : BookBase
    {
        public Newspaper(string name, string house, List<string> authors, DateTime dateAndYear)
            : base(name, house, authors)
        {
            DateAndYear = dateAndYear;
        }

        public DateTime DateAndYear { get; private set; }

        public override string ToString()
        {
            return
                base.ToString() +
                ";" +
                this.DateAndYear.ToString("MM/dd/yyyy")
                ;
        }
    }
}

