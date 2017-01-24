Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' CountryCollection (editable root list).<br/>
    ''' This is a generated base class of <see cref="CountryCollection"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="CountryItem"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class CountryCollection
        Inherits BusinessBindingListBase(Of CountryCollection, CountryItem)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Adds a new <see cref="CountryItem"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        Public Overloads Sub Add(item As CountryItem)
            If Contains(item.CountryId) Then
                Throw New ArgumentException("CountryItem already exists.")
            End If

            Add(item)
        End Sub

        ''' <summary>
        ''' Removes a <see cref="CountryItem"/> item from the collection.
        ''' </summary>
        ''' <param name="countryId">The CountryId of the item to be removed.</param>
        Public Overloads Sub Remove(countryId As Short)
            For Each item As CountryItem In Me
                If item.CountryId = countryId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="CountryItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="countryId">The CountryId of the item to search for.</param>
        ''' <returns><c>True</c> if the CountryItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(countryId As Short) As Boolean
            For Each item As CountryItem In Me
                If item.CountryId = countryId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="CountryItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="countryId">The CountryId of the item to search for.</param>
        ''' <returns><c>True</c> if the CountryItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(countryId As Short) As Boolean
            For Each item As CountryItem In DeletedList
                If item.CountryId = countryId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="CountryCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="CountryCollection"/> collection.</returns>
        Public Shared Function NewCountryCollection() As CountryCollection
            Return DataPortal.Create(Of CountryCollection)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="CountryCollection"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="CountryCollection"/> collection.</returns>
        Public Shared Function GetCountryCollection() As CountryCollection
            Return DataPortal.Fetch(Of CountryCollection)()
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="CountryCollection"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
            AddHandler Saved, AddressOf OnCountryCollectionSaved

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = True
            AllowEdit = True
            AllowRemove = True
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Cache Invalidation "

        Private Sub OnCountryCollectionSaved(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            CountryNVL.InvalidateCache()
        End Sub

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
                CountryNVL.InvalidateCache()
            End If
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="CountryCollection"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.CslaExtremeDemosConnection, False)
                Using cmd = New SqlCommand("dbo.GetCountryCollection", ctx.Connection)
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
        ''' Loads all <see cref="CountryCollection"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DataPortal.FetchChild(Of CountryItem)(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="CountryCollection"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.CslaExtremeDemosConnection, False)
                Child_Update()
                ctx.Commit()
            End Using
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
