namespace dz6
{
    internal class Program
    {
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime Date { get; set; }

            public Book(string title, string author, DateTime date) { Title = title; Author = author; Date = date; }
            public override string ToString() { return $"{Title} by {Author} | {Date.ToString("dd.MM.yyyy")}"; }

            public static bool operator ==(Book op1, Book op2)
            {
                return op1.Title.ToLower() == op2.Title.ToLower() && op1.Author.ToLower() == op2.Author.ToLower();
            }
            public static bool operator !=(Book op1, Book op2)
            {
                return !(op1 == op2);
            }
        }

        class BookList
        {
            private Book[] list;

            public void Add(Book book)
            {
                if (list == null)
                {
                    list = new Book[] { book };
                }
                else
                {
                    Book[] t = new Book[list.Length+1];
                    list.CopyTo(t, 0);
                    t[list.Length] = book;
                    list = t;
                }

                }
            public void Remove(Book book)
            {
                if (Contains(book))
                {
                    Book[] t = new Book[list.Length - 1 ];
                    int j = 0;
                    for (int i = 0; i < list.Length; i++) 
                    {
                        if (list[i] != book) { t[j] = list[i]; j++; } 
                    }

                    list = t;
                }
            }
            public bool Contains(Book book) 
            {
                foreach (var item in list)
                {
                    if (item == book) { return true; }
                }
                return false;
            }

            public int Count() { return list.Length; }

            public void Print()
            {
                foreach (var item in list)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine(item.ToString());
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------\n\n");
            }

            static public BookList operator +(BookList l, Book r)
            {
                l.Add(r);
                return l;
            }
            static public BookList operator -(BookList l, Book r)
            {
                l.Remove(r);
                return l;
            }

            public Book this[int index]
            {
                get
                {
                    if (index < 0 || index >= list.Length) { throw new IndexOutOfRangeException(); }
                    return list[index];
                }
                set
                {
                    if (index < 0 || index >= list.Length) { throw new IndexOutOfRangeException(); }
                    list[index] = value;
                }
            }
        }


        static void Main(string[] args)
        {
            BookList booklist = new BookList();
            Book book = new Book("123", "321", DateTime.Parse("04.07.2019"));
            booklist.Add(new Book("Book 1", "Author", DateTime.Today));
            booklist.Add(new Book("Book 2", "Author", DateTime.Today));
            booklist.Add(new Book("Book 3", "Author", DateTime.Today));
            Console.WriteLine(booklist.Count());
            booklist.Print();

            booklist[0] = book;
            Console.WriteLine(booklist[0]);

            Console.WriteLine(booklist.Contains(book));
            booklist.Remove(book);
            Console.WriteLine(booklist.Contains(book));
            Console.WriteLine("\n");

            Console.WriteLine(booklist.Count());
            booklist.Print();
        }
    }
}
