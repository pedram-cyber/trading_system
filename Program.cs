using App;

List<User> users = new List<User>();
List<Item> items = new List<Item>();
List<Trade> trades = new List<Trade>();

User activeUser = null;
bool running = true;

while (running)
{
  //Clearing the console to not show previous codes.
  Console.Clear();

  //The login section to the system when you register your username and password and exit the program.
  //At the start of the program, it is assumed that the activeuser does not yet exist.
  if (activeUser == null)
  {
    Console.WriteLine("1.Register");
    Console.WriteLine("2.Login");
    Console.WriteLine("0.Exit");
    Console.WriteLine(" ");

    //Selecting the option the user wants to execute switch commands By typing the desired number
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

        /*
        - Loop through all registered users
        - For each user, call TryLogin() to check if email and password match
        - If a match is found, set that user as activeUser
        */

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

        /*
        - If no matching user was found, show error message
        - The user stays on the login menu
        */

        if (!loggedIn)
        {
          Console.WriteLine("Invalid credentials.");
        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "0":

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
    Console.WriteLine("Current Users: ");
    foreach (User user in users)
    {
      Console.WriteLine(user.ShowInfo());
    }
    Console.WriteLine(" ");
    Console.WriteLine("Logged in as:" + activeUser.Email);
    Console.WriteLine(" ");
    Console.WriteLine("1.Add Item");
    Console.WriteLine("2.Browes Items");
    Console.WriteLine("3.Request Trade");
    Console.WriteLine("4.Browes Trades");
    Console.WriteLine("5.Accept Trade");
    Console.WriteLine("6.Deny Trade");
    Console.WriteLine("7.Logout");
    Console.WriteLine("0.Exit");
    Console.WriteLine(" ");

    string choice = Console.ReadLine();

    switch (choice)
    {
      case "1": //Add Item

        Console.WriteLine("Item name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        items.Add(new Item(name, description, activeUser));
        Console.WriteLine("Item Added!");

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "2": //Browes Items

        Console.WriteLine("...Items...");
        foreach (Item item in items)
        {
          Console.WriteLine(item.ShowInfo());
        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      /*
      - case3 handles trade request from all activeusers 
      */

      case "3": //Request Trade

        Console.Write("Receiver email: ");
        string recv = Console.ReadLine();

        //checks if user information is correct, searches for user, finds and equals recv
        User receiver = users.Find(u => u.Email == recv);

        if (receiver == null)
        {
          Console.WriteLine("User not found.");
        }

        /*
        - checks the whole list of items, finds all items, sends the item to activeuser, activeuser captures item
        - check the whole list of items, finds all items, send the reciever items to active user for trade choices
        */

        else
        {
          List<Item> myItems = items.FindAll(i => i.Owner == activeUser);
          List<Item> receiverItems = items.FindAll(i => i.Owner == receiver);

          if (myItems.Count == 0 || receiverItems.Count == 0)
          {
            Console.WriteLine("Both has to have an Item to trade");
          }

          /*
          - shows item information and handles items used for trading 
          */

          else
          {
            Console.WriteLine("Your object:");
            for (int i = 0; i < myItems.Count; i++)
            {
              Console.WriteLine((i + 1) + ". " + myItems[i].ShowInfo());

            }

            //Changing Parse to TryParse to avoid crashing the program when entering letters instead of the desired number
            Console.Write("Choose number of object you want to trade: ");
            int myChoice;
            if (!int.TryParse(Console.ReadLine(), out myChoice))
            {
              Console.WriteLine("Invalid number.");
              break;
            }
            myChoice = myChoice - 1;

            Console.WriteLine(receiver.Email + " " + "object:");
            for (int i = 0; i < receiverItems.Count; i++)
            {
              Console.WriteLine((i + 1) + ". " + receiverItems[i].ShowInfo());
            }

            //Changing Parse to TryParse to avoid crashing the program when entering letters instead of the desired number
            Console.Write("Choose number of object you want to trade: ");
            int theirChoice;
            if (!int.TryParse(Console.ReadLine(), out theirChoice))
            {
              Console.WriteLine("Invalid number.");
              break;
            }
            theirChoice = theirChoice - 1;

            /*
            - checks if a choice is made from active user list 
            - my items must always be greater than my choice, for a choice to be made
            - same goes for receiver items and choice of receiver items
            - if my choice is greater than my items count , no choice can be made, since there no item left 
            */

            if (myChoice >= 0 && myChoice < myItems.Count &&
                theirChoice >= 0 && theirChoice < receiverItems.Count)
            {
              var tradeItems = new List<Item> { myItems[myChoice], receiverItems[theirChoice] };

              Trade trade = new Trade(trades.Count + 1, activeUser, receiver, tradeItems);
              trades.Add(trade);

              Console.WriteLine("Trade request sent!");
            }
            else
            {
              Console.WriteLine("Invalid choice");
            }
          }
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

        //When there is no trade demand
        if (trades.Count == 0)
        {
          Console.WriteLine("No trades yet.");
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        break;

      /*
      - checks for trade id to accept
      - finds trade to accept from trade list 
      - finds trade through id get information from receiver and activeuser
      - if receiver decides to accept the trade would be done successfully
      - sender item and receiver item will be trade and so will the owners of the item
      - item trade successfull massage will be send after successfull trade
      - if trade already handled or is none existing, trade will fail 
      */

      case "5": //Accept Trade

        Console.Write("Enter Trade Id to accept: ");
        int accId;
        int.TryParse(Console.ReadLine(), out accId);

        Trade tradeToAccept = trades.Find(t => t.Id == accId && t.Receiver == activeUser);

        if (tradeToAccept != null && tradeToAccept.Status == TradeStatus.Pending)
        {
          Item senderItem = tradeToAccept.Items[0];
          Item receiverItem = tradeToAccept.Items[1];

          // change owner
          senderItem.Owner = tradeToAccept.Receiver;
          receiverItem.Owner = tradeToAccept.Sender;

          tradeToAccept.Status = TradeStatus.Accepted;
          Console.WriteLine("Trade accepted, items swapped!");
        }
        else
        {
          Console.WriteLine("Trade not found or already handled.");
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        break;

      /*
      - receiver types, the trade id to deny 
      - the deny id is found and handled 
      - when the trade id is found, a denied command is executed and deny command is sent to active user
      - trade status is change from pending to denied
      - trade denied status is written and trade successfully denied 
      - if trade already handled or not found a trade denied will not be executed, error massage written
      */

      case "6": //Deny Trade

        Console.Write("Enter Trade Id to deny: ");
        int denyId;
        int.TryParse(Console.ReadLine(), out denyId);

        Trade tradeToDeny = trades.Find(t => t.Id == denyId && t.Receiver == activeUser);

        if (tradeToDeny != null && tradeToDeny.Status == TradeStatus.Pending)
        {
          tradeToDeny.Status = TradeStatus.Denied;
          Console.WriteLine("Trade denied.");
        }
        else
        {
          Console.WriteLine("Trade not found or already handled.");
        }

        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine();
        break;

      // logout command for activeusers

      case "7": //Logout

        activeUser.Logout();
        Console.WriteLine("You logged out.");
        activeUser = null;

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        break;

      case "0": //Exit

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