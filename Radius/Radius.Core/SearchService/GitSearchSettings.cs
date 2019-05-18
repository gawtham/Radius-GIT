using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radius.Core.SearchService
{
    /// <summary>
    /// This class is responsible for fetching setting to create GET requests Git Respsitories
    /// </summary>
    public class GitSearchSettings : SearchSettings
    {
        private const string linkPrefix = "https://api.github.com/search/issues?";
        public GitSearchSettings(string rawLink) : base(rawLink)
        {
        }

        /// <summary>
        /// Cleans the string
        /// Ideally user want to input git httplink or .git or repo path.
        /// </summary>
        /// <param name="rawString"></param>
        /// <returns></returns>
        public override string FormatString(string rawString)
        {
            var res = rawString.Replace("https://github.com/", "").Replace(".git", "");
            return res;
        }

        /// <summary>
        /// Creates a Query string to fetch count after the timestamp
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override string AfterQuery(DateTime time)
        {
            var date = string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", time.Year, withPrefix(time.Month), withPrefix(time.Day), withPrefix(time.Hour), withPrefix(time.Minute), withPrefix(time.Second));
            var res = string.Format("q=created:>{0}+state:open+repo:{1}", date, RepoName);
            return linkPrefix + res;
        }

        /// <summary>
        /// Creates a Query string to fetch count before the timestamp
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override string BeforeQuery(DateTime time)
        {
            var date = string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", time.Year, withPrefix(time.Month), withPrefix(time.Day), withPrefix(time.Hour), withPrefix(time.Minute), withPrefix(time.Second));
            var res = string.Format("q=created:<{0}+state:open+repo:{1}", date, RepoName);
            return linkPrefix + res;
        }

        /// <summary>
        /// Creates a Query string to fetch count between the timestamps
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public override string BetweenQuery(DateTime start, DateTime end)
        {
            var startDate = string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", start.Year, withPrefix(start.Month), withPrefix(start.Day), 
                withPrefix(start.Hour), withPrefix(start.Minute), withPrefix(start.Second));
            var endDate = string.Format("{0}-{1}-{2}T{3}:{4}:{5}Z", end.Year, withPrefix(end.Month), withPrefix(end.Day), 
                withPrefix(end.Hour), withPrefix(end.Minute), withPrefix(end.Second));
            var res = string.Format("q=created:{0}..{1}+state:open+repo:{2}", startDate, endDate, RepoName);
            return linkPrefix + res;
        }

        /// <summary>
        /// Open Query to fetches everthing in the repo
        /// </summary>
        /// <returns></returns>
        public override string ToalIssueCountQuery()
        {
            var res = string.Format("q=state:open+repo:{0}", RepoName);
            return linkPrefix + res;
        }

        /// <summary>
        /// The query string is expected to be in standard number format with '0' prefix.
        /// This method is responsible to left-pad the number
        /// </summary>
        /// <param name="val"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string withPrefix(int val, int len = 2)
        {
            return val.ToString("".PadLeft(len, '0'));
        }
    }
}
