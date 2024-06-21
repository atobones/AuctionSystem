using System.ComponentModel.DataAnnotations;

public class EditUserModel
{
    public string Id { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
