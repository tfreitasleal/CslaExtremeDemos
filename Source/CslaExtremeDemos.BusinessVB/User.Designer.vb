Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules.CommonRules
Imports CslaExtremeDemos.Rules
Imports System.ComponentModel.DataAnnotations

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' User (editable root object).<br/>
    ''' This is a generated base class of <see cref="User"/> business object.
    ''' </summary>
    <Serializable()>
    Partial Public Class User
    Inherits BusinessBase(Of User)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="UserId"/> property.
        ''' </summary>
        <NotUndoable>
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
        ''' Gets or sets the First Name.
        ''' </summary>
        ''' <value>The First Name.</value>
        <Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")>
        Public Property FirstName As String
            Get
                Return GetProperty(FirstNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(FirstNameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="MiddleName"/> property.
        ''' </summary>
        Public Shared ReadOnly MiddleNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.MiddleName, "Middle Name")
        ''' <summary>
        ''' Gets or sets the Middle Name.
        ''' </summary>
        ''' <value>The Middle Name.</value>
        Public Property MiddleName As String
            Get
                Return GetProperty(MiddleNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(MiddleNameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="LastName"/> property.
        ''' </summary>
        Public Shared ReadOnly LastNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.LastName, "Last Name")
        ''' <summary>
        ''' Gets or sets the Last Name.
        ''' </summary>
        ''' <value>The Last Name.</value>
        <Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")>
        Public Property LastName As String
            Get
                Return GetProperty(LastNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(LastNameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="MaritalStatus"/> property.
        ''' </summary>
        Public Shared ReadOnly MaritalStatusProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.MaritalStatus, "Marital Status")
        ''' <summary>
        ''' Gets or sets the Marital Status.
        ''' </summary>
        ''' <value>The Marital Status.</value>
        Public Property MaritalStatus As CivilStatus
            Get
                Return GetPropertyConvert(Of Byte, CivilStatus)(MaritalStatusProperty)
            End Get
            Set(ByVal value As CivilStatus)
                SetPropertyConvert(Of Byte, CivilStatus)(MaritalStatusProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Role"/> property.
        ''' </summary>
        Public Shared ReadOnly RoleProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.Role, "Role")
        ''' <summary>
        ''' Gets or sets the Role.
        ''' </summary>
        ''' <value>The Role.</value>
        Public Property Role As Roles
            Get
                Return GetPropertyConvert(Of Byte, Roles)(RoleProperty)
            End Get
            Set(ByVal value As Roles)
                SetPropertyConvert(Of Byte, Roles)(RoleProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DeptId"/> property.
        ''' </summary>
        Public Shared ReadOnly DeptIdProperty As PropertyInfo(Of Short?) = RegisterProperty(Of Short?)(Function(p) p.DeptId, "Dept")
        ''' <summary>
        ''' Gets or sets the Dept.
        ''' </summary>
        ''' <value>The Dept.</value>
        Public Property DeptId As Short?
            Get
                Return GetProperty(DeptIdProperty)
            End Get
            Set(ByVal value As Short?)
                SetProperty(DeptIdProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="User"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="User"/> object.</returns>
        Public Shared Function NewUser() As User
            Return DataPortal.Create(Of User)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="User"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="userId">The UserId parameter of the User to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="User"/> object.</returns>
        Public Shared Function GetUser(userId As Integer) As User
            Return DataPortal.Fetch(Of User)(userId)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="User"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnUserSaved
            AddHandler UserSaved, AddressOf UserSavedHandler
        End Sub

        #End Region

        #Region " Cache Invalidation "

        Private Sub UserSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            UserList.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                UserList.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Business Rules and Property Authorization "

        ''' <summary>
        ''' Override this method in your business class to be notified when you need to set up shared business rules.
        ''' </summary>
        ''' <remarks>
        ''' This method is automatically called by CSLA.NET when your object should associate
        ''' per-type validation rules with its properties.
        ''' </remarks>
        Protected Overrides Sub AddBusinessRules()
            MyBase.AddBusinessRules()

            ' Property Business Rules

            ' FirstName
            BusinessRules.AddRule(New MaxLength(FirstNameProperty, 50))
            ' MiddleName
            BusinessRules.AddRule(New MaxLength(MiddleNameProperty, 50))
            ' LastName
            BusinessRules.AddRule(New MaxLength(LastNameProperty, 50))
            ' MaritalStatus
            BusinessRules.AddRule(New EnumNotZero(MaritalStatusProperty) With { .MessageText = "Must specify Marital Status." })

            AddBusinessRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom shared business rules.
        ''' </summary>
        Partial Private Sub AddBusinessRulesExtend()
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="User"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(UserIdProperty, System.Threading.Interlocked.Decrement(_lastId))
            LoadProperty(MiddleNameProperty, Nothing)
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="User"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="userId">The User Id.</param>
        Protected Sub DataPortal_Fetch(userId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.GetUser", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@UserId", userId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, userId)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="User"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(UserIdProperty, dr.GetInt32("UserId"))
            LoadProperty(FirstNameProperty, dr.GetString("FirstName"))
            LoadProperty(MiddleNameProperty, If(dr.IsDBNull("MiddleName"), Nothing, dr.GetString("MiddleName")))
            LoadProperty(LastNameProperty, dr.GetString("LastName"))
            LoadProperty(MaritalStatusProperty, dr.GetByte("MaritalStatusId"))
            LoadProperty(RoleProperty, dr.GetByte("RoleId"))
            LoadProperty(DeptIdProperty, DirectCast(dr.GetValue("DeptId"), Short?))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="User"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.AddUser", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@MiddleName", If(ReadProperty(MiddleNameProperty) Is Nothing, DBNull.Value, ReadProperty(MiddleNameProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@MaritalStatusId", ReadProperty(MaritalStatusProperty)).DbType = DbType.Byte
                    ' For nullable PropertyConvert, null (Nothing) is persisted if the backing field is zero
                    cmd.Parameters.AddWithValue("@RoleId", If(ReadProperty(RoleProperty) = 0, DBNull.Value, ReadProperty(RoleProperty))).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@DeptId", If(ReadProperty(DeptIdProperty) Is Nothing, DBNull.Value, ReadProperty(DeptIdProperty).Value)).DbType = DbType.Int16
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(UserIdProperty, DirectCast(cmd.Parameters("@UserId").Value, Integer))
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="User"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.UpdateUser", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@MiddleName", If(ReadProperty(MiddleNameProperty) Is Nothing, DBNull.Value, ReadProperty(MiddleNameProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@MaritalStatusId", ReadProperty(MaritalStatusProperty)).DbType = DbType.Byte
                    ' For nullable PropertyConvert, null (Nothing) is persisted if the backing field is zero
                    cmd.Parameters.AddWithValue("@RoleId", If(ReadProperty(RoleProperty) = 0, DBNull.Value, ReadProperty(RoleProperty))).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@DeptId", If(ReadProperty(DeptIdProperty) Is Nothing, DBNull.Value, ReadProperty(DeptIdProperty).Value)).DbType = DbType.Int16
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " Saved Event "

        Private Sub OnUserSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent UserSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="User"/> object was saved.</summary>
        Public Shared Event UserSaved As EventHandler(Of Csla.Core.SavedEventArgs)

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the update operation.
        ''' </summary>
        Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        ''' </summary>
        Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class

End Namespace
