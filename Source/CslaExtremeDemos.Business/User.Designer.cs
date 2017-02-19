using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules.CommonRules;
using CslaExtremeDemos.Rules;
using System.ComponentModel.DataAnnotations;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// User (editable root object).<br/>
    /// This is a generated base class of <see cref="User"/> business object.
    /// </summary>
    [Serializable]
    public partial class User : BusinessBase<User>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="UserId"/> property.
        /// </summary>
        [NotUndoable]
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
        /// Gets or sets the First Name.
        /// </summary>
        /// <value>The First Name.</value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")]
        public string LastName
        {
            get { return GetProperty(LastNameProperty); }
            set { SetProperty(LastNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="MaritalStatus"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> MaritalStatusProperty = RegisterProperty<byte>(p => p.MaritalStatus, "Marital Status");
        /// <summary>
        /// Gets or sets the Marital Status.
        /// </summary>
        /// <value>The Marital Status.</value>
        public CivilStatus MaritalStatus
        {
            get { return GetPropertyConvert<byte, CivilStatus>(MaritalStatusProperty); }
            set { SetPropertyConvert<byte, CivilStatus>(MaritalStatusProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Role"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> RoleProperty = RegisterProperty<byte?>(p => p.Role, "Role");
        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        /// <value>The Role.</value>
        public Roles? Role
        {
            get { return GetPropertyConvert<byte?, Roles?>(RoleProperty); }
            set { SetPropertyConvert<byte?, Roles?>(RoleProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DeptId"/> property.
        /// </summary>
        public static readonly PropertyInfo<short?> DeptIdProperty = RegisterProperty<short?>(p => p.DeptId, "Dept");
        /// <summary>
        /// Gets or sets the Dept.
        /// </summary>
        /// <value>The Dept.</value>
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

        #region Business Rules and Property Authorization

        /// <summary>
        /// Override this method in your business class to be notified when you need to set up shared business rules.
        /// </summary>
        /// <remarks>
        /// This method is automatically called by CSLA.NET when your object should associate
        /// per-type validation rules with its properties.
        /// </remarks>
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // Property Business Rules

            // FirstName
            BusinessRules.AddRule(new MaxLength(FirstNameProperty, 50));
            // MiddleName
            BusinessRules.AddRule(new MaxLength(MiddleNameProperty, 50));
            // LastName
            BusinessRules.AddRule(new MaxLength(LastNameProperty, 50));
            // MaritalStatus
            BusinessRules.AddRule(new EnumNotZero(MaritalStatusProperty) { MessageText = "Must specify Marital Status." });

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="User"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(UserIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
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
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosConnection, false))
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
            LoadProperty(MaritalStatusProperty, dr.GetByte("MaritalStatusId"));
            LoadProperty(RoleProperty, (byte?)dr.GetValue("RoleId"));
            LoadProperty(DeptIdProperty, (short?)dr.GetValue("DeptId"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="User"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddUser", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) != null ? ReadProperty(MiddleNameProperty) : (object)DBNull.Value).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MaritalStatusId", ReadProperty(MaritalStatusProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty).HasValue ? ReadProperty(RoleProperty).Value : (object)DBNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty).HasValue ? ReadProperty(DeptIdProperty).Value : (object)DBNull.Value).DbType = DbType.Int16;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(UserIdProperty, (int) cmd.Parameters["@UserId"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="User"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdateUser", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", ReadProperty(UserIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@FirstName", ReadProperty(FirstNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MiddleName", ReadProperty(MiddleNameProperty) != null ? ReadProperty(MiddleNameProperty) : (object)DBNull.Value).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@LastName", ReadProperty(LastNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@MaritalStatusId", ReadProperty(MaritalStatusProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@RoleId", ReadProperty(RoleProperty).HasValue ? ReadProperty(RoleProperty).Value : (object)DBNull.Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty).HasValue ? ReadProperty(DeptIdProperty).Value : (object)DBNull.Value).DbType = DbType.Int16;
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
