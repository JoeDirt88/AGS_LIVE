namespace AGS.ServerAPI.View_Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
    }

    public class UxSurvey
    {
        public string Question { get; set; }
        public string Left { get; set; }
        public int Slider { get; set; }
        public string Right { get; set; }
    }

    public class UxResult
    {
        public string strEmail { get; set; }
        public string strPhone { get; set; }
        public string strOccupation { get; set; }
        public string iExperienceTypeID { get; set; }
        public string strAnswers { get; set; }
        public double iAverage { get; set; }
    }

    public class FbResult
    {
        public string strEmail { get; set; }
        public string strContactNumber { get; set; }
        public string strReport { get; set; }
    }
}