using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using AGS.ServerAPI.DAL_Models;
using AGS.ServerAPI.View_Models;
using UxSurvey = AGS.ServerAPI.DAL_Models.UxSurvey;

namespace AGS.ServerAPI.Utility
{
    public class QueryShort
    {
        private static string serverCon = @"Data Source=Lillith\SQLEXPRESS;Initial Catalog=AGS_DB;Integrated Security=True;MultipleActiveResultSets=True";

        #region AddClient tblClient
        /// <summary>
        /// Description:    This is a shortcut method for writing new client
        ///                 data into the Client data table
        /// </summary>      Implemented
        /// <param name="value">This is an object posted by the app to the API</param>
        /// <returns>bool upon success or failure</returns>
        //public static bool AddClient(PatientInfo value)
        //{
        //    MedicalDBContext mdbc = new MedicalDBContext();
        //    try
        //    {
        //        using (var connect = new SqlConnection())
        //        {
        //            connect.ConnectionString = serverCon;

        //            var query = $@"INSERT INTO tblClient (ID, Name, Surname)";
        //            query += $@"VALUES (@ID, @Name, @Surname)";
        //            connect.Open();
        //            using (var cmd = new SqlCommand(query, connect))
        //            {
        //                cmd.Parameters.AddWithValue("@ID", value.Said);
        //                cmd.Parameters.AddWithValue("@Name", value.Name);
        //                cmd.Parameters.AddWithValue("@Surname", value.Surname);
        //                cmd.ExecuteNonQuery();
        //            }

        //            connect.Close();
        //        }

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception occured while writing to table:" + e.Message);
        //        throw;
        //    }
        //}
        public static bool AddClient(PatientInfo value)
        {
            MedicalDBContext mdbc = new MedicalDBContext();
            var tblClient = new tblClients()
            {
                strClientID = value.Said,
                strFirstName = value.Name,
                strSurname = value.Surname,
                strLocation = "coming soon",
                strSex = "coming soon",
                iAge = 0,
                iRoleID = 0,
                bIsDeleted = false,
            };

            //Add
            var isexist = mdbc.tblClients.FirstOrDefault(client =>
                client.bIsDeleted != true && client.strClientID == tblClient.strClientID);
            if (isexist == null)
            {
                tblClient.dtAddedBy = DateTime.Now;
                tblClient.iAddedBy = -1;
                tblClient.dtEditedby = DateTime.Now;
                tblClient.iEditedBy = -1;

                mdbc.tblClients.Add(tblClient);
                mdbc.SaveChanges();
                return true;
            }
            //Update
            else
            {
                tblClient.dtAddedBy = isexist.dtAddedBy;
                tblClient.iAddedBy = isexist.iAddedBy;
                tblClient.dtEditedby = DateTime.Now;
                tblClient.iEditedBy = -1;

                mdbc.Set<tblClients>().AddOrUpdate(tblClient);
                mdbc.SaveChanges();
                return true;
            }

        }
        #endregion 

