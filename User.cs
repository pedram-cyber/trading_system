namespace App;

class User
{
  public string Email;
  string _password;
  public bool LoggedIn;
  
  //User Constructor stores Email, Password and Logged in instans variabels

  public User(string email, string password)
  {
    Email = email;
    _password = password;
    LoggedIn = false;
  }

  //Checkes if Email and Password is correct. Runs if true and brings back to menue if false

  public bool TryLogin(string email, string password)
  {
    if (email == Email && password == _password)
    {
      LoggedIn = true;
      return true;
    }
    return false;
  }

  public void Logout()
  {
    LoggedIn = false;
  }

  public string ShowInfo()
  {
    return "User:" + Email;
  }
}