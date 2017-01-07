Imports System.ComponentModel

Namespace CslaExtremeDemos.BusinessVB
    Public Enum CivilStatus As Byte
        <Description("<Select state>")>
        Empty = 0
        <Description("Single")>
        Singleton
        <Description("Maried")>
        Maried
        <Description("Divorced")>
        Divorced
        <Description("Widowed")>
        Widowed
    End Enum
End Namespace