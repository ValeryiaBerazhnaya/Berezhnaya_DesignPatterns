using Task3;

var user = new User { Name = "Alice", IsRegistered = true, HasAccess = true };
IBook book = new BookProxy(user);

Console.WriteLine(book.GetContent());

var badUser = new User { Name = "Bob", IsRegistered = false, HasAccess = false };
IBook book2 = new BookProxy(badUser);

Console.WriteLine(book2.GetContent());
