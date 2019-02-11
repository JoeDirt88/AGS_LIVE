using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsResult))]
    public partial class tblResult
    {
    }

    public class clsResult
    {
        public int iResultID { get; set; }
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

        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid SA ID number")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Incorrect ID number length")]
        [Display(Name = "Client ID")]
        public string strClientID { get; set; }
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Module code is 3 letters")]
        [Display(Name = "Module ID")]
        public string strModID { get; set; }
        [Display(Name = "Test data")]
        public string TestData { get; set; }
        [Display(Name = "Result")]
        public string Result { get; set; }

        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }

        public virtual tblModules tblModules { get; set; }
    }
}