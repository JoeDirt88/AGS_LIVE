using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;

namespace AGS.ServerAPI.Model_Managers
{
    public class clsUsersManager
    {
        MedicalDBContext db = new MedicalDBContext();

        ////Get All
        //public List<clsUsers> getAllUsersList()
        //{
        //    List<clsUsers> lstUsers = new List<clsUsers>();
        //    var lstGetUsersList = db.tblUsers.Where(User => User.bIsDeleted == false).ToList();

        //    if (lstGetUsersList.Count > 0)
        //    {
        //        //clsUserAccessManager clsUserAccessManager = new clsUserAccessManager(); //User Access Manager
        //        //clsRoleTypesManager clsRoleTypesManager = new clsRoleTypesManager(); //Role Type Manager

        //        foreach (var item in lstGetUsersList)
        //        {
        //            clsUsers clsUser = new clsUsers
        //            {
        //                iUserID = item.iUserID,
        //                dtAdded = item.dtAdded,
        //                iAddedBy = item.iAddedBy,
        //                dtEdited = item.dtEdited,
        //                iEditedBy = item.iEditedBy,
        //                iRoleTypeID = item.iRoleTypeID,

        //                strFirstName = item.strFirstName,
        //                strSurname = item.strSurname,
        //                strPrimaryContact = item.strPrimaryContact,
        //                strSecondaryContact = item.strSecondaryContact,
        //                strPrimaryContactNumber = item.strPrimaryContactNumber,
        //                strSecondaryContactNumber = item.strSecondaryContactNumber,

        //                strEmailAddress = item.strEmailAddress,
        //                strCompanyName = item.strCompanyName,
        //                strVatNumber = item.strVatNumber,
        //                strTrackNumber = item.strTrackNumber,
        //                strAccountNumber = item.strAccountNumber,
        //                strTerms = item.strTerms,
        //                strBusinessPurpose = item.strBusinessPurpose,
        //                strPassword = item.strPassword,
        //                strPasswordConfirm = item.strPasswordConfirm,
        //                strImagePath = item.strImagePath,
        //                strImageName = item.strImageName,

        //                bIsDeleted = item.bIsDeleted,
        //                bIsConfirmed = item.bIsConfirmed,
        //                lstUserAccess = new List<clsUserAccess>()
        //            };
        //            //if (item.tblUserAccess.Count > 0)
        //            //{
        //            //    foreach (var UserAccessItem in item.tblUserAccess)
        //            //    {
        //            //        clsUserAccess clsUserAccess = clsUserAccessManager.convertUserAccessTableToClass(UserAccessItem);
        //            //        clsUser.lstUserAccess.Add(clsUserAccess);
        //            //    }
        //            //}

        //            //if (item.tblRoleTypes != null)
        //            //    clsUser.clsRoleType = clsRoleTypesManager.convertRoleTypesTableToClass(item.tblRoleTypes);

        //            //lstUsers.Add(clsUser);
        //        }
        //    }

        //    return lstUsers;
        //}

        ////Get All
        //public List<clsUsers> getAllUsersOnlyList()
        //{
        //    List<clsUsers> lstUsers = new List<clsUsers>();
        //    var lstGetUsersList = db.tblUsers.Where(User => User.bIsDeleted == false).ToList();

        //    if (lstGetUsersList.Count > 0)
        //    {
        //        clsUserAccessManager clsUserAccessManager = new clsUserAccessManager(); //User Access Manager
        //        clsRoleTypesManager clsRoleTypesManager = new clsRoleTypesManager(); //Role Type Manager

        //        foreach (var item in lstGetUsersList)
        //        {
        //            clsUsers clsUser = new clsUsers()
        //            {
        //                iUserID = item.iUserID,
        //                dtAdded = item.dtAdded,
        //                iAddedBy = item.iAddedBy,
        //                dtEdited = item.dtEdited,
        //                iEditedBy = item.iEditedBy,
        //                iRoleTypeID = item.iRoleTypeID,

        //                strFirstName = item.strFirstName,
        //                strSurname = item.strSurname,
        //                strPrimaryContact = item.strPrimaryContact,
        //                strSecondaryContact = item.strSecondaryContact,
        //                strPrimaryContactNumber = item.strPrimaryContactNumber,
        //                strSecondaryContactNumber = item.strSecondaryContactNumber,

