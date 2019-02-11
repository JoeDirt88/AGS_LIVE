using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsReports))]
    public partial class tblReports
    {
    }

    public class clsReports
    {
        public int iReportID { get; set; }
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

        [Required(ErrorMessage = "Report title is required")]
        [Display(Name = "Report")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Report title must be at least 2 characters long")]
        public string strReport { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Email must be at least 2 characters long")]
        public string strEmail { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid contact number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Incorrect contact number length")]
        public string strContactNumber { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }
    }
}