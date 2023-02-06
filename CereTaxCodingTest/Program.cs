using CereTaxCodingTest;

//
// exercise 1
//
Console.WriteLine("Exercise 1");

Customer[] customers = 
{
    new Customer { LastName = "Smith", FirstName = "John" },
    new Customer { LastName = "Simpson", FirstName = "Amy" },
    new Customer { LastName = "Anderson", FirstName = "Tom" },
    new Customer { LastName = "Sexton", FirstName = "Test" },
    new Customer { LastName = "Dummy", FirstName = "test" },
    new Customer { LastName = "Dummy1", FirstName = "test23" },
    new Customer { LastName = "Dummy2", FirstName = "Testing" },
    new Customer { LastName = "Sexton", FirstName = "Charles" },
    new Customer { LastName = "Billy", FirstName = "Test" }
};

string customerNames = customers.Select(e => e.ToString())
                                .Aggregate((name1, name2) => $"{name1}; {name2}");

Console.WriteLine(customerNames);
Console.WriteLine();


//
// exercise 2
//
Console.WriteLine("Exercise 2");

int customerCount = GetCustomerCountWhereFirstNameContains(customerNames, "Test");
Console.WriteLine($"Customers Count: {customerCount}");
Console.WriteLine();


int GetCustomerCountWhereFirstNameContains(string customerNames, string containsSubString)
{
    Customer[] parsedCustomers = customerNames.Split(';').Select(e =>
    {
        string[] customerParts = e.Split(new [] { ", " }, StringSplitOptions.None);
    
        return new Customer
        {
            LastName = customerParts[0], 
            FirstName = customerParts[1]
        };
    }).ToArray();

    int customerCount = parsedCustomers.Count(e => e.FirstName.Contains(containsSubString));
    return customerCount;
}


//
// Exercise 5
//
Console.WriteLine("Exercise 5");

ICollection<string> substrings = GetNewStringByNDeletedLetters("TEST", 1);
ICollection<string> substrings2 = GetNewStringByNDeletedLetters("TEST", 2);

Console.WriteLine(string.Join(',', substrings));
Console.WriteLine(string.Join(',', substrings2));
Console.WriteLine();


ICollection<string> GetNewStringByNDeletedLetters(
    string input, int lettersToRemove, int depth = 0, IList<string>? newStrings = null)
{
    newStrings ??= new List<string>();
    
    if (lettersToRemove <= depth || depth >= input.Length - 1 || lettersToRemove <= 0)
    {
        return newStrings;
    }
    
    IList<string> substringsToRemoveLetters = 
        newStrings.Count == 0 
            ? Enumerable.Repeat(input, input.Length).ToList() 
            : newStrings.Where(e => e.Length == input.Length - depth).ToList();
    
    foreach (string substring in substringsToRemoveLetters)
    {
        for (int y = 0; y < substring.Length; y++)
        {
            string newSubstring = substring.Remove(y, 1);
            
            if (newStrings.Contains(newSubstring) == false)
            {
                newStrings.Add(newSubstring);
            }
        }
    }
    
    return GetNewStringByNDeletedLetters(input, lettersToRemove, ++depth, newStrings);
}


//
// Exercise 6
//
Console.WriteLine("Exercise 6");

ICollection<string> strings1 = GetNewStringByNDeletedLetters("TEST", 1);
ICollection<string> strings2 = GetNewStringByNDeletedLetters("TEST", 2);

ICollection<string> stringsFound = strings1.Where(a => strings2.Any(b => a == b)).ToArray();

Console.WriteLine(string.Join(',', stringsFound));
