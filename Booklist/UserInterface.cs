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
            Console.WriteLine("parametricky");
            SelectAction();
        }

        public UserInterface()
        {
            _management = new BooksManagement();
            Console.WriteLine("bezparametricky");
            SelectAction();
        }

        private void SetFile(string file)
        {
            _management.SetFile(file);
            Console.WriteLine(_management.File);
        }

        private void SelectAction()
        {
            Console.WriteLine("Vyberte typ akce od 0 do 3: nastavit soubor, vytvorit knihu, vymazat knihu, vypsat seznam knih:");
            int actionNumber = int.Parse(Console.ReadLine());
            ActionEnum action;
            if (actionNumber == 0) action = ActionEnum.SetFile;
            else if (actionNumber == 1) action = ActionEnum.Create;
            else if (actionNumber == 2) action = ActionEnum.Delete;
            else if (actionNumber == 3) action = ActionEnum.GetAllBooks;
            else action = ActionEnum.Finish;
            switch(action)
            {
                case ActionEnum.SetFile:
                    Console.WriteLine("Nastavte nazev souboru");
                    string file = Console.ReadLine();
                    this.SetFile(file);
                    SelectAction();
                    break;
                case ActionEnum.GetAllBooks:
                    Console.WriteLine("Seznam vsech knih:");
                    foreach(var b in _management.GetBooks())
                    {
                        Console.WriteLine(b.ToString());
                    }
                    break;
                case ActionEnum.Create:
                    Console.WriteLine("Vyberte nazev noveho souboru");
                    string name = Console.ReadLine();
                    Console.WriteLine("Vyberte typ literatury: 0 - poems, 1 - novel, 2 - stories");
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
                    _management.AddBook(type, name);
                    SelectAction();
                    break;
                case ActionEnum.Delete:
                    Console.WriteLine("Zadejte jmeno knihy k vymazani");
                    string nameToDelete = Console.ReadLine();
                    _management.DeleteBook(nameToDelete);
                    SelectAction();
                    break;
                case ActionEnum.Finish:
                    Console.WriteLine("Press Enter to finish the app");
                    break;
                default: Console.WriteLine("Unknown exception");
                    break;

            }
        }
    }
}

