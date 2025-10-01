namespace App;

//Get id sender receiver status and Items 
//get and set for tradestatus in order to be able to receive and handle the status

class Trade
{
  public int Id { get; }
  public User Sender { get; }
  public User Receiver { get; }
  public TradeStatus Status { get; set; }
  public List<Item> Items { get; }

  //constructor for trade that stores instans variabels for id sender, receiver and list items

  public Trade(int id, User sender, User receiver, List<Item> items)
  {
    Id = id;
    Sender = sender;
    Receiver = receiver;
    Items = items;
    Status = TradeStatus.Pending;
  }
  public string ShowInfo()
  {
    return "Trade " + Id + ": " + Sender.Email + " -> " + Receiver.Email + " | Items: " + Items.Count + " | Status: " + Status;
  }

}