// See https://aka.ms/new-console-template for more information
using Booklist;

Console.WriteLine("Program started");

Console.WriteLine("File to load:");

string file = Console.ReadLine();

if (file == "")
{
    UserInterface session = new UserInterface();
}
else
{
    UserInterface session = new UserInterface(file);
}
Console.ReadKey();