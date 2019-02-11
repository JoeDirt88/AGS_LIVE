using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsUsers))]
    public partial class tblUsers
    {
    }

    public class clsUsers
    {
        public int iUserID { get; set; }
        [Display(Name = "Added By")]
        public int? iAddedBy { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Added On")]
        public DateTime? dtAddedBy { get; set; }
        [Display(Name = "Edited By")]
        public int? iEditedBy { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Edited On")]
        public DateTime? dtEditedby { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "User name must be at least 2 characters long")]
        [Display(Name = "Name")]
        public string strFirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be at least 2 characters long")]
        [Display(Name = "Surname")]
        public string strSurname { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Field is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        //(Method, Controller,)
        //[Remote("checkIfEmailExists", "cmsUsers", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        [Display(Name = "Email")]
        public string strEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Please enter a valid contact number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid contact number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Incorrect contact number length")]
        [Display(Name = "Phone")]
        public string strPhone { get; set; }
        [Display(Name = "Location")]
        public string strLocation { get; set; }
        [Display(Name = "Role")]
        public int? iRoleID { get; set; }

        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }
    }
}