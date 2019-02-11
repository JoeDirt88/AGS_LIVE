using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsQuestions))]
    public partial class tblQuestions
    {
    }

    public class clsQuestions
    {
        public int iQuestionID { get; set; }
        [Display(Name = "Question ID")]
        public string strQuestionID { get; set; }
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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Question must be at least 2 characters long")]
        [Display(Name = "Question")]
        public string strQuestion { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Question description must be at least 2 characters long")]
        [Display(Name = "Flavor")]
        public string strFlavourText { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Question significance must be at least 2 characters long")]
        [Display(Name = "Significance")]
        public string strSignificance { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Unit must be at least 2 characters long")]
        [Display(Name = "Unit")]
        public string strUnit { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }
    }
}