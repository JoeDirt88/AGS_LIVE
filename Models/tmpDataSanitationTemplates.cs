using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

class Sanitisers
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Field is required")]
    [StringLength(250, MinimumLength = 2, ErrorMessage = "Last name must be at least 2 characters long")]
    public string strNames { get; set; }

    [DataType(DataType.PhoneNumber)]
    [Phone(ErrorMessage = "Please enter a valid contact number")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid contact number")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Incorrect contact number length")]
    public string strNumbers { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Field is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email")]
    //(Method, Controller,)
    //[Remote("checkIfUserExists", "Users", HttpMethod = "POST", ErrorMessage = "Email already exists")]
    public string strEmailAddresses { get; set; }

    [DataType(DataType.Password)]
    [PasswordPropertyText(true)]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters long")]
    public string strPasswords { get; set; }

    [DataType(DataType.Password)]
    [PasswordPropertyText(true)]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters long")]
    [System.ComponentModel.DataAnnotations.Compare("strPasswords", ErrorMessage = "Password does not match")]
    public string strPasswordConfirm { get; set; }

}
