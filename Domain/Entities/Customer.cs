namespace Domain.Entities
{
  public class Customer
  {
    public String Name { get; set; } = String.Empty;
    public String Email { get; set; } = String.Empty;
    public String Document { get; set; } = String.Empty;

    public Customer(String name, String email, String document)
    {
      Name = name;
      Email = email;
      Document = document;
    }
  }
}
