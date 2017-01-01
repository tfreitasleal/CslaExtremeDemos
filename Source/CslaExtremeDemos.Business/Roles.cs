using System.ComponentModel;

namespace CslaExtremeDemos.Business
{
    public enum Roles : byte
    {
        [Description("<Select role>")]
        Empty = 0,
        [Description("Senior Developer")]
        Clerk,
        [Description("Team Leader")]
        Chief,
        [Description("Project Manager")]
        Governor,
        [Description("Chief Executive Officer")]
        Boss
    }
}