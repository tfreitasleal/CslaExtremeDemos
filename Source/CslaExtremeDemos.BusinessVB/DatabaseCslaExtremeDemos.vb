Imports System.Configuration


''' <summary>Class that provides the connection
''' strings used by the application.</summary>
Partial Friend Class Database
    ''' <summary>Connection string to the CslaExtremeDemosDatabase database.</summary>
    Friend Shared ReadOnly Property CslaExtremeDemosDatabaseConnection As String
        Get
            Return ConfigurationManager.ConnectionStrings("CslaExtremeDemosDatabase").ConnectionString
        End Get
    End Property
End Class


