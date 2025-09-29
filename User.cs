namespace App;

class User
{
  public string Email;
  string _password;
  public bool LoggedIn;

  public User(string email, string password)
  {
    Email = email;
    _password = password;
    LoggedIn = false;
  }

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