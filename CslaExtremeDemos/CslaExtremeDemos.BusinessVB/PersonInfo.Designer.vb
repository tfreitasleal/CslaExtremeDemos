Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data

Namespace CslaExtremeDemos.BusinessVB

    ''' <summary>
    ''' PersonInfo (read only object).<br/>
    ''' This is a generated base class of <see cref="PersonInfo"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="PersonList"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class PersonInfo
        Inherits ReadOnlyBase(Of PersonInfo)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="PersonId"/> property.
        ''' </summary>
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
        ''' Gets the Name.
        ''' </summary>
        ''' <value>The Name.</value>
        Public ReadOnly Property Name As String
            Get
                Return GetProperty(NameProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="Gender"/> property.
        ''' </summary>
        Public Shared ReadOnly GenderProperty As PropertyInfo(Of Byte) = RegisterProperty(Of Byte)(Function(p) p.Gender, "Gender")
        ''' <summary>
        ''' Gets the Gender.
        ''' </summary>
        ''' <value>The Gender.</value>
        Public ReadOnly Property Gender As Byte
            Get
                Return GetProperty(GenderProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="BirthDate"/> property.
        ''' </summary>
        Public Shared ReadOnly BirthDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.BirthDate, "Birth Date")
        ''' <summary>
        ''' Gets the Birth Date.
        ''' </summary>
        ''' <value>The Birth Date.</value>
        Public ReadOnly Property BirthDate As String
            Get
                Return GetPropertyConvert(Of SmartDate, String)(BirthDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="BirthCountryId"/> property.
        ''' </summary>
        Public Shared ReadOnly BirthCountryIdProperty As PropertyInfo(Of Short) = RegisterProperty(Of Short)(Function(p) p.BirthCountryId, "Birth Country Id")
        ''' <summary>
        ''' Gets the Birth Country Id.
        ''' </summary>
        ''' <value>The Birth Country Id.</value>
        Public ReadOnly Property BirthCountryId As Short
            Get
                Return GetProperty(BirthCountryIdProperty)
            End Get
        End Property

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="PersonInfo"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Update properties on saved object event "

        ''' <summary>
        ''' Existing <see cref="PersonInfo"/> object is updated by <see cref="Person"/> Saved event.
        ''' </summary>
        Friend Shared Function LoadInfo(person As Person) As PersonInfo
            Dim info As New PersonInfo()
            info.UpdatePropertiesOnSaved(person)
            Return info
        End Function

        ''' <summary>
        ''' Properties on <see cref="PersonInfo"/> object are updated by <see cref="Person"/> Saved event.
        ''' </summary>
        Friend Sub UpdatePropertiesOnSaved(person As Person)
            LoadProperty(PersonIdProperty, person.PersonId)
            LoadProperty(NameProperty, person.Name)
            LoadProperty(GenderProperty, person.Gender)
            LoadProperty(BirthDateProperty, CType(person.BirthDate, SmartDate))
            LoadProperty(BirthCountryIdProperty, person.BirthCountryId)
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="PersonInfo"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Child_Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(PersonIdProperty, dr.GetInt32("PersonId"))
            LoadProperty(NameProperty, dr.GetString("Name"))
            LoadProperty(GenderProperty, dr.GetByte("Gender"))
            LoadProperty(BirthDateProperty, dr.GetSmartDate("BirthDate", True))
            LoadProperty(BirthCountryIdProperty, dr.GetInt16("BirthCountryId"))
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
