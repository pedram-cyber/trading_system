namespace App;

class Item
{
  public string Name;
  public string Description;
  public User Owner;

  public Item(string name, string description, User owner)
  {
    Name = name;
    Description = description;
    Owner = owner;
  }

  public string ShowInfo()
  {
    return "Item " + Name + " - " + Description + "(Owner:" + Owner.Email + ")";
  }
  
  //foreach (Item item in items)
  // {
  //   Console.WriteLine(item.ShowInfo());
  // }
}