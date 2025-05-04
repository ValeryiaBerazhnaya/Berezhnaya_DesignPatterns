namespace Task3
{
    public class RealBook : IBook
    {
        private string _content;

        public RealBook()
        {
            Console.WriteLine("Loading book content from database...");
            _content = "This is the content of the book.";
        }

        public string GetContent()
        {
            return _content;
        }
    }
}