        //                strEmailAddress = item.strEmailAddress,
        //                strCompanyName = item.strCompanyName,
        //                strVatNumber = item.strVatNumber,
        //                strTrackNumber = item.strTrackNumber,
        //                strAccountNumber = item.strAccountNumber,
        //                strTerms = item.strTerms,
        //                strBusinessPurpose = item.strBusinessPurpose,
        //                strPassword = item.strPassword,
        //                strPasswordConfirm = item.strPasswordConfirm,
        //                iAreaID = item.iAreaID,
        //                strImagePath = item.strImagePath,
        //                strImageName = item.strImageName,

        //                bIsDeleted = item.bIsDeleted,
        //                bIsConfirmed = item.bIsConfirmed,

        //                lstUserAccess = new List<clsUserAccess>()
        //            };
        //            lstUsers.Add(clsUser);
        //        }
        //    }

        //    return lstUsers;
        //}

        //Get

        public clsUsers getUserById(int iUserID)
        {
            var clsUser = new clsUsers();
            var tblUser = db.tblUsers.FirstOrDefault(user => user.iUserID == iUserID && user.bIsDeleted == false);

            if (tblUser != null)
            {
                clsUser = new clsUsers
                {
                    iUserID = tblUser.iUserID,
                    dtAddedBy = tblUser.dtAddedBy,
                    iAddedBy = tblUser.iAddedBy,
                    dtEditedby = tblUser.dtEditedby,
                    iEditedBy = tblUser.iEditedBy,
                    iRoleID = tblUser.iRoleID,

                    strFirstName = tblUser.strFirstName,
                    strSurname = tblUser.strSurname,
                    strPhone = tblUser.strPhone,
                    strLocation = tblUser.strLocation,
                    strEmail = tblUser.strEmail,

                    bIsDeleted = tblUser.bIsDeleted
                };

            //    if (tblUser.tblUserAccess.Count > 0)
            //    {
            //        foreach (var UserAccessItem in tblUser.tblUserAccess)
            //        {
            //            clsUserAccess clsUserAccess = clsUserAccessManager.convertUserAccessTableToClass(UserAccessItem);
            //            clsUser.lstUserAccess.Add(clsUserAccess);
            //        }
            //    }

            //    if (tblUser.tblRoleTypes != null)
            //        clsUser.clsRoleType = clsRoleTypesManager.convertRoleTypesTableToClass(tblUser.tblRoleTypes);
            }

            return clsUser;
        }

        ////Get user account by user ID
        //public clsAccountUpdate getUserAccountById(int iUserID)
        //{
        //    clsAccountUpdate clsUser = null;
        //    var tblUser = db.tblUsers.FirstOrDefault(user => user.iUserID == iUserID && user.bIsDeleted == false);

        //    if (tblUser != null)
        //    {
        //        clsUser = new clsAccountUpdate
        //        {
        //            iUserID = tblUser.iUserID,
        //            dtAdded = tblUser.dtAdded,
        //            iAddedBy = tblUser.iAddedBy,
        //            dtEdited = tblUser.dtEdited,
        //            iEditedBy = tblUser.iEditedBy,
        //            iRoleTypeID = tblUser.iRoleTypeID,

        //            strFirstName = tblUser.strFirstName,
        //            strSurname = tblUser.strSurname,
        //            strPrimaryContact = tblUser.strPrimaryContact,
        //            strSecondaryContact = tblUser.strSecondaryContact,
        //            strPrimaryContactNumber = tblUser.strPrimaryContactNumber,
        //            strSecondaryContactNumber = tblUser.strSecondaryContactNumber,

        //            strEmailAddress = tblUser.strEmailAddress,
        //            strCompanyName = tblUser.strCompanyName,
        //            strVatNumber = tblUser.strVatNumber,
        //            strTrackNumber = tblUser.strTrackNumber,
        //            strAccountNumber = tblUser.strAccountNumber,
        //            strTerms = tblUser.strTerms,
        //            strBusinessPurpose = tblUser.strBusinessPurpose,
        //            strPassword = tblUser.strPassword,
        //            strPasswordConfirm = tblUser.strPasswordConfirm,
        //            iAreaID = tblUser.iAreaID,
        //            strImagePath = tblUser.strImagePath,
        //            strImageName = tblUser.strImageName,

                    
        //            bIsDeleted = tblUser.bIsDeleted,
        //            bIsConfirmed = tblUser.bIsConfirmed
        //        };
        //    }
        //    return clsUser;
        //}

