using System.Configuration;

namespace CslaExtremeDemos.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static partial class Database
    {
        /// <summary>Connection string to the CslaExtremeDemosDatabase database.</summary>
        internal static string CslaExtremeDemosDatabaseConnection
        {
            get { return ConfigurationManager.ConnectionStrings["CslaExtremeDemosDatabase"].ConnectionString; }
        }
    }
}
