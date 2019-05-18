using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Radius.UI.Models
{
    /// <summary>
    /// Cover that holds GET requests data.
    /// </summary>
    [Serializable]
    public class GitSearchModel
    {
        public string toalIssueCountQuery { get; set; }
        public string issuesCountInLast24HrsQuery { get; set; }
        public string issuesCountBtwn24HrsTo7DaysQuery { get; set; }
        public string issuesCountAfter7DaysQuery { get; set; }
    }
}