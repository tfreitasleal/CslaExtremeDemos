Imports System.Configuration

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>Class that provides the connection
    ''' strings used by the application.</summary>
    Partial Friend Class Database

        ''' <summary>Connection string to the CslaExtremeDemos database.</summary>
        Friend Shared ReadOnly Property CslaExtremeDemosConnection As String
            Get
                Return ConfigurationManager.ConnectionStrings("CslaExtremeDemos").ConnectionString
            End Get
        End Property

    End Class

End Namespace
