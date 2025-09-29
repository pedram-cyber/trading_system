namespace App;

class Item
{
  public string Name;
  public string Description;
  public User OwnerEmail;

  public Item(string name, string description, User owneremail)
  {
    Name = name;
    Description = description;
    OwnerEmail = owneremail;
  }

  public string ShowInfo()
  {
    return "Item " + Name + " - " + Description + "(Owner:" + OwnerEmail + ")";
  }
  
  //foreach (Item item in items)
  // {
  //   Console.WriteLine(Item.ShowInfo());
  // }
}