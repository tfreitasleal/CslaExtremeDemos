using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// User (editable root object).<br/>
    /// This is a generated base class of <see cref="User"/> business object.
    /// </summary>
    [Serializable]
    public partial class User : BusinessBase<User>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="UserId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> UserIdProperty = RegisterProperty<int>(p => p.UserId, "User Id");
        /// <summary>
        /// Gets or sets the User Id.
        /// </summary>
        /// <value>The User Id.</value>
        public int UserId
        {
            get { return GetProperty(UserIdProperty); }
            set { SetProperty(UserIdProperty, value); }
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
        public static readonly PropertyInfo<CivilStates> CivilStateProperty = RegisterProperty<CivilStates>(p => p.CivilState, "Civil State");
        /// <summary>
        /// Gets or sets the Civil State.
        /// </summary>
        /// <value>The Civil State.</value>
        public CivilStates CivilState
        {
            get { return GetProperty(CivilStateProperty); }
            set { SetProperty(CivilStateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Role"/> property.
        /// </summary>
        public static readonly PropertyInfo<Roles> RoleProperty = RegisterProperty<Roles>(p => p.Role, "Role");
        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        /// <value>The Role.</value>
        public Roles Role
        {
            get { return GetProperty(RoleProperty); }
            set { SetProperty(RoleProperty, value); }
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
        /// Factory method. Creates a new <see cref="User"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="User"/> object.</returns>
        public static User NewUser()
        {
            return DataPortal.Create<User>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="User"/> object, based on given parameters.
        /// </summary>
        /// <param name="userId">The UserId parameter of the User to fetch.</param>
        /// <returns>A reference to the fetched <see cref="User"/> object.</returns>
        public static User GetUser(int userId)
        {
            return DataPortal.Fetch<User>(userId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="User"/> object, based on given parameters.
        /// </summary>
        /// <param name="userId">The UserId of the User to delete.</param>
        public static void DeleteUser(int userId)
        {
            DataPortal.Delete<User>(userId);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public User()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnUserSaved;
            UserSaved += UserSavedHandler;
        }

        #endregion

        #region Cache Invalidation

        private void UserSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            UserList.InvalidateCache();
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
                UserList.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="User"/> object properties.
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
        /// Loads a <see cref="User"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="userId">The User Id.</param>
        protected void DataPortal_Fetch(int userId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetUser", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, userId);
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
        /// Loads a <see cref="User"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(UserIdProperty, dr.GetInt32("UserId"));
            LoadProperty(FirstNameProperty, dr.GetString("FirstName"));
            LoadProperty(MiddleNameProperty, dr.IsDBNull("MiddleName") ? null : dr.GetString("MiddleName"));
            LoadProperty(LastNameProperty, dr.GetString("LastName"));
            LoadProperty(CivilStateProperty, (CivilStates)dr.GetInt16("CivilStateId"));
            LoadProperty(RoleProperty, (Roles)dr.GetInt16("RoleId"));
            LoadProperty(DeptIdProperty, (short?)dr.GetValue("DeptId"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="User"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddUser", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) == null ? (object)DBNull.Value : ReadProperty(MiddleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CivilStateId", Convert.ToInt16(ReadProperty(CivilStateProperty))).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty) == 0 ? (object)DBNull.Value : Convert.ToInt16(ReadProperty(RoleProperty))).DbType = DbType.Int16;
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
        /// Updates in the database all changes made to the <see cref="User"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdateUser", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) == null ? (object)DBNull.Value : ReadProperty(MiddleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CivilStateId", Convert.ToInt16(ReadProperty(CivilStateProperty))).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty) == 0 ? (object)DBNull.Value : Convert.ToInt16(ReadProperty(RoleProperty))).DbType = DbType.Int16;
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

        private void OnUserSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (UserSaved != null)
                UserSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="User"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> UserSaved;

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