        //Get CMS user by User email

        public clsUsers getUserByEmail(string strEmailAddress)
        {
            var clsUser = new clsUsers();
            var tblUser = db.tblUsers.FirstOrDefault(user => user.strEmail == strEmailAddress && user.bIsDeleted == false);

            if (tblUser != null)
            {
                clsUser = new clsUsers
                {
                    iUserID = tblUser.iUserID,
                    dtAddedBy = tblUser.dtAddedBy,
                    iAddedBy = tblUser.iAddedBy,
                    dtEditedby = tblUser.dtEditedby,
                    iEditedBy = tblUser.iEditedBy,
                    iRoleID = tblUser.iRoleID,

                    strFirstName = tblUser.strFirstName,
                    strSurname = tblUser.strSurname,
                    strPhone = tblUser.strPhone,
                    strLocation = tblUser.strLocation,
                    strEmail = tblUser.strEmail,
                    
                    bIsDeleted = tblUser.bIsDeleted,
                    //lstUserAccess = new List<clsUserAccess>()
                };


                //if (tblUser.tblUserAccess.Count > 0)
                //{
                //    foreach (var UserAccessItem in tblUser.tblUserAccess)
                //    {
                //        clsUserAccess clsUserAccess = clsUserAccessManager.convertUserAccessTableToClass(UserAccessItem);
                //        clsUser.lstUserAccess.Add(clsUserAccess);
                //    }
                //}

                //if (tblUser.tblRoleTypes != null)
                //    clsUser.clsRoleType = clsRoleTypesManager.convertRoleTypesTableToClass(tblUser.tblRoleTypes);
            }

            return clsUser;
        }

        ////Save
        //public void saveUser(clsUsers clsUser)
        //{
        //    if (HttpContext.Current.Session["clsCMSUser"] == null) return;
        //    var clsSessionCMSUser = (clsUsers)HttpContext.Current.Session["clsCMSUser"];
        //    var tblUser = new tblUsers
        //    {
        //        iUserID = clsUser.iUserID,
        //        iRoleTypeID = clsUser.iRoleTypeID,

        //        strFirstName = clsUser.strFirstName,
        //        strSurname = clsUser.strSurname,
        //        strPrimaryContact = clsUser.strPrimaryContact,
        //        strSecondaryContact = clsUser.strSecondaryContact,
        //        strPrimaryContactNumber = clsUser.strPrimaryContactNumber,
        //        strSecondaryContactNumber = clsUser.strSecondaryContactNumber,

        //        strEmailAddress = clsUser.strEmailAddress,
        //        strCompanyName = clsUser.strCompanyName,
        //        strVatNumber = clsUser.strVatNumber,
        //        strTrackNumber = clsUser.strTrackNumber,
        //        strAccountNumber = clsUser.strAccountNumber,
        //        strTerms = clsUser.strTerms,
        //        strBusinessPurpose = clsUser.strBusinessPurpose,
        //        strPassword = clsUser.strPassword,
        //        strPasswordConfirm = clsUser.strPasswordConfirm,
        //        iAreaID = clsUser.iAreaID,
        //        strImagePath = clsUser.strImagePath,
        //        strImageName = clsUser.strImageName,

        //        bIsDeleted = clsUser.bIsDeleted,
        //        bIsConfirmed = clsUser.bIsConfirmed
        //    };

        //    //Add
        //    if (tblUser.iUserID == 0)
        //    {
        //        tblUser.dtAdded = DateTime.Now;
        //        tblUser.iAddedBy = clsSessionCMSUser.iCMSUserID;
        //        tblUser.dtEdited = DateTime.Now;
        //        tblUser.iEditedBy = clsSessionCMSUser.iCMSUserID;

        //        db.tblUsers.Add(tblUser);
        //        db.SaveChanges();
        //    }
        //    //Update
        //    else
        //    {
        //        tblUser.dtAdded = clsUser.dtAdded;
        //        tblUser.iAddedBy = clsUser.iAddedBy;
        //        tblUser.dtEdited = DateTime.Now;
        //        tblUser.iEditedBy = clsSessionCMSUser.iCMSUserID;

