using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// UserInfo (read only object).<br/>
    /// This is a generated <see cref="UserInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="UserList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class UserInfo : ReadOnlyBase<UserInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="UserId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> UserIdProperty = RegisterProperty<int>(p => p.UserId, "User Id");
        /// <summary>
        /// Gets the User Id.
        /// </summary>
        /// <value>The User Id.</value>
        public int UserId
        {
            get { return GetProperty(UserIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FirstName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(p => p.FirstName, "First Name");
        /// <summary>
        /// Gets the First Name.
        /// </summary>
        /// <value>The First Name.</value>
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="MiddleName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(p => p.MiddleName, "Middle Name", null);
        /// <summary>
        /// Gets the Middle Name.
        /// </summary>
        /// <value>The Middle Name.</value>
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LastName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(p => p.LastName, "Last Name");
        /// <summary>
        /// Gets the Last Name.
        /// </summary>
        /// <value>The Last Name.</value>
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public UserInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="UserInfo"/> object is updated by <see cref="User"/> Saved event.
        /// </summary>
        internal static UserInfo LoadInfo(User user)
        {
            var info = new UserInfo();
            info.UpdatePropertiesOnSaved(user);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="UserInfo"/> object are updated by <see cref="User"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(User user)
        {
            LoadProperty(UserIdProperty, user.UserId);
            LoadProperty(FirstNameProperty, user.FirstName);
            LoadProperty(MiddleNameProperty, user.MiddleName);
            LoadProperty(LastNameProperty, user.LastName);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="UserInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(UserIdProperty, dr.GetInt32("UserId"));
            LoadProperty(FirstNameProperty, dr.GetString("FirstName"));
            LoadProperty(MiddleNameProperty, dr.IsDBNull("MiddleName") ? null : dr.GetString("MiddleName"));
            LoadProperty(LastNameProperty, dr.GetString("LastName"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
