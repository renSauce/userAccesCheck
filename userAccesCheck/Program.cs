class Program
{
    static void Main()
    {
        // Ask user for input
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter password: ");
        string? password = Console.ReadLine();

        Console.Write("Enter user ID: ");
        string? inputUserId = Console.ReadLine();

        // Validate null or empty inputs
        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("❌ Username cannot be empty.");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("❌ Password cannot be empty.");
            return;
        }
        if (string.IsNullOrEmpty(inputUserId) || !uint.TryParse(inputUserId, out uint userId))
        {
            Console.WriteLine("❌ Invalid User ID.");
            return;
        }

        // Boolean checks
        var userIsAdmin = userId > 65536;
        var usernameValid = username.Length >= 3;
        bool containsSpecial = password.Contains('$') || password.Contains('|') || password.Contains('@');
        var passwordValid = containsSpecial &&
                           ((userIsAdmin && password.Length >= 20) ||
                            (!userIsAdmin && password.Length >= 16));

        // Output results
        if (usernameValid && passwordValid)
        {
            Console.WriteLine("Access granted: Both username and password are valid.");
        }
        else
        {
            if (!usernameValid)
                Console.WriteLine("Invalid username: must be at least 3 characters.");
            
            if (!passwordValid)
                Console.WriteLine("Invalid password: must contain $, | or @ and meet length requirements.");
        }
    }
}