        //        db.Set<tblUsers>().AddOrUpdate(tblUser);
        //        db.SaveChanges();
        //    }
        //}

        //Save

        public int registerUser(clsUsers clsUser)
        {

            var tblUser = new tblUsers
            {
                iUserID = clsUser.iUserID,
                strFirstName = clsUser.strFirstName,
                strSurname = clsUser.strSurname,
                strPhone = clsUser.strPhone,
                strLocation = clsUser.strLocation,
                strEmail = clsUser.strEmail,
                iRoleID = clsUser.iRoleID,
                bIsDeleted = clsUser.bIsDeleted,
                
            };

            //Add
            if (tblUser.iUserID == 0)
            {
                tblUser.dtAddedBy = DateTime.Now;
                tblUser.iAddedBy = 1;
                tblUser.dtEditedby = DateTime.Now;
                tblUser.iEditedBy = 1;

                db.tblUsers.Add(tblUser);
                db.SaveChanges();
            }
            //Update
            else
            {
                tblUser.dtAddedBy = clsUser.dtAddedBy;
                tblUser.iAddedBy = clsUser.iAddedBy;
                tblUser.dtEditedby = DateTime.Now;
                tblUser.iEditedBy = 1;

                db.Set<tblUsers>().AddOrUpdate(tblUser);
                db.SaveChanges();
            }
            return tblUser.iUserID;
        }

        //Save
        public int updateUser(clsUsers clsUser)
        {
            var tblUser = new tblUsers
            {
                iUserID = clsUser.iUserID,
                iRoleID = clsUser.iRoleID,

                strFirstName = clsUser.strFirstName,
                strSurname = clsUser.strSurname,
                strPhone = clsUser.strPhone,
                strLocation = clsUser.strLocation,
                strEmail = clsUser.strEmail,
                
                bIsDeleted = clsUser.bIsDeleted,
            };

            if ((clsUser.strEmail != null) && (clsUser.strPhone != null))
            {
                tblUser.strEmail = clsUser.strEmail;
                tblUser.strPhone = clsUser.strPhone;
            }

            //Add
            if (tblUser.iUserID == 0)
            {
                tblUser.dtAddedBy = DateTime.Now;
                tblUser.iAddedBy = 1;
                tblUser.dtEditedby = DateTime.Now;
                tblUser.iEditedBy = 1;

                db.tblUsers.Add(tblUser);
                db.SaveChanges();
            }
            //Update
            else
            {
                tblUser.dtAddedBy = clsUser.dtAddedBy;
                tblUser.iAddedBy = clsUser.iAddedBy;
                tblUser.dtEditedby = DateTime.Now;
                tblUser.iEditedBy = 1;

                db.Set<tblUsers>().AddOrUpdate(tblUser);
                db.SaveChanges();
            }
            return tblUser.iUserID;
        }
        
        //Check if user Exists by ID
        public bool checkIfUserExists(int iUserID)
        {
            var bUserExists = db.tblUsers.Any(User => User.iUserID == iUserID && User.bIsDeleted == false);
            return bUserExists;
        }

        //Check if  user Exists by email
        public bool checkIfUserExists(string strEmailAddress)
        {
            bool bUserExists = db.tblUsers.Any(User => User.strEmail == strEmailAddress && User.bIsDeleted == false);
            return bUserExists;
        }

        //Convert database table to class
        public clsUsers convertUsersTableToClass(tblUsers tblUser)
        {
            var clsUser = new clsUsers
            {
                iUserID = tblUser.iUserID,
                dtAddedBy = tblUser.dtAddedBy,
                iAddedBy = tblUser.iAddedBy,
                dtEditedby = tblUser.dtEditedby,
                iEditedBy = tblUser.iEditedBy,
                iRoleID = tblUser.iRoleID,
                
                strFirstName = tblUser.strFirstName,
                strSurname = tblUser.strSurname,
                strPhone = tblUser.strPhone,
                strEmail = tblUser.strEmail,
                strLocation = tblUser.strLocation,
                
                bIsDeleted = tblUser.bIsDeleted,
            };
            return clsUser;
        }
    }
}
