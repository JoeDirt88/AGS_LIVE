using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsModules))]
    public partial class tblModules
    {
    }

    public class clsModules
    {
        public string strModID { get; set; }
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

        [Display(Name = "Module name")]
        public string strModName { get; set; }
        [Display(Name = "Description")]
        public string strModDescription { get; set; }
        [Display(Name = "Active")]
        public bool bModStatus { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }

        public virtual ICollection<tblResult> tblResult { get; set; }
    }
}