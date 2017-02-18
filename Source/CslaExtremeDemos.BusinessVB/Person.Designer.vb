Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' Person (editable root object).<br/>
    ''' This is a generated base class of <see cref="Person"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class contains one child collection:<br/>
    ''' - <see cref="Jobs"/> of type <see cref="JobCollection"/> (1:M relation to <see cref="JobItem"/>)
    ''' </remarks>
    <Serializable>
    Public Partial Class Person
        Inherits BusinessBase(Of Person)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="PersonId"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly PersonIdProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.PersonId, "Person Id")
        ''' <summary>
        ''' Gets the Person Id.
        ''' </summary>
        ''' <value>The Person Id.</value>
        Public ReadOnly Property PersonId As Integer
            Get
                Return GetProperty(PersonIdProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Name"/> property.
        ''' </summary>
        Public Shared ReadOnly NameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.Name, "Name")
        ''' <summary>
        ''' Gets or sets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(NameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Gender"/> property.
        ''' </summary>
        Public Shared ReadOnly GenderProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.Gender, "Gender")
        ''' <summary>
        ''' Gets or sets the Gender.
        ''' </summary>
        ''' <value>The Gender.</value>
        Public Property Gender As Byte
            Get
                Return GetProperty(GenderProperty)
            End Get
            Set(ByVal value As Byte)
                SetProperty(GenderProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="BirthDate"/> property.
        ''' </summary>
        Public Shared ReadOnly BirthDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.BirthDate, "Birth Date")
        ''' <summary>
        ''' Gets or sets the Birth Date.
        ''' </summary>
        ''' <value>The Birth Date.</value>
        Public Property BirthDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(BirthDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(BirthDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="BirthCountryId"/> property.
        ''' </summary>
        Public Shared ReadOnly BirthCountryIdProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.BirthCountryId, "Birth Country Id")
        ''' <summary>
        ''' Gets or sets the Birth Country Id.
        ''' </summary>
        ''' <value>The Birth Country Id.</value>
        Public Property BirthCountryId As Short
            Get
                Return GetProperty(BirthCountryIdProperty)
            End Get
            Set(ByVal value As Short)
                SetProperty(BirthCountryIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="GraduationDate"/> property.
        ''' </summary>
        Public Shared ReadOnly GraduationDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.GraduationDate, "Graduation Date")
        ''' <summary>
        ''' Gets or sets the Graduation Date.
        ''' </summary>
        ''' <value>The Graduation Date.</value>
        Public Property GraduationDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(GraduationDateProperty)
            End Get
            Set(ByVal value As String)
                SetPropertyConvert(Of SmartDate, String)(GraduationDateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="GraduationCollege"/> property.
        ''' </summary>
        Public Shared ReadOnly GraduationCollegeProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.GraduationCollege, "Graduation College")
        ''' <summary>
        ''' Gets or sets the Graduation College.
        ''' </summary>
        ''' <value>The Graduation College.</value>
        Public Property GraduationCollege As String
            Get
                Return GetProperty(GraduationCollegeProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(GraduationCollegeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="GraduationCountryId"/> property.
        ''' </summary>
        Public Shared ReadOnly GraduationCountryIdProperty As PropertyInfo(Of Short?) = RegisterProperty(Of Short?)(Function(p) p.GraduationCountryId, "Graduation Country Id")
        ''' <summary>
        ''' Gets or sets the Graduation Country Id.
        ''' </summary>
        ''' <value>The Graduation Country Id.</value>
        Public Property GraduationCountryId As Short?
            Get
                Return GetProperty(GraduationCountryIdProperty)
            End Get
            Set(ByVal value As Short?)
                SetProperty(GraduationCountryIdProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="GraduationDegree"/> property.
        ''' </summary>
        Public Shared ReadOnly GraduationDegreeProperty As PropertyInfo(Of Byte?) = RegisterProperty(Of Byte?)(Function(p) p.GraduationDegree, "Graduation Degree")
        ''' <summary>
        ''' Gets or sets the Graduation Degree.
        ''' </summary>
        ''' <value>The Graduation Degree.</value>
        Public Property GraduationDegree As Byte?
            Get
                Return GetProperty(GraduationDegreeProperty)
            End Get
            Set(ByVal value As Byte?)
                SetProperty(GraduationDegreeProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about child <see cref="Jobs"/> property.
        ''' </summary>
        Public Shared ReadOnly JobsProperty As PropertyInfo(Of JobCollection) = RegisterProperty(Of JobCollection)(Function(p) p.Jobs, "Jobs", RelationshipTypes.Child)
        ''' <summary>
        ''' Gets the Jobs ("parent load" child property).
        ''' </summary>
        ''' <value>The Jobs.</value>
        Public Property Jobs As JobCollection
            Get
                Return GetProperty(JobsProperty)
            End Get
            Private Set(ByVal value As JobCollection)
                LoadProperty(JobsProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="Person"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="Person"/> object.</returns>
        Public Shared Function NewPerson() As Person
            Return DataPortal.Create(Of Person)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="Person"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="personId">The PersonId parameter of the Person to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="Person"/> object.</returns>
        Public Shared Function GetPerson(personId As Integer) As Person
            Return DataPortal.Fetch(Of Person)(personId)
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="Person"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnPersonSaved
            AddHandler PersonSaved, AddressOf PersonSavedHandler
        End Sub

        #End Region

        #Region " Cache Invalidation "

        Private Sub PersonSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            PersonList.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                PersonList.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="Person"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(PersonIdProperty, System.Threading.Interlocked.Decrement(_lastId))
            LoadProperty(GraduationDateProperty, Nothing)
            LoadProperty(GraduationCollegeProperty, Nothing)
            LoadProperty(JobsProperty, DataPortal.CreateChild(Of JobCollection)())
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="Person"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="personId">The Person Id.</param>
        Protected Sub DataPortal_Fetch(personId As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.GetPerson", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@PersonId", personId).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, personId)
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
                    FetchChildren(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="Person"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(PersonIdProperty, dr.GetInt32("PersonId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(GenderProperty, dr.GetByte("Gender"))
            LoadProperty(BirthDateProperty, dr.GetSmartDate("BirthDate", True))
            LoadProperty(BirthCountryIdProperty, dr.GetInt16("BirthCountryId"))
            LoadProperty(GraduationDateProperty, If(dr.IsDBNull("GraduationDate"), Nothing, dr.GetSmartDate("GraduationDate", True)))
            LoadProperty(GraduationCollegeProperty, If(dr.IsDBNull("GraduationCollege"), Nothing, dr.GetString("GraduationCollege")))
            LoadProperty(GraduationCountryIdProperty, DirectCast(dr.GetValue("GraduationCountryId"), Short?))
            LoadProperty(GraduationDegreeProperty, DirectCast(dr.GetValue("GraduationDegree"), Byte?))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Loads child objects from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub FetchChildren(dr As SafeDataReader)
            dr.NextResult()
            LoadProperty(JobsProperty, DataPortal.FetchChild(Of JobCollection)(dr))
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="Person"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.AddPerson", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Gender", ReadProperty(GenderProperty)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@BirthDate", ReadProperty(BirthDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@BirthCountryId", ReadProperty(BirthCountryIdProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@GraduationDate", ReadProperty(GraduationDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@GraduationCollege", If(ReadProperty(GraduationCollegeProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationCollegeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@GraduationCountryId", If(ReadProperty(GraduationCountryIdProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationCountryIdProperty).Value)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@GraduationDegree", If(ReadProperty(GraduationDegreeProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationDegreeProperty).Value)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(PersonIdProperty, DirectCast(cmd.Parameters("@PersonId").Value, Integer))
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="Person"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.UpdatePerson", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@Gender", ReadProperty(GenderProperty)).DbType = DbType.Byte
                    cmd.Parameters.AddWithValue("@BirthDate", ReadProperty(BirthDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@BirthCountryId", ReadProperty(BirthCountryIdProperty)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@GraduationDate", ReadProperty(GraduationDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@GraduationCollege", If(ReadProperty(GraduationCollegeProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationCollegeProperty))).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@GraduationCountryId", If(ReadProperty(GraduationCountryIdProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationCountryIdProperty).Value)).DbType = DbType.Int16
                    cmd.Parameters.AddWithValue("@GraduationDegree", If(ReadProperty(GraduationDegreeProperty) Is Nothing, DBNull.Value, ReadProperty(GraduationDegreeProperty).Value)).DbType = DbType.Byte
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                End Using
                ' flushes all pending data operations
                FieldManager.UpdateChildren(Me)
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " Saved Event "

        Private Sub OnPersonSaved(sender As Object, e As Csla.Core.SavedEventArgs)
                RaiseEvent PersonSaved(sender, e)
        End Sub

        ''' <summary> Use this event to signal a <see cref="Person"/> object was saved.</summary>
        Public Shared Event PersonSaved As EventHandler(Of Csla.Core.SavedEventArgs)

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
