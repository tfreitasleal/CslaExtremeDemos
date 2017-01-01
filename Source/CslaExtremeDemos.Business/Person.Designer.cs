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
    [Serializable]
    public partial class Person : BusinessBase<Person>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="PersonId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> PersonIdProperty = RegisterProperty<int>(p => p.PersonId, "Person Id");
        /// <summary>
        /// Gets or sets the Person Id.
        /// </summary>
        /// <value>The Person Id.</value>
        public int PersonId
        {
            get { return GetProperty(PersonIdProperty); }
            set { SetProperty(PersonIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FirstName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(p => p.FirstName, "First Name");
        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        /// <value>The First Name.</value>
        public string FirstName
        {
            get { return GetProperty(FirstNameProperty); }
            set { SetProperty(FirstNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="MiddleName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(p => p.MiddleName, "Middle Name");
        /// <summary>
        /// Gets or sets the Middle Name.
        /// </summary>
        /// <value>The Middle Name.</value>
        public string MiddleName
        {
            get { return GetProperty(MiddleNameProperty); }
            set { SetProperty(MiddleNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LastName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(p => p.LastName, "Last Name");
        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        /// <value>The Last Name.</value>
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CivilState"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> CivilStateProperty = RegisterProperty<byte>(p => p.CivilState, "Civil State");
        /// <summary>
        /// Gets or sets the Civil State.
        /// </summary>
        /// <value>The Civil State.</value>
        public CivilStates CivilState
        {
            get { return GetPropertyConvert<byte, CivilStates>(CivilStateProperty); }
            set { SetPropertyConvert(CivilStateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Role"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> RoleProperty = RegisterProperty<byte>(p => p.Role, "Role");
        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        /// <value>The Role.</value>
        public Roles Role
        {
            get { return GetPropertyConvert<byte,Roles>(RoleProperty); }
            set { SetPropertyConvert(RoleProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DeptId"/> property.
        /// </summary>
        public static readonly PropertyInfo<short?> DeptIdProperty = RegisterProperty<short?>(p => p.DeptId, "Dept");
        /// <summary>
        /// Gets or sets the Dept Id.
        /// </summary>
        /// <value>The Dept Id.</value>
        public short? DeptId
        {
            get { return GetProperty(DeptIdProperty); }
            set { SetProperty(DeptIdProperty, value); }
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

        /// <summary>
        /// Factory method. Deletes a <see cref="Person"/> object, based on given parameters.
        /// </summary>
        /// <param name="personId">The PersonId of the Person to delete.</param>
        public static void DeletePerson(int personId)
        {
            DataPortal.Delete<Person>(personId);
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
            LoadProperty(MiddleNameProperty, null);
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
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
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
            LoadProperty(FirstNameProperty, dr.GetString("FirstName"));
            LoadProperty(MiddleNameProperty, dr.IsDBNull("MiddleName") ? null : dr.GetString("MiddleName"));
            LoadProperty(LastNameProperty, dr.GetString("LastName"));
            LoadProperty(CivilStateProperty, dr.GetByte("CivilStateId"));
            LoadProperty(RoleProperty, dr.GetByte("RoleId"));// persisted null value defaults to enum value 0
            LoadProperty(DeptIdProperty, (short?)dr.GetValue("DeptId"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="Person"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddPerson", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) == null ? (object)DBNull.Value : ReadProperty(MiddleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CivilStateId", ReadProperty(CivilStateProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty) == 0 ? (object)DBNull.Value : ReadProperty(RoleProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty) == null ? (object)DBNull.Value : ReadProperty(DeptIdProperty).Value).DbType = DbType.Int16;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Person"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdatePerson", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonId", ReadProperty(PersonIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) == null ? (object)DBNull.Value : ReadProperty(MiddleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CivilStateId", ReadProperty(CivilStateProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty) == 0 ? (object)DBNull.Value : ReadProperty(RoleProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty) == null ? (object)DBNull.Value : ReadProperty(DeptIdProperty).Value).DbType = DbType.Int16;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
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
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

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
