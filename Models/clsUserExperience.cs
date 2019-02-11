using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsUserExperience))]
    public partial class tblUserExperience
    {
    }

    public class clsUserExperience
    {
        public int iUxID { get; set; }
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

        [Display(Name = "Experience Type")]
        public int iExperienceTypeID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Questions name must be at least 2 characters long")]
        [Display(Name = "Experience question")]
        public string strQuestion { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Negative option must be at least 2 characters long")]
        [Display(Name = ("Negative option"))]
        public string strUxQuestionL { get; set; }
        [Required(ErrorMessage = "Field is required")]
        [Range(0, 4)]
        [Display(Name = ("Rating"))]
        public int iUxQuestionM { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Field is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Positive option must be at least 2 characters long")]
        [Display(Name = ("Positive option"))]
        public string strUxQuestionR { get; set; }
        [Display(Name = ("Removed"))]
        public bool bIsDeleted { get; set; }

        public virtual tblExperienceTypes tblExperienceTypes { get; set; }
    }
}