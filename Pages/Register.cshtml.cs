 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

public class RegisterModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Contact { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var connectionString = "Server=localhost;Database=registration;User Id=root;Password=your_password;";
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("INSERT INTO Users (Name, Email, Contact) VALUES (@Name, @Email, @Contact)", connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Contact", Contact);
            command.ExecuteNonQuery();
        }

        return RedirectToPage("/Index");
    }
}
