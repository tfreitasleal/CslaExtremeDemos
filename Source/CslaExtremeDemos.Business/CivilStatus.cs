using System.ComponentModel;

namespace CslaExtremeDemos.Business
{
    public enum CivilStatus : byte
    {
        [Description("<Select status>")]
        Empty = 0,
        [Description("Single")]
        Singleton,
        [Description("Maried")]
        Maried,
        [Description("Divorced")]
        Divorced,
        [Description("Widowed")]
        Widowed
    }
}