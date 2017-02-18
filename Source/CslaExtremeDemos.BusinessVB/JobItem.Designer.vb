Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' JobItem (editable child object).<br/>
    ''' This is a generated base class of <see cref="JobItem"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="JobCollection"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class JobItem
        Inherits BusinessBase(Of JobItem)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="JobId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly JobIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.JobId, "Job Id")
        ''' <summary>
        ''' Gets the Job Id.
        ''' </summary>
        ''' <value>The Job Id.</value>
        Public ReadOnly Property JobId As Integer
            Get
                Return GetProperty(JobIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CompanyName"/> property.
        ''' </summary>
        Public Shared ReadOnly CompanyNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.CompanyName, "Company Name")
        ''' <summary>
        ''' Gets or sets the Company Name.
        ''' </summary>
        ''' <value>The Company Name.</value>
        Public Property CompanyName As String
            Get
                Return GetProperty(CompanyNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(CompanyNameProperty, value)
            End Set
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="JobItem"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="JobItem"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub Child_Create()
            LoadProperty(JobIdProperty, System.Threading.Interlocked.Decrement(_lastId))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.Child_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="JobItem"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(JobIdProperty, dr.GetInt32("JobId"))
            LoadProperty(CompanyNameProperty, dr.GetString("CompanyName"))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="JobItem"/> object in the database.
        ''' </summary>
        ''' <param name="parent">The parent object.</param>
        Private Sub Child_Insert(parent As Person)
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.AddJobItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@PersonId", parent.PersonId).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@JobId", ReadProperty(JobIdProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@CompanyName", ReadProperty(CompanyNameProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(JobIdProperty, DirectCast(cmd.Parameters("@JobId").Value, Integer))
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="JobItem"/> object.
        ''' </summary>
        Private Sub Child_Update()
            If Not IsDirty
                return
            End If

            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.UpdateJobItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@JobId", ReadProperty(JobIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@CompanyName", ReadProperty(CompanyNameProperty)).DbType = DbType.String
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="JobItem"/> object from database.
        ''' </summary>
        Private Sub Child_DeleteSelf()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.DeleteJobItem", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@JobId", ReadProperty(JobIdProperty)).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
            End Using
        End Sub

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
