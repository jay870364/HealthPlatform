using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bossinfo.HealthPlatform.Models.TaiDoc
{
    [Serializable]
    public class Feedback
    {
        public string RuleType { get; set; }

        public string MessageType { get; set; }

        public string FeedbackTime { get; set; }

        public int FeedbackContent { get; set; }
    }
}