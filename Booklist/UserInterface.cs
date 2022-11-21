using System;
namespace Booklist
{
    public class UserInterface
    {
        private readonly BooksManagement _management;

        public ActionEnum SelectedAction { get; private set; }

        public UserInterface(string file)
        {
            _management = new BooksManagement(file);
            Console.WriteLine("Parametrical");
            SelectAction();
        }

        public UserInterface()
        {
            _management = new BooksManagement();
            Console.WriteLine("Non parametrical");
            SelectAction();
        }

        private void SetFile(string file)
        {
            _management.SetFile(file);
            Console.WriteLine(_management.MemoryFile);
        }

        private void SelectAction()
        {
            Console.WriteLine("Select the action type from 0 to 5: set file, create a book, delete a book, paste the list of books, find a book, end the programme:");
            int actionNumber = int.Parse(Console.ReadLine());
            ActionEnum action;
            if (actionNumber == 0) action = ActionEnum.SetFile;
            else if (actionNumber == 1) action = ActionEnum.Create;
            else if (actionNumber == 2) action = ActionEnum.Delete;
            else if (actionNumber == 3) action = ActionEnum.GetAllBooks;
            else if (actionNumber == 4) action = ActionEnum.GetBook;
            else action = ActionEnum.Finish;
            switch(action)
            {
                case ActionEnum.SetFile:
                    Console.WriteLine("Set a file");
                    string file = Console.ReadLine();
                    this.SetFile(file);
                    SelectAction();
                    break;
                case ActionEnum.GetAllBooks:
                    Console.WriteLine("List of all books:");
                    foreach(var b in _management.GetBooks())
                    {
                        Console.WriteLine(b.ToString());
                    }
                    SelectAction();
                    break;
                case ActionEnum.Create:
                    Console.WriteLine("Select the name of a book and the house:");
                    string name = Console.ReadLine();
                    string house = Console.ReadLine();
                    List<string> authors = new List<string>();
                    bool addAnother = true;
                    while(addAnother)
                    {
                        Console.WriteLine("Add another author:");
                        string author = Console.ReadLine();
                        authors.Add(author);
                        Console.WriteLine("Add another author? Yes: true No: false");
                        addAnother = Convert.ToBoolean(Console.ReadLine());
                    }
                    Console.WriteLine("Select the type: book, magazine, newspaper, poster");
                    string paper = Console.ReadLine();
                    if (paper.ToLower().Contains("bo"))
                    {
                        Console.WriteLine("Select the book type:");
                        LiteratureEnum type;
                        int typeNumber = int.Parse(Console.ReadLine());
                        if (typeNumber == 0) type = LiteratureEnum.Poems;
                        else if (typeNumber == 1) type = LiteratureEnum.Novel;
                        else if (typeNumber == 2) type = LiteratureEnum.Stories;
                        else
                        {
                            Console.WriteLine("Unknown literature type");
                            type = LiteratureEnum.Unknown;
                        }
                        Console.WriteLine("Enter number of pages:");
                        int pages = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a year:");
                        int year = int.Parse(Console.ReadLine());
                        _management.AddBook(name, house, authors, type, pages, year);
                    }
                    else if(paper.ToLower().Contains("ma"))
                    {
                        Console.WriteLine("Enter a year:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a number in the given year:");
                        int number = int.Parse(Console.ReadLine());
                        _management.AddMagazine(name, house, authors, year, number);
                    }
                    else if(paper.ToLower().Contains("ne"))
                    {
                        Console.WriteLine("Enter the year:");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the month:");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the day:");
                        int day = int.Parse(Console.ReadLine());
                        _management.AddNewspaper(name, house, authors, new DateTime(year, month, day));
                    }
                    else
                    {
                        Console.WriteLine("Set a content:");
                        string content = Console.ReadLine();
                        _management.AddPoster(name, house, authors, content);
                    }
                    SelectAction();
                    break;
                case ActionEnum.Delete:
                    Console.WriteLine("Set the book name to delete");
                    string nameToDelete = Console.ReadLine();
                    _management.DeleteBook(nameToDelete);
                    SelectAction();
                    break;
                case ActionEnum.GetBook:
                    Console.WriteLine("Select the book:");
                    string autor = Console.ReadLine();
                    try
                    {
                        var b = _management.GetBooks().FindAll(o => o.Authors.Contains(autor));
                        foreach (var v in b)
                        {
                            Console.WriteLine(v.ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Author not found");
                    }
                    SelectAction();
                    break;
                case ActionEnum.Finish:
                    _management.SaveBooks();
                    Console.WriteLine("Press Enter to finish the app");
                    break;
                default: Console.WriteLine("Unknown exception");
                    break;

            }
        }
    }
}

