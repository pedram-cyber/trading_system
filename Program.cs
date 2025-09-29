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

        Console.WriteLine("Press enter to continue...");
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

        Console.WriteLine("Press enter to continue...");
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
    Console.WriteLine("1.Add Item");
    Console.WriteLine("2.Items description");
    Console.WriteLine("3.Request Trade");
    Console.WriteLine("4.Browes Trades");
    Console.WriteLine("5.Logout");
    Console.WriteLine("6.Exit");
    Console.WriteLine(" ");

    string choice = Console.ReadLine();

    switch (choice)
    {
      case"1":

        Console.WriteLine("Item name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        items.Add(new Item(name, description, activeUser));
        Console.WriteLine("Item Added!");

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "2":

        Console.WriteLine("...Items...");
        foreach (Item item in items)
        {
          Console.WriteLine(item.ShowInfo());
        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "3":
        break;
        
      case "4":
        break;

      case "5":

        activeUser.Logout();
        Console.WriteLine("You logged out.");
        activeUser = null;

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "6":

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