namespace App;

class Trade
{
  public User Sender;
  public User Receiver;
  public TradeStatus Status;
  public List<Item> Items;

  public Trade(User sender, User receiver, List<Item> items)
  {
    Sender = sender;
    Receiver = receiver;
    Items = items;
  }

  
}