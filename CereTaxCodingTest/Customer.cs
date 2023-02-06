namespace CereTaxCodingTest;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        string customer = "";

        if (string.IsNullOrEmpty(FirstName) == false 
                 && string.IsNullOrEmpty(LastName) == false)
        {
            customer = $"{LastName}, {FirstName}";
        }
        
        return customer;
    }
}