        #region AddExperience tblExperienceAnswers
        /// <summary>
        /// Description:    This is a shortcut method for writing new client
        ///                 data into the Client data table
        /// </summary>      Implemented
        /// <param name="value">This is an object posted by the app to the API</param>
        /// <returns>bool upon success or failure</returns>
        public static bool AddUxResult(UxResult value)
        {
            var mdbc = new MedicalDBContext();
            var iTypeId = 0;
            switch (value.iExperienceTypeID.ToLower())
            {
                case "tx":
                    iTypeId = 3;
                    break;
                case "ux":
                    iTypeId = 2;
                    break;
                case "fb":
                    iTypeId = 4;
                    value.iAverage = -1.0;
                    break;
            }
            var tblExperienceAnswer = new tblExperienceAnswers()
            {
                iExperienceAnswerID = 0,
                strEmail = value.strEmail,
                strPhone = value.strPhone,
                strOccupation = value.strOccupation,
                strAnswers = value.strAnswers,
                iAverage = value.iAverage,
                iExperienceTypeID = iTypeId,
                bIsDeleted = false,
            };

            //Add
            if (tblExperienceAnswer.iExperienceAnswerID == 0)
            {
                tblExperienceAnswer.dtAddedBy = DateTime.Now;
                tblExperienceAnswer.iAddedBy = -1;
                tblExperienceAnswer.dtEditedby = DateTime.Now;
                tblExperienceAnswer.iEditedBy = -1;

                mdbc.tblExperienceAnswers.Add(tblExperienceAnswer);
                mdbc.SaveChanges();
                return true;
            }
            //Update
            else
            {
                tblExperienceAnswer.dtAddedBy = DateTime.Now;
                tblExperienceAnswer.iAddedBy = -1;
                tblExperienceAnswer.dtEditedby = DateTime.Now;
                tblExperienceAnswer.iEditedBy = -1;

                mdbc.Set<tblExperienceAnswers>().AddOrUpdate(tblExperienceAnswer);
                mdbc.SaveChanges();
                return true;
            }

        }
        #endregion 

        #region AddResult tblResult
        /// <summary>
        /// Description:    This is a shortcut method for writing new client
        ///                 data into the Client data table
        /// </summary>      Implemented
        /// <param name="value">This is an object posted by the app to the API</param>
        /// <returns>bool upon success or failure</returns>
        public static bool AddResult(AnswerModel value)
        {

            try
            {
                using (var connect = new SqlConnection())
                {
                    connect.ConnectionString = serverCon;

                    var query = $@"INSERT INTO tblResult (ClientID, ModuleTested, TestData, Result, DateTime)";
                    query += $@"VALUES (@ClientID, @ModuleTested, @TestData, @Result, @DateTime)";
                    connect.Open();

                    //make this better
                    var testDataList = new List<string>();
                    var testData = string.Empty;
                    switch (value.ModuleId)
                    {

                        case "Vad":
                            foreach (var dat in value.ParametersVad)
                            {
                                testData += dat + " ";
                            }
                            break;
                        case "Met":
                            testDataList.Add(value.Age);
                            testDataList.Add(value.Waist);
                            testDataList.Add(value.Systolic);
                            foreach (var dat in testDataList)
                            {
                                testData += dat + " ";
                            }
                            break;
                        default:
                            testData = "No DATA";
                            break;
                    }


                    using (var cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@ClientID", value.Said);
                        cmd.Parameters.AddWithValue("@ModuleTested", value.ModuleId);
                        cmd.Parameters.AddWithValue("@TestData", testData);
                        cmd.Parameters.AddWithValue("@Result", PythonShort.PostToPython(value));
                        cmd.Parameters.AddWithValue("@DateTime", value.CurDateTime);
                        cmd.ExecuteNonQuery();
                    }

                    connect.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while writing to table:" + e.Message);
                throw;
            }
        }
        #endregion

        #region ClientList tblClient
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static List<PatientInfo> SearchClient()
        {
            MedicalDBContext mdbc = new MedicalDBContext();
            // Empty query variable
            var queList = new List<PatientInfo>();
            // Create the connection
            using (var connection = new SqlConnection())
            {
                var lstPatients = mdbc.tblClients.Where(client => client.bIsDeleted != true).ToList();
                connection.ConnectionString = serverCon;
                foreach (var patient in lstPatients)
                {
                    var curPatient = new PatientInfo()
                    {
                        Said = patient.strClientID,
                        Name = patient.strFirstName,
                        Surname = patient.strSurname
                    };
                    queList.Add(curPatient);
                }

                //var command = new SqlCommand("SELECT * FROM tblClient", connection);
                //connection.Open();
                //using (var reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        var queListBuild = new PatientInfo()
                //        {
                //            Said = (string)reader[0],
                //            Name = (string)reader[1],
                //            Surname = (string)reader[2]
                //        };
                //        queList.Add(queListBuild);
                //    }
                //    connection.Close();
                //}
            }
            return queList;
        }
        #endregion

        #region SearchClient tblClient
        /// <summary>
        /// Description:    SQL shortcut for checking if a client already exists for creation on the API
        /// Status:         Implemented
        /// </summary>
        /// <param name="value">The client ID number taken from the model</param>
        /// <returns>string "Old" if the client exists, "New" for a new entry</returns>
        public static PatientInfo SearchClient(string value)
        {
            // Empty query variable
            var curPatient = new PatientInfo();
            var queList = new PatientInfo { Name = "Failed", Surname = "Attempt", Said = "0" };
            MedicalDBContext mdbc = new MedicalDBContext();

            var thisPatient = mdbc.tblClients.FirstOrDefault(patient => patient.bIsDeleted != true && patient.strClientID == value);
            if (thisPatient != null)
            {
                curPatient = new PatientInfo()
                {
                    Said = thisPatient.strClientID,
                    Name = thisPatient.strFirstName,
                    Surname = thisPatient.strSurname
                };
            }
            else
            {
                curPatient = queList;
            }

            //// Create the connection
            //using (var connection = new SqlConnection())
            //{
            //    connection.ConnectionString = serverCon;

            //    var command = new SqlCommand("SELECT * FROM tblClient", connection);
            //    connection.Open();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var queListBuild = new PatientInfo()
            //            {
            //                Said = (string) reader[0],
            //                Name = (string) reader[1],
            //                Surname = (string) reader[2]
            //            };
            //            if (queListBuild.Said == value)
            //            {
            //                queList = queListBuild;
            //            }
            //        }
            //        connection.Close();
            //    }
            //}
            return curPatient;
        }
        #endregion

        #region SearchModule tblModules POST()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static string SearchModule(string module)
        {
            MedicalDBContext mdbc = new MedicalDBContext();
            var strModID = mdbc.tblModules.FirstOrDefault(mod => mod.strModID == module && mod.bIsDeleted != true);
            return strModID != null ? strModID.strModID : throw new Exception("Module name mismatch in Query");

            //// Create the connection
            //using (var connection = new SqlConnection())
            //{
            //    connection.ConnectionString = serverCon;

            //    var command = new SqlCommand("SELECT * FROM tblModules", connection);
            //    connection.Open();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            if ((string)reader[0] == module)
            //            {
            //                return (string)reader[1];
            //            }
            //        }
            //        connection.Close();
            //    }
            //}

        }
        #endregion

        #region ModuleList tblModules GET(){id}
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static List<QuestionInfo> ModuleList(string id)
        {
            MedicalDBContext mdbc = new MedicalDBContext();
            var lstQuestions = mdbc.tblQuestions.Where(question => question.bIsDeleted != true && question.strQuestionID == id).ToList();
            var queList = new List<QuestionInfo>();

            foreach (var question in lstQuestions)
            {
                var curQuestion = new QuestionInfo()
                {
                    Qid = question.strQuestionID,
                    Question = question.strQuestion,
                    Significance = question.strSignificance,
                    Unit = question.strUnit
                };
                queList.Add(curQuestion);
            }
            //using (var connect = new SqlConnection())
            //{
            //    connect.ConnectionString = serverCon;

            //    var command = new SqlCommand("SELECT * FROM tblQuestions", connect);
            //    connect.Open();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var queListBuild = new QuestionInfo()
            //            {
            //                Qid = (string)reader[0],
            //                Question = (string)reader[1],
            //                Significance = (string)reader[3],
            //                Unit = (string)reader[4]
            //            };
            //            if (queListBuild.Qid == id)
            //                queList.Add(queListBuild);
            //        }
            //        connect.Close();
            //    }
            //}

            return queList;
        }
        #endregion

        #region UxSurveyList tblTechExperience/tblUserExperience GET(){id}
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static List<UxSurvey> UxSurveyList(string id)
        {
            var mdbc = new MedicalDBContext();
            var lstQuestions = new List<UxSurvey>();
            switch (id)
            {
                case "Tx":
                    {
                        var Questions = mdbc.tblTechExperience.Where(question => question.bIsDeleted != true).ToList();
                        foreach (var item in Questions)
                        {
                            var survey = new UxSurvey()
                            {
                                Question = item.strQuestion,
                                Left = item.strTxQuestionL,
                                Slider = item.iTxQuestionM,
                                Right = item.strTxQuestionR
                            };
                            lstQuestions.Add(survey);
                        }
                    }
                    break;
                case "Ux":
                {
                    var Questions = mdbc.tblUserExperience.Where(question => question.bIsDeleted != true).ToList();
                    foreach (var item in Questions)
                    {
                        var survey = new UxSurvey()
                        {
                            Question = item.strQuestion,
                            Left = item.strUxQuestionL,
                            Slider = item.iUxQuestionM,
                            Right = item.strUxQuestionR
                        };
                        lstQuestions.Add(survey);
                    }
                }
                    break;
            }
            
            return lstQuestions;
        }
        #endregion

        #region ModuleAll tblModules GET()
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static List<ModuleInfo> ModuleAll()
        {
            // Create the connection
            var modList = new List<ModuleInfo>();
            using (var connect = new SqlConnection())
            {
                connect.ConnectionString = serverCon;

                var command = new SqlCommand("SELECT * FROM tblModules", connect);
                connect.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var modListBuild = new ModuleInfo
                        {
                            ModId = (string)reader[0],
                            ModName = (string)reader[1],
                            ModDesc = (string)reader[2],
                            ModSts = (string)reader[3]
                        };
                        modList.Add(modListBuild);
                    }
                    connect.Close();
                }
            }

            return modList;
        }
        #endregion

        #region ResultList tblModules GET(){id}
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of PatientInfo Objects</returns>
        public static List<ResultModel> ResultList(string id)
        {
            //QuestionModel question = null;
            var resultsList = new List<ResultModel>();
            MedicalDBContext mdbc = new MedicalDBContext();
            var lstResults = mdbc.tblResult.Where(result => result.bIsDeleted != true && result.strClientID == id)
                .ToList();
            if (lstResults.Count != 0)
            {
                var color = Color.Black;
                foreach (var result in lstResults)
                {
                    if (result.Result != null)
                    {
                        color = result.Result == "True" ? Color.Crimson : Color.Chartreuse;
                    }

                    ResultModel resultModel;
                    if (result.dtAddedBy != null)
                    {
                        resultModel = new ResultModel
                        {
                            Screened = color,
                            ModuleId = result.strModID,
                            Result = result.Result,
                            CurDateTime = result.dtAddedBy.Value.ToShortDateString() + " " + result.dtAddedBy.Value.ToShortTimeString()
                        };

                    }
                    else
                    {
                        resultModel = new ResultModel
                        {
                            Screened = color,
                            ModuleId = result.strModID,
                            Result = result.Result,
                            CurDateTime = DateTime.Now.ToLongDateString()
                        };

                    }
                    resultsList.Add(resultModel);
                }
            }
            //using (var connection = new SqlConnection())
            //{
            //    connection.ConnectionString = serverCon;
            //    var command = new SqlCommand("SELECT * FROM tblResult", connection);
            //    /*
            //    tblName | ID | ClientID | ModuleTested | TestData | Result | DateTime |
            //            |====|==========|==============|==========|========|==========|
            //    reader# | 0  | 1        | 2            | 3        | 4      | 5        |
            //    */
            //    connection.Open();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            var color = Color.Black;
            //            if ((string)reader[4] != "Null")
            //            {
            //                color = (string)reader[4] == "True" ? Color.Crimson : Color.Chartreuse;
            //            }

            //            var result = new ResultModel
            //            {
            //                Screened = color,
            //                ModuleId = (string)reader[2],
            //                Result = (string)reader[4],
            //                CurDateTime = (string)reader[5]
            //            };
            //            if ((string)reader[1] == id)
            //                resultsList.Add(result);
            //        }
            //    }
            //    connection.Close();
            //}

            return resultsList;
        }
        #endregion
    }
}