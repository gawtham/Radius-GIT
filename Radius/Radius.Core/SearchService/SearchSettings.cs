using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radius.Core.SearchService
{
    public abstract class SearchSettings
    {
        public string RepoName { get; private set; }
        public SearchSettings(string rawLink)
        {
            RepoName = FormatString(rawLink);
        }
        public abstract string FormatString(string rawString);
        public abstract string AfterQuery(DateTime time);
        public abstract string BeforeQuery(DateTime time);
        public abstract string BetweenQuery(DateTime start, DateTime end);
        public abstract string ToalIssueCountQuery();
    }
}
