Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' UserInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="UserInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="UserList"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class UserInfo
    Inherits ReadOnlyBase(Of UserInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="UserId"/> property.
        ''' </summary>
        Public Shared ReadOnly UserIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.UserId, "User Id")
        ''' <summary>
        ''' Gets the User Id.
        ''' </summary>
        ''' <value>The User Id.</value>
        Public ReadOnly Property UserId As Integer
            Get
                Return GetProperty(UserIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FirstName"/> property.
        ''' </summary>
        Public Shared ReadOnly FirstNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FirstName, "First Name")
        ''' <summary>
        ''' Gets the First Name.
        ''' </summary>
        ''' <value>The First Name.</value>
        Public ReadOnly Property FirstName As String
            Get
                Return GetProperty(FirstNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="MiddleName"/> property.
        ''' </summary>
        Public Shared ReadOnly MiddleNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.MiddleName, "Middle Name", New String(Nothing))
        ''' <summary>
        ''' Gets the Middle Name.
        ''' </summary>
        ''' <value>The Middle Name.</value>
        Public ReadOnly Property MiddleName As String
            Get
                Return GetProperty(MiddleNameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="LastName"/> property.
        ''' </summary>
        Public Shared ReadOnly LastNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.LastName, "Last Name")
        ''' <summary>
        ''' Gets the Last Name.
        ''' </summary>
        ''' <value>The Last Name.</value>
        Public ReadOnly Property LastName As String
            Get
                Return GetProperty(LastNameProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="UserInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="UserInfo"/> object is updated by <see cref="User"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(user As User) As UserInfo
            Dim info As New UserInfo()
            info.UpdatePropertiesOnSaved(user)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="UserInfo"/> object are updated by <see cref="User"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(user As User)
            LoadProperty(UserIdProperty, user.UserId)
            LoadProperty(FirstNameProperty, user.FirstName)
            LoadProperty(MiddleNameProperty, user.MiddleName)
            LoadProperty(LastNameProperty, user.LastName)
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="UserInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(UserIdProperty, dr.GetInt32("UserId"))
            LoadProperty(FirstNameProperty, dr.GetString("FirstName"))
            LoadProperty(MiddleNameProperty, If(dr.IsDBNull("MiddleName"), Nothing, dr.GetString("MiddleName")))
            LoadProperty(LastNameProperty, dr.GetString("LastName"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace
