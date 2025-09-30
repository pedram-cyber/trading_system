namespace App;

class Trade
{
  public int Id;
  public User Sender;
  public User Receiver;
  public TradeStatus Status;
  public List<Item> Items;

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