Imports System
Imports Csla


Partial Public Class User

#Region " OnDeserialized actions "

    ''' <summary>
    ''' This method is called on a newly deserialized object
    ''' after deserialization is complete.
    ''' </summary>
    ''' <param name="context">Serialization context object.</param>
    Protected Overrides Sub OnDeserialized(context As System.Runtime.Serialization.StreamingContext)
        MyBase.OnDeserialized(context)
        AddHandler Saved, AddressOf OnUserSaved
        AddHandler UserSaved, AddressOf UserSavedHandler
        ' add your custom OnDeserialized actions here.
    End Sub

#End Region

#Region " Custom Business Rules and Property Authorization "

    'partial void AddBusinessRulesExtend()
    '{
    '    throw new NotImplementedException();
    '}

#End Region

#Region " Implementation of DataPortal Hooks "

    'partial void OnCreate(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnFetchPre(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnFetchPost(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnFetchRead(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnUpdatePre(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnUpdatePost(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnInsertPre(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

    'partial void OnInsertPost(DataPortalHookArgs args)
    '{
    '    throw new NotImplementedException();
    '}

#End Region
End Class


