using System.ComponentModel;

namespace CslaExtremeDemos.Business
{
    public enum CivilStates : byte
    {
        [Description("<Select state>")]
        Empty = 0,
        [Description("Single")]
        Singleton,
        [Description("Maried")]
        Maried,
        [Description("Divorced")]
        Divorced,
        [Description("Widower")]
        Widower
    }
}