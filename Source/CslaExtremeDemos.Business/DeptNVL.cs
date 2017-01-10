using System;
using Csla;

namespace CslaExtremeDemos.Business
{
    public partial class DeptNVL
    {

        #region OnDeserialized actions

        /*/// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            // add your custom OnDeserialized actions here.
        }*/

        #endregion

        #region Implementation of DataPortal Hooks

        partial void OnFetchPre(DataPortalHookArgs args)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            Add(new NameValuePair(0, string.Empty));
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        //partial void OnFetchPost(DataPortalHookArgs args)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

    }
}
