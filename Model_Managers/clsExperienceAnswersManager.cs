using System;
using System.Data.Entity.Migrations;

namespace AGS.ServerAPI.Model_Managers
{
    public class clsExperienceAnswersManager
    {
        public void registerUx(clsExperienceAnswers clsExperienceAnswer)
        {
            var db = new MedicalDBContext();

            var tblExperienceAnswers = new tblExperienceAnswers()
            {
                iExperienceAnswerID = clsExperienceAnswer.iExperienceAnswerID,
                iExperienceTypeID = clsExperienceAnswer.iExperienceTypeID,
                iAverage = clsExperienceAnswer.iAverage,
                bIsDeleted = clsExperienceAnswer.bIsDeleted,
                strEmail = clsExperienceAnswer.strEmail,
                strPhone = clsExperienceAnswer.strPhone,
                strOccupation = clsExperienceAnswer.strOccupation,
                strAnswers = clsExperienceAnswer.strAnswers
            };

            //Add
            if (tblExperienceAnswers.iExperienceAnswerID == 0)
            {
                tblExperienceAnswers.dtAddedBy = DateTime.Now;
                tblExperienceAnswers.iAddedBy = 1;
                tblExperienceAnswers.dtEditedby = DateTime.Now;
                tblExperienceAnswers.iEditedBy = 1;

                db.tblExperienceAnswers.Add(tblExperienceAnswers);
                db.SaveChanges();
            }
            //Update
            else
            {
                tblExperienceAnswers.dtAddedBy = clsExperienceAnswer.dtAddedBy;
                tblExperienceAnswers.iAddedBy = clsExperienceAnswer.iAddedBy;
                tblExperienceAnswers.dtEditedby = DateTime.Now;
                tblExperienceAnswers.iEditedBy = 1;

                db.Set<tblExperienceAnswers>().AddOrUpdate(tblExperienceAnswers);
                db.SaveChanges();
            }
        }
    }
}