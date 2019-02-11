using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace AGS.ServerAPI.DAL_Models
{
    /// <summary>
    /// Description:    This class will model the receive data from the app
    ///                 in the proper POST method
    /// Status:         Creating
    /// </summary>
    [DataContract]
    public class SurveyInfo
    {
        [DataMember (Name = "modID")]
        public string ModId { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }

        [DataMember(Name = "saID")]
        public string Said { get; set; }

        [DataMember(Name = "dateTime")]
        public DateTime DateTime { get; set; }
    }

    /// <summary>
    /// Description:    This class will model question info to be sent to the app
    /// Status:         Creating
    /// </summary>
    public class QuestionInfo
    {
        public string Qid { get; set; }
        public string Question { get; set; }
        public string Significance { get; set; }
        public string Unit { get; set; }
    }

    public class AnswerModel
    {
        // TestData
        public List<string> ParametersVad { get; set; }
        public string Age { get; set; }
        public string Waist { get; set; }
        public string Systolic { get; set; }
        public string ModuleId { get; set; }
        // ClientData
        public string Said { get; set; }
        // EnvironmentData
        public DateTime CurDateTime { get; set; }
    }

    public class ResultModel
    {
        // TestData
        public string ModuleId { get; set; }
        // TestData
        public Color Screened { get; set; }
        public string Result { get; set; }
        // EnvironmentData
        public string CurDateTime { get; set; }
    }

    public class UxSurvey
    {
        public string Question { get; set; }
        public string Left { get; set; }
        public int Slider { get; set; }
        public string Right { get; set; }
    }
}