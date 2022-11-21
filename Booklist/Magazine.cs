using System;
using System.Xml.Linq;

namespace Booklist
{
    public class Magazine : BookBase
    {
        public Magazine(string name, string house, List<string> authors, int year, int number)
            : base(name, house, authors)
        {
            Year = year;
            Number = number;
        }

        public int Year { get; private set; }
        public int Number { get; private set; }

        public override string ToString()
        {
            return
                base.ToString() +
                ";" +
                this.Number.ToString() +
                ";" +
                this.Year.ToString()
                ;
        }
    }
}

