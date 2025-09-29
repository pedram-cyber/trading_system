using App;

List<User> users = new List<User>();
List<Item> items = new List<Item>();
List<Trade> trades = new List<Trade>();

User activeUser = null;
bool running = true;

while (running)
{
  Console.Clear();

  if (activeUser == null)
  {
    Console.WriteLine("1.Register");
    Console.WriteLine("2.Login");
    Console.WriteLine("3.Exit");
    Console.WriteLine(" ");
    Console.WriteLine("");

    string choice = Console.ReadLine();

    switch (choice)
    {
      case "1":
        Console.WriteLine("Email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();

        users.Add(new User(email, password));
        Console.WriteLine("User registered with email: " + email);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        break;

      case "2":

        Console.WriteLine("Email: ");
        email = Console.ReadLine();
        Console.WriteLine("Password: ");
        password = Console.ReadLine();

        bool loggedIn = false;
        foreach (User u in users)
        {
          if (u.TryLogin(email, password))
          {
            activeUser = u;
            loggedIn = true;
            Console.WriteLine("Login successful! Logged in as " + activeUser.Email);

            break;
          }
        }

        if (!loggedIn)
        {
          Console.WriteLine("Invalid credentials.");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
        break;

      case "3":

        running = false;

        break;

      default:

        Console.WriteLine("Invalid choice.");
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();

        break;

    }
  }
  else
  {
    Console.WriteLine("Logged in as:" + activeUser.Email);
    Console.WriteLine("1.Logout");
    Console.WriteLine("2.Exit");
    Console.WriteLine(" ");

    string choice = Console.ReadLine();

    switch (choice)
    {
      case "1":

        activeUser.Logout();
        Console.WriteLine("You logged out.");
        activeUser = null;
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        break;

      case "2":

        running = false;

        break;

      default:

        Console.WriteLine("Invalid choice.");
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();

        break;
    }
  }

}