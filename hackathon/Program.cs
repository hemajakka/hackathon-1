namespace hackathon
{
    class Note
    {
        public int Id { get; set; } 
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

    }
    class Details
    {
        List<Note> notes = new List<Note>();
        int customerid = 1;
        
        public void AddNotes() 
        {
            try
            {
                Console.WriteLine("enter title");
                string title = Console.ReadLine();
                Console.WriteLine("enter description");
                string description = Console.ReadLine();
                int id = customerid++;
                
                DateTime date = DateTime.Now;



                notes.Add(new Note { Id = id, title = title, description = description, date = date});
            }
            catch(FormatException) 
            {
                Console.WriteLine("enter only strings");
            }
        }
        public Note ViewNote(int id)
        {
            foreach (Note note in notes)
            {
                if (note.Id == id)
                    return note;
            }
            return null;
        }
        public List<Note> ViewNotes()
        {
            return notes;
        }
        public bool UpdateNote(int id)
        {
            foreach(Note n in notes)
            {
                if(n.Id == id)
                {
                    try
                    {
                        Console.WriteLine("enter new title");
                        string title = Console.ReadLine();
                        Console.WriteLine("enter new description");
                        string description = Console.ReadLine();
                        Console.WriteLine("note details updated successfully");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("enter only strings");
                    }
                }
                return true;
            }
            return false;
        }
        public bool DeleteNote(int id)
        {
            foreach(Note note in notes)
            {
                if(note.Id == id)
                {
                    notes.Remove(note);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Details obj = new Details();
            string ans = "";
            do
            {

                Console.WriteLine("1.add note");
                Console.WriteLine("2.view note by id");
                Console.WriteLine("3.view all notes");
                Console.WriteLine("4.update note");
                Console.WriteLine("5.delete note by id");
                Console.WriteLine("select the choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            obj.AddNotes();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("enter id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            
                            Note? n = obj.ViewNote(id);
                            if (n == null)
                            {
                                Console.WriteLine("note with specific id does not exist");
                            }
                            else
                            {
                                Console.WriteLine($"{n.Id} {n.title} {n.description}{n.date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Id\t title\t description\tdate");
                            int count = 0;
                            foreach (var c in obj.ViewNotes())
                            {
                                Console.WriteLine($"{c.Id}\t\t{c.title}\t\t{c.description}\t\t{c.date}");
                                count++;
                              
                            }
                            Console.WriteLine($"Total Notes\t{count}");
                        
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter note id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (obj.UpdateNote(id))
                            {
                                Console.WriteLine("note is updated");
                            }
                            else { Console.WriteLine("note does not exist"); }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("enter note id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteNote(id))
                            {
                                Console.WriteLine("note is deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("note does not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invaild choice");
                            break;
                        }
                }
                Console.WriteLine("do you want to continue [y/n]");
                ans= Console.ReadLine();
            }while (ans.ToLower()== "y");


        }
    }
}