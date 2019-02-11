using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsExperienceAnswers))]
    public partial class tblExperienceAnswers
    {
    }

    public class clsExperienceAnswers
    {
        public int iExperienceAnswerID { get; set; }
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

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string strEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string strPhone { get; set; }
        [Display(Name = "Occupation")]
        public string strOccupation { get; set; }
        [Display(Name = "Experience Type")]
        public int iExperienceTypeID { get; set; }

        [Display(Name = "Answers")]
        public string strAnswers { get; set; }
        [Display(Name = "Average")]
        public double iAverage { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }
        
        public virtual tblExperienceTypes tblExperienceTypes { get; set; }
    }
}