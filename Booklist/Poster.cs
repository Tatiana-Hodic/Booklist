using System;
namespace Booklist
{
    public class Poster : BookBase
    {
        public Poster(string name, string house, List<string> authors, string content)
            : base(name, house, authors)
        {
            Content = content;
        }

        public string Content { get; private set; }

        public override string ToString()
        {
            return
                base.ToString() +
                ";" +
                this.Content
                ;
        }
    }
}

