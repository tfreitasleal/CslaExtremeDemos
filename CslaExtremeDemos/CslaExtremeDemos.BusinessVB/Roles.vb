Imports System.ComponentModel

Namespace CslaExtremeDemos.BusinessVB
    Public Enum Roles As Byte

        <Description("<Select role>")>
        Empty = 0
        <Description("Senior Developer")>
        Clerk
        <Description("Team Leader")>
        Chief
        <Description("Project Manager")>
        Governor
        <Description("Chief Executive Officer")>
        Boss
    End Enum
End Namespace