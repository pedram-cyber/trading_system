namespace App;

class Item
{
  public string Name;
  public string Description;
  public User Owner;

  //Item constructor to store instans variables for name description and owner

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
  
}