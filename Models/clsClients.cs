using System;
using System.ComponentModel.DataAnnotations;

namespace AGS.ServerAPI
{
    [MetadataType(typeof(clsClients))]
    public partial class tblClients
    {
    }

    public class clsClients
    {
        public int iClientID { get; set; }
        [Display(Name = "South African ID")]
        public string strClientID { get; set; }
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


        [Display(Name = "First name")]
        public string strFirstName { get; set; }
        [Display(Name = "Last name")]
        public string strSurname { get; set; }
        [Display(Name = "Age")]
        public int iAge { get; set; }
        [Display(Name = "Sex")]
        public string strSex { get; set; }
        [Display(Name = "Coordinates")]
        public string strLocation { get; set; }
        [Display(Name = "Role ID")]
        public int? iRoleID { get; set; }
        [Display(Name = "Removed")]
        public bool bIsDeleted { get; set; }
        
    }
}