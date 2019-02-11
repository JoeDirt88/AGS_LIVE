using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsExperienceTypes))]
    public partial class tblExperienceTypes
    {
    }

    public class clsExperienceTypes
    {
        public int iExperienceTypeID { get; set; }
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

        [Display(Name = "Experience Title")]
        public string strExperienceTitle { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }

        public virtual ICollection<tblExperienceAnswers> tblExperienceAnswers { get; set; }
        public virtual ICollection<tblTechExperience> tblTechExperience { get; set; }
        public virtual ICollection<tblUserExperience> tblUserExperience { get; set; }
    }
}