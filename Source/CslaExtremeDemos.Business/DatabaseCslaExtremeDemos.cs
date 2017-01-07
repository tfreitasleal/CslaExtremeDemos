using System.Configuration;

namespace CslaExtremeDemos.Business
{
    /// <summary>Class that provides the connection
    /// strings used by the application.</summary>
    internal static partial class Database
    {
        /// <summary>Connection string to the CslaExtremeDemos database.</summary>
        internal static string CslaExtremeDemosConnection
        {
            get { return ConfigurationManager.ConnectionStrings["CslaExtremeDemos"].ConnectionString; }
        }
    }
}
