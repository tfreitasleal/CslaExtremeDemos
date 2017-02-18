Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' DeptCollection (dynamic root list).<br/>
    ''' This is a generated base class of <see cref="DeptCollection"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DeptItem"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DeptCollection
        Inherits DynamicBindingListBase(Of DeptItem)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Adds a new <see cref="DeptItem"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        Public Overloads Sub Add(item As DeptItem)
            If Contains(item.DeptId) Then
                Throw New ArgumentException("DeptItem already exists.")
            End If

            Add(item)
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DeptItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="deptId">The DeptId of the item to search for.</param>
        ''' <returns><c>True</c> if the DeptItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(deptId As Short) As Boolean
            For Each item As DeptItem In Me
                If item.DeptId = deptId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Find Methods "

        ''' <summary>
        ''' Finds a <see cref="DeptItem"/> item of the <see cref="DeptCollection"/> collection, based on a given DeptName.
        ''' </summary>
        ''' <param name="deptName">The DeptName.</param>
        ''' <returns>A <see cref="DeptItem"/> object.</returns>
        Public Function FindDeptItemByDeptName(deptName As String) As DeptItem
            For i As Integer = 0 To Me.Count - 1
                If Me(i).DeptName.Equals(deptName) Then
                    Return Me(i)
                End If
            Next i

            Return Nothing
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DeptCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DeptCollection"/> collection.</returns>
        Public Shared Function NewDeptCollection() As DeptCollection
            Return DataPortal.Create(Of DeptCollection)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DeptCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DeptCollection"/> collection.</returns>
        Public Shared Function GetDeptCollection() As DeptCollection
            Return DataPortal.Fetch(Of DeptCollection)()
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DeptCollection"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DeptCollection"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.GetDeptCollection", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DeptCollection"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.Fetch(Of DeptItem)(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " DataPortal Hooks "

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

        #End Region

    End Class
End Namespace
