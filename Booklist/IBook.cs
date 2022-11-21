using System;
namespace Booklist
{
    public interface IBook
    {
        string Name { get; }
        List<string> Authors { get; }
        string ToString();
    }
}