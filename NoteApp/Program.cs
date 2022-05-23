using System;

namespace NoteApp
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen in der Notiz-App");
            Console.WriteLine();

            Console.WriteLine("Was möchtest du tun?");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("(1) - Notiz schreiben; (2) - Notizen ansehen; (3) - Notiz bearbeiten; (4) - Notiz löschen");
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Console.WriteLine("Notiz schreiben...");
                        CreateNote();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine();
                        ReadNotes();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine();
                        //Console.WriteLine("WIP");
                        EditNotes();
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine();
                        DeleteNotes();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Zu dumm oder was?!?!");
                        break;
                }
            }
        }

        static void CreateNote()
        {
            Console.WriteLine("Titel eingeben: ");
            string titleInput = Console.ReadLine();
            if (titleInput == "") titleInput = "Neue Notiz";

            Console.WriteLine("Content eingeben: ");
            string contentInput = Console.ReadLine();
            if (contentInput == "") contentInput = "Neue Notiz";

            Operations.NewNote(new Note() { Title = titleInput, Content = contentInput });
        }

        static void ReadNotes()
        {
            Console.WriteLine("Notizen:");
            Operations.ShowNotes();
        }

        static void EditNotes()
        {
            Console.WriteLine("Welche Notiz möchtest du bearbeiten?");

            var UserInput = Console.ReadKey(true);
            int item;

            if (char.IsDigit(UserInput.KeyChar))
            {
                item = int.Parse(UserInput.KeyChar.ToString());
            }
            else
            {
                item = -1;
                Console.WriteLine("Du hast keine Zahl eingegeben!");
            }

            Console.WriteLine("Neuen Titel eingeben: ");
            string titleInput = Console.ReadLine();
            if (titleInput == "") titleInput = "Neue Notiz";

            Console.WriteLine("Neuen Content eingeben: ");
            string contentInput = Console.ReadLine();
            if (contentInput == "") contentInput = "Neue Notiz";

            Operations.EditNote(item, new Note() { Title = titleInput, Content = contentInput });

        }

        static void DeleteNotes()
        {
            Console.WriteLine("Welche Notiz möchtest du löschen?");

            var UserInput = Console.ReadKey(true);
            int item;

            if (char.IsDigit(UserInput.KeyChar))
            {
                item = int.Parse(UserInput.KeyChar.ToString());
            }
            else
            {
                item = -1;
                Console.WriteLine("Du hast keine Zahl eingegeben!");
            }

            Operations.DeleteNote(item);
        }
    }

    class Note
    {
        private string _title;
        private string _content;

        public string Title
        {
            get => _title;
            set => _title = value;
        }
        public string Content
        {
            get => _content;
            set => _content = value;
        }

        public override string ToString()
        {
            return "Title: " + Title + "    Content: " + Content;
        }
    }

    class Operations
    {
        public static List<Note> NoteList = new();

        public static void NewNote(Note note)
        {
            NoteList.Add(note);
        }

        public static void EditNote(int item, Note newNote)
        {
            item -= 1;
            Note note = NoteList[item];
            int index = NoteList.IndexOf(note);
            NoteList[item] = newNote;
            Console.WriteLine();
            Console.WriteLine("Notiz bearbeitet!" + "\nNeue Notiz:" + "\nTitel: " + newNote.Title + "\nContent: " + note.Content);
        }

        public static void DeleteNote(int item)
        {
            item -= 1;
            Note note = NoteList[item];
            int index = NoteList.IndexOf(note);
            NoteList.RemoveAt(index);
            Console.WriteLine("Notiz gelöscht!");
        }

        public static void ShowNotes()
        {
            foreach (Note note in NoteList)
            {
                int listNo = NoteList.IndexOf(note) + 1;
                Console.WriteLine("Nr. " + listNo + ": " + note);
            }
        }
    }
}