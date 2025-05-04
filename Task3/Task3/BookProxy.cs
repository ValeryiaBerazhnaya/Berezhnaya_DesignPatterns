namespace Task3
{
    public class BookProxy : IBook
    {
        private RealBook _realBook;
        private User _user;

        public BookProxy(User user)
        {
            _user = user;
        }

        public string GetContent()
        {
            if (!_user.IsRegistered)
            {
                return "Access denied: User is not registered.";
            }

            if (!_user.HasAccess)
            {
                return "Access denied: User does not have access rights.";
            }

            if (_realBook == null)
            {
                _realBook = new RealBook();
            }

            return _realBook.GetContent();
        }
    }

}
