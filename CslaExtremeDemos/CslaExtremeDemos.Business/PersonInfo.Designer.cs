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
        /// Maintains metadata about <see cref="Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name, "Name");
        /// <summary>
        /// Gets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Gender"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> GenderProperty = RegisterProperty<byte>(p => p.Gender, "Gender");
        /// <summary>
        /// Gets the Gender.
        /// </summary>
        /// <value>The Gender.</value>
        public byte Gender
        {
            get { return GetProperty(GenderProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="BirthDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> BirthDateProperty = RegisterProperty<SmartDate>(p => p.BirthDate, "Birth Date");
        /// <summary>
        /// Gets the Birth Date.
        /// </summary>
        /// <value>The Birth Date.</value>
        public string BirthDate
        {
            get { return GetPropertyConvert<SmartDate, string>(BirthDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="BirthCountryId"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> BirthCountryIdProperty = RegisterProperty<short>(p => p.BirthCountryId, "Birth Country Id");
        /// <summary>
        /// Gets the Birth Country Id.
        /// </summary>
        /// <value>The Birth Country Id.</value>
        public short BirthCountryId
        {
            get { return GetProperty(BirthCountryIdProperty); }
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
            LoadProperty(NameProperty, person.Name);
            LoadProperty(GenderProperty, person.Gender);
            LoadProperty(BirthDateProperty, (SmartDate)person.BirthDate);
            LoadProperty(BirthCountryIdProperty, person.BirthCountryId);
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
            LoadProperty(NameProperty, dr.GetString("Name"));
            LoadProperty(GenderProperty, dr.GetByte("Gender"));
            LoadProperty(BirthDateProperty, dr.GetSmartDate("BirthDate", true));
            LoadProperty(BirthCountryIdProperty, dr.GetInt16("BirthCountryId"));
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
