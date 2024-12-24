namespace UnitTestConsoleApp;


public interface IEmailService
{
    bool SendEmail(string email, string subject, string body);
    bool SendEmailWithAttachment(string email, string subject, string body, string attachmentPath);
}

public class EmailService : IEmailService
{
    public bool SendEmail(string email, string subject, string body)
    {
        // Dummy logic for demonstration:
        if (string.IsNullOrEmpty(email)) return false;

        Console.WriteLine($"Sending email to {email} with subject '{subject}'");
        return true; // Assume the email was sent successfully
    }

    public bool SendEmailWithAttachment(string email, string subject, string body, string attachmentPath)
    {
        // Dummy logic for demonstration:
        if (string.IsNullOrEmpty(email)) return false;

        Console.WriteLine($"Sending email to {email} with attachment {attachmentPath}");
        return true; // Assume the email was sent successfully
    }
}


/* 
Primary constructors:
You can add parameters to a struct or class declaration to create a primary constructor. 
Primary constructor parameters are in scope throughout the class definition.
It's important to view primary constructor parameters as parameters even though they are in scope throughout the class definition

    The UserAccount class depends on an IEmailService interface to send emails. 
    The SetEmail method sets the email address and sends a welcome email using the IEmailService interface. 
    The SetEmailWithAttachment method sends an email with an attachment using the IEmailService interface. 
    The GetEmail method returns the email address that was set.
    
*/

public class UserAccount
{
    private readonly IEmailService _emailService;
    private string _email;

    /*
    Non-nullable property must contain a non-null value when exiting constructor.
    Consider declaring the property as nullable
    SOLUTION :
    1=> If you don't want this, you can disable this by deleting the below line from the csproj file or setting it as disable.
    By default value is disable.
    <Nullable>enable</Nullable>

    2=> You can also set the property as nullable by adding ? after the type.
    The compiler is warning you that the default assignment of your string property 
    (which is null) doesn't match its stated type (which is non-null string).
    This is emitted when nullable reference types are switched on, which changes all reference types to be non-null, unless stated otherwise with a ?.
    For example, your code could be changed to

    public class Greeting
  
    public string? From { get; set; }
    public string? To { get; set; } 
    public string? Message { get; set; }

    to declare the properties as nullable strings, or you could give the properties defaults in-line or in the constructor:
    }


    */
    // private string _email ;

    public UserAccount(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public bool SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty");
        }

        _email = email;

        return _emailService.SendEmail(_email, "Welcome", "Thank you for registering.");
    }

    public bool SetEmailWithAttachment(string email, string subject, string body, string attachmentPath)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty");
        }

        _email = email;

        return _emailService.SendEmailWithAttachment(_email, subject, body, attachmentPath);
    }

    public string GetEmail()
    {
        return _email;
    }
}


class Program
{
    static void Main(string[] args)
    {
        
    }
}