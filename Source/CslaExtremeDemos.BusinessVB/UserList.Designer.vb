Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports Csla
Imports Csla.Data


''' <summary>
''' UserList (read only list).<br/>
''' This is a generated base class of <see cref="UserList"/> business object.
''' This class is a root collection.
''' </summary>
''' <remarks>
''' The items of the collection are <see cref="UserInfo"/> objects.
''' </remarks>
<Serializable()>
Partial Public Class UserList
    Inherits ReadOnlyBindingListBase(Of UserList, UserInfo)

#Region " Collection Business Methods "

    ''' <summary>
    ''' Determines whether a <see cref="UserInfo"/> item is in the collection.
    ''' </summary>
    ''' <param name="userId">The UserId of the item to search for.</param>
    ''' <returns><c>true</c> if the UserInfo is a collection item; otherwise, <c>false</c>.</returns>
    Public Overloads Function Contains(userId As Integer) As Boolean
        For Each item As UserInfo In Me
            If item.UserId = userId Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

#Region " Private Fields "

    Private Shared _list As UserList

#End Region

#Region " Cache Management Methods "

    ''' <summary>
    ''' Clears the in-memory UserList cache so it is reloaded on the next request.
    ''' </summary>
    Public Shared Sub InvalidateCache()
        _list = Nothing
    End Sub

    ''' <summary>
    ''' Used by async loaders to load the cache.
    ''' </summary>
    ''' <param name="lst">The list to cache.</param>
    Friend Shared Sub SetCache(lst As UserList)
        _list = lst
    End Sub

    Friend Shared ReadOnly Property IsCached As Boolean
        Get
            Return _list IsNot Nothing
        End Get
    End Property

#End Region

#Region " Factory Methods "

    ''' <summary>
    ''' Factory method. Loads a <see cref="UserList"/> collection.
    ''' </summary>
    ''' <returns>A reference to the fetched <see cref="UserList"/> collection.</returns>
    Public Shared Function GetUserList() As UserList
        If _list Is Nothing Then
            _list = DataPortal.Fetch(Of UserList)()
        End If

        Return _list
    End Function

#End Region

#Region " Constructor "

    ''' <summary>
    ''' Initializes a new instance of the <see cref="UserList"/> class.
    ''' </summary>
    ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
    Public Sub New()
        ' Use factory methods and do not use direct creation.
        AddHandler User.UserSaved, AddressOf UserSavedHandler

        Dim rlce = RaiseListChangedEvents
        RaiseListChangedEvents = False
        AllowNew = False
        AllowEdit = False
        AllowRemove = False
        RaiseListChangedEvents = rlce
    End Sub

#End Region

#Region " Saved Event Handler "

    ''' <summary>
    ''' Handle Saved events of <see cref="User"/> to update the list of <see cref="UserInfo"/> objects.
    ''' </summary>
    ''' <param name="sender">The sender of the event.</param>
    ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
    Private Sub UserSavedHandler(sender As Object, e As Csla.Core.SavedEventArgs)
        Dim obj = CType(e.NewObject, User)
        If CType(sender, User).IsNew Then
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = True
            Add(UserInfo.LoadInfo(obj))
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        ElseIf CType(sender, User).IsDeleted Then
            For index = 0 To Count - 1
                Dim child = Me(index)
                If child.UserId = obj.UserId Then
                    IsReadOnly = False
                    Dim rlce = RaiseListChangedEvents
                    RaiseListChangedEvents = True
                    RemoveItem(index)
                    RaiseListChangedEvents = rlce
                    IsReadOnly = True
                    Exit For
                End If
            Next
        Else
            For index = 0 To Count - 1
                Dim child = Me(index)
                If child.UserId = obj.UserId Then
                    child.UpdatePropertiesOnSaved(obj)
                    Dim listChangedEventArgs As New ListChangedEventArgs(ListChangedType.ItemChanged, index)
                    OnListChanged(listChangedEventArgs)
                    Exit For
                End If
            Next
        End If
    End Sub

#End Region

#Region " Data Access "

    ''' <summary>
    ''' Loads a <see cref="UserList"/> collection from the database or from the cache.
    ''' </summary>
    Protected Overloads Sub DataPortal_Fetch()
        If IsCached Then
            LoadCachedList()
            Exit Sub
        End If

        Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.CslaExtremeDemosDatabaseConnection, False)
            Using cmd = New SqlCommand("dbo.GetUserList", ctx.Connection)
                cmd.CommandType = CommandType.StoredProcedure
                Dim args As New DataPortalHookArgs(cmd)
                OnFetchPre(args)
                LoadCollection(cmd)
                OnFetchPost(args)
            End Using
        End Using
        _list = Me
    End Sub

    Private Sub LoadCachedList()
        IsReadOnly = False
        Dim rlce = RaiseListChangedEvents
        RaiseListChangedEvents = False
        AddRange(_list)
        RaiseListChangedEvents = rlce
        IsReadOnly = True
    End Sub

    Private Sub LoadCollection(cmd As SqlCommand)
        Using dr As New SafeDataReader(cmd.ExecuteReader())
            Fetch(dr)
        End Using
    End Sub

    ''' <summary>
    ''' Loads all <see cref="UserList"/> collection items from the given SafeDataReader.
    ''' </summary>
    ''' <param name="dr">The SafeDataReader to use.</param>
    Private Sub Fetch(dr As SafeDataReader)
        IsReadOnly = False
        Dim rlce = RaiseListChangedEvents
        RaiseListChangedEvents = False
        While dr.Read()
            Add(DataPortal.FetchChild(Of UserInfo)(dr))
        End While
        RaiseListChangedEvents = rlce
        IsReadOnly = True
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

