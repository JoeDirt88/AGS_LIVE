using System.Collections.Generic;

namespace AGS.ServerAPI.View_Models
{
    public class AllStats
    {
        public List<clsClients> Clients { get; set; }
        public List<clsUsers> Users { get; set; }
        public List<clsUserExperience> Uxs { get; set; }
        public List<clsTechExperience> Txs { get; set; }
        public List<clsExperienceAnswers> Xans { get; set; }
        public List<clsResult> Results { get; set; }
    }
}