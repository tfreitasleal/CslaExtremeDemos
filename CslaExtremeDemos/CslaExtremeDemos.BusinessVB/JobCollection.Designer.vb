Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' JobCollection (editable child list).<br/>
    ''' This is a generated base class of <see cref="JobCollection"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="Person"/> editable root object.<br/>
    ''' The items of the collection are <see cref="JobItem"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class JobCollection
        Inherits BusinessBindingListBase(Of JobCollection, JobItem)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Removes a <see cref="JobItem"/> item from the collection.
        ''' </summary>
        ''' <param name="jobId">The JobId of the item to be removed.</param>
        Public Overloads Sub Remove(jobId As Integer)
            For Each item As JobItem In Me
                If item.JobId = jobId Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="JobItem"/> item is in the collection.
        ''' </summary>
        ''' <param name="jobId">The JobId of the item to search for.</param>
        ''' <returns><c>True</c> if the JobItem is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(jobId As Integer) As Boolean
            For Each item As JobItem In Me
                If item.JobId = jobId Then
                    Return True
                End If
            Next
            Return False
        End Function

        ''' <summary>
        ''' Determines whether a <see cref="JobItem"/> item is in the collection's DeletedList.
        ''' </summary>
        ''' <param name="jobId">The JobId of the item to search for.</param>
        ''' <returns><c>True</c> if the JobItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function ContainsDeleted(jobId As Integer) As Boolean
            For Each item As JobItem In DeletedList
                If item.JobId = jobId Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="JobCollection"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            ' show the framework that this is a child object
            MarkAsChild()

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
        ''' Loads all <see cref="JobCollection"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DataPortal.FetchChild(Of JobItem)(dr))
            End While
            OnFetchPost(args)
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
