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
        foreach (User user in users)
        {
          if (user.TryLogin(email, password))
          {
            activeUser = user;
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
    foreach (User user in users)
    {
      Console.WriteLine(user.ShowInfo());
    }
    Console.WriteLine(" ");
    Console.WriteLine("Logged in as:" + activeUser.Email);
    Console.WriteLine(" ");
    Console.WriteLine("1.Add Item");
    Console.WriteLine("2.Items description");
    Console.WriteLine("3.Request Trade");
    Console.WriteLine("4.Browes Trades");
    Console.WriteLine("5.Accept Trade");
    Console.WriteLine("6.Deny Trade");
    Console.WriteLine("7.Logout");
    Console.WriteLine("8.Exit");
    Console.WriteLine(" ");

    string choice = Console.ReadLine();

    switch (choice)
    {
      case"1": //Add Item

        Console.WriteLine("Item name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        items.Add(new Item(name, description, activeUser));
        Console.WriteLine("Item Added!");

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "2": //Items description

        Console.WriteLine("...Items...");
        foreach (Item item in items)
        {
          Console.WriteLine(item.ShowInfo());
        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "3": //Request Trade

        Console.Write("Receiver email: ");
        string recv = Console.ReadLine();

        User receiver = null;
        foreach (User user in users)
        {
          if (user.Email == recv)
          {
            receiver = user;
            break;
          }
        }

        if (receiver == null)
        {
          Console.WriteLine("User not found.");
        }
        else
        {
          trades.Add(new Trade(trades.Count + 1, activeUser, receiver, new List<Item>()));
          Console.WriteLine("Trade request sent!");
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        break;

      case "4": //Browes Trades

        Console.WriteLine("--- Trades ---");
        foreach (Trade trade in trades)
        {
          Console.WriteLine(trade.ShowInfo());
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        break;

      case"5": //Accept Trade

        Console.Write("Enter Trade Id to accept: ");
        string accStr = Console.ReadLine();
        int accId = 0;
        int.TryParse(accStr, out accId);

        foreach (Trade t in trades)
        {
          if (t.Id == accId && t.Receiver == activeUser)
          {
            t.Status = TradeStatus.Accepted;
            Console.WriteLine("Trade accepted.");
            break;
          }
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();

        break;

      case"6": //Deny Trade

        Console.Write("Enter Trade Id to deny: ");
        string denyStr = Console.ReadLine();
        int denyId = 0;
        int.TryParse(denyStr, out denyId);

        foreach (Trade t in trades)
        {
          if (t.Id == denyId && t.Receiver == activeUser)
          {
            t.Status = TradeStatus.Denied;
            Console.WriteLine("Trade denied.");
            break;
          }
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();

        break;  

      case "7": //Logout

        activeUser.Logout();
        Console.WriteLine("You logged out.");
        activeUser = null;

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "8": //Exit

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