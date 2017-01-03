using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// PersonInfo (read only object).<br/>
    /// This is a generated base class of <see cref="PersonInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="PersonList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class PersonInfo : ReadOnlyBase<PersonInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="PersonId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> PersonIdProperty = RegisterProperty<int>(p => p.PersonId, "Person Id");
        /// <summary>
        /// Gets the Person Id.
        /// </summary>
        /// <value>The Person Id.</value>
        public int PersonId
        {
            get { return GetProperty(PersonIdProperty); }
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
        /// Initializes a new instance of the <see cref="PersonInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public PersonInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="PersonInfo"/> object is updated by <see cref="Person"/> Saved event.
        /// </summary>
        internal static PersonInfo LoadInfo(Person person)
        {
            var info = new PersonInfo();
            info.UpdatePropertiesOnSaved(person);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="PersonInfo"/> object are updated by <see cref="Person"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(Person person)
        {
            LoadProperty(PersonIdProperty, person.PersonId);
            LoadProperty(FirstNameProperty, person.FirstName);
            LoadProperty(MiddleNameProperty, person.MiddleName);
            LoadProperty(LastNameProperty, person.LastName);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="PersonInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(PersonIdProperty, dr.GetInt32("PersonId"));
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
