using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// Person (editable root object).<br/>
    /// This is a generated base class of <see cref="Person"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Jobs"/> of type <see cref="JobCollection"/> (1:M relation to <see cref="JobItem"/>)
    /// </remarks>
    [Serializable]
    public partial class Person : BusinessBase<Person>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="PersonId"/> property.
        /// </summary>
        [NotUndoable]
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
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Gender"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> GenderProperty = RegisterProperty<byte>(p => p.Gender, "Gender");
        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        /// <value>The Gender.</value>
        public byte Gender
        {
            get { return GetProperty(GenderProperty); }
            set { SetProperty(GenderProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="BirthDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> BirthDateProperty = RegisterProperty<SmartDate>(p => p.BirthDate, "Birth Date");
        /// <summary>
        /// Gets or sets the Birth Date.
        /// </summary>
        /// <value>The Birth Date.</value>
        public string BirthDate
        {
            get { return GetPropertyConvert<SmartDate, string>(BirthDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(BirthDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="BirthCountryId"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> BirthCountryIdProperty = RegisterProperty<short>(p => p.BirthCountryId, "Birth Country Id");
        /// <summary>
        /// Gets or sets the Birth Country Id.
        /// </summary>
        /// <value>The Birth Country Id.</value>
        public short BirthCountryId
        {
            get { return GetProperty(BirthCountryIdProperty); }
            set { SetProperty(BirthCountryIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="GraduationDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> GraduationDateProperty = RegisterProperty<SmartDate>(p => p.GraduationDate, "Graduation Date");
        /// <summary>
        /// Gets or sets the Graduation Date.
        /// </summary>
        /// <value>The Graduation Date.</value>
        public string GraduationDate
        {
            get { return GetPropertyConvert<SmartDate, string>(GraduationDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(GraduationDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="GraduationCollege"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> GraduationCollegeProperty = RegisterProperty<string>(p => p.GraduationCollege, "Graduation College");
        /// <summary>
        /// Gets or sets the Graduation College.
        /// </summary>
        /// <value>The Graduation College.</value>
        public string GraduationCollege
        {
            get { return GetProperty(GraduationCollegeProperty); }
            set { SetProperty(GraduationCollegeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="GraduationCountryId"/> property.
        /// </summary>
        public static readonly PropertyInfo<short?> GraduationCountryIdProperty = RegisterProperty<short?>(p => p.GraduationCountryId, "Graduation Country Id");
        /// <summary>
        /// Gets or sets the Graduation Country Id.
        /// </summary>
        /// <value>The Graduation Country Id.</value>
        public short? GraduationCountryId
        {
            get { return GetProperty(GraduationCountryIdProperty); }
            set { SetProperty(GraduationCountryIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="GraduationDegree"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> GraduationDegreeProperty = RegisterProperty<byte?>(p => p.GraduationDegree, "Graduation Degree");
        /// <summary>
        /// Gets or sets the Graduation Degree.
        /// </summary>
        /// <value>The Graduation Degree.</value>
        public byte? GraduationDegree
        {
            get { return GetProperty(GraduationDegreeProperty); }
            set { SetProperty(GraduationDegreeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Jobs"/> property.
        /// </summary>
        public static readonly PropertyInfo<JobCollection> JobsProperty = RegisterProperty<JobCollection>(p => p.Jobs, "Jobs", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Jobs ("parent load" child property).
        /// </summary>
        /// <value>The Jobs.</value>
        public JobCollection Jobs
        {
            get { return GetProperty(JobsProperty); }
            private set { LoadProperty(JobsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Person"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Person"/> object.</returns>
        public static Person NewPerson()
        {
            return DataPortal.Create<Person>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Person"/> object, based on given parameters.
        /// </summary>
        /// <param name="personId">The PersonId parameter of the Person to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Person"/> object.</returns>
        public static Person GetPerson(int personId)
        {
            return DataPortal.Fetch<Person>(personId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Person()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnPersonSaved;
            PersonSaved += PersonSavedHandler;
        }

        #endregion

        #region Cache Invalidation

        private void PersonSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            PersonList.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                PersonList.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Person"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(PersonIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(GraduationDateProperty, null);
            LoadProperty(GraduationCollegeProperty, null);
            LoadProperty(JobsProperty, DataPortal.CreateChild<JobCollection>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Person"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="personId">The Person Id.</param>
        protected void DataPortal_Fetch(int personId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetPerson", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", personId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, personId);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="Person"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(PersonIdProperty, dr.GetInt32("PersonId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            LoadProperty(GenderProperty, dr.GetByte("Gender"));
            LoadProperty(BirthDateProperty, dr.GetSmartDate("BirthDate", true));
            LoadProperty(BirthCountryIdProperty, dr.GetInt16("BirthCountryId"));
            LoadProperty(GraduationDateProperty, dr.IsDBNull("GraduationDate") ? null : dr.GetSmartDate("GraduationDate", true));
            LoadProperty(GraduationCollegeProperty, dr.IsDBNull("GraduationCollege") ? null : dr.GetString("GraduationCollege"));
            LoadProperty(GraduationCountryIdProperty, (short?)dr.GetValue("GraduationCountryId"));
            LoadProperty(GraduationDegreeProperty, (byte?)dr.GetValue("GraduationDegree"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            LoadProperty(JobsProperty, DataPortal.FetchChild<JobCollection>(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="Person"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddPerson", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Gender", ReadProperty(GenderProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@BirthDate", ReadProperty(BirthDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@BirthCountryId", ReadProperty(BirthCountryIdProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@GraduationDate", ReadProperty(GraduationDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@GraduationCollege", ReadProperty(GraduationCollegeProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationCollegeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@GraduationCountryId", ReadProperty(GraduationCountryIdProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationCountryIdProperty).Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@GraduationDegree", ReadProperty(GraduationDegreeProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationDegreeProperty).Value).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(PersonIdProperty, (int) cmd.Parameters["@PersonId"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Person"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdatePerson", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Gender", ReadProperty(GenderProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@BirthDate", ReadProperty(BirthDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@BirthCountryId", ReadProperty(BirthCountryIdProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@GraduationDate", ReadProperty(GraduationDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@GraduationCollege", ReadProperty(GraduationCollegeProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationCollegeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@GraduationCountryId", ReadProperty(GraduationCountryIdProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationCountryIdProperty).Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@GraduationDegree", ReadProperty(GraduationDegreeProperty) == null ? (object)DBNull.Value : ReadProperty(GraduationDegreeProperty).Value).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        #endregion

        #region Saved Event

        private void OnPersonSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (PersonSaved != null)
                PersonSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="Person"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> PersonSaved;

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
