Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports Csla.Rules.CommonRules
Imports CslaGenFork.Rules.CollectionRules
Imports System.ComponentModel.DataAnnotations

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' DeptItem (dynamic root object).<br/>
    ''' This is a generated base class of <see cref="DeptItem"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DeptCollection"/> collection.
    ''' </remarks>
    <Serializable()>
    Partial Public Class DeptItem
    Inherits BusinessBase(Of DeptItem)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DeptId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly DeptIdProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.DeptId, "Dept Id")
        ''' <summary>
        ''' Gets or sets the Dept Id.
        ''' </summary>
        ''' <value>The Dept Id.</value>
        Public Property DeptId As Short
            Get
                Return GetProperty(DeptIdProperty)
            End Get
            Set(ByVal value As Short)
                SetProperty(DeptIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DeptName"/> property.
        ''' </summary>
        Public Shared ReadOnly DeptNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DeptName, "Dept Name")
        ''' <summary>
        ''' Gets or sets the Dept Name.
        ''' </summary>
        ''' <value>The Dept Name.</value>
        <Required(AllowEmptyStrings := false, ErrorMessage := "Must fill.")>
        Public Property DeptName As String
            Get
                Return GetProperty(DeptNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(DeptNameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="IsActive"/> property.
        ''' </summary>
        Public Shared ReadOnly IsActiveProperty As PropertyInfo(Of Boolean) = RegisterProperty(Of Boolean)(Function(p) p.IsActive, "Is Active")
        ''' <summary>
        ''' Gets or sets the Is Active.
        ''' </summary>
        ''' <value><c>True</c> if Is Active; otherwise, <c>false</c>.</value>
        Public Property IsActive As Boolean
            Get
                Return GetProperty(IsActiveProperty)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(IsActiveProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DeptItem"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnDeptItemSaved
            AddHandler DeptItemSaved, AddressOf DeptItemSavedHandler
        End Sub

        #End Region

        #Region " Cache Invalidation "

        Private Sub DeptItemSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            DeptNVL.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                DeptNVL.InvalidateCache()
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

            ' DeptName
            BusinessRules.AddRule(New MaxLength(DeptNameProperty, 50))
            BusinessRules.AddRule(New NoDuplicates(DeptNameProperty, "Department names can't be repeated."))

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
        ''' Loads default values for the <see cref="DeptItem"/> object properties.
        ''' </summary>
        <Csla.RunLocal()>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(IsActiveProperty, true)
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DeptItem"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub DataPortal_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DeptIdProperty, dr.GetInt16("DeptId"))
            LoadProperty(DeptNameProperty, dr.GetString("DeptName"))
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DeptItem"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.AddDeptItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@DeptName", ReadProperty(DeptNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(DeptIdProperty, DirectCast(cmd.Parameters("@DeptId").Value, Short))
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DeptItem"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.UpdateDeptItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@DeptName", ReadProperty(DeptNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DeptItem"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(DeptId)
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="DeptItem"/> object from database.
        ''' </summary>
        ''' <param name="deptId">The delete criteria.</param>
        Protected Sub DataPortal_Delete(deptId As Short)
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.DeleteDeptItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DeptId", deptId).DbType = DbType.Int16
                    Dim args As New DataPortalHookArgs(cmd, deptId)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " Saved Event "

        Private Sub OnDeptItemSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent DeptItemSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="DeptItem"/> object was saved.</summary>
        Public Shared Event DeptItemSaved As EventHandler(Of Csla.Core.SavedEventArgs)

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        ''' </summary>
        Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after the delete operation, before Commit().
        ''' </summary>
        Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
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
