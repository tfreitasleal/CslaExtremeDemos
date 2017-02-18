using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules.CommonRules;
using CslaGenFork.Rules.CollectionRules;
using System.ComponentModel.DataAnnotations;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// DeptItem (dynamic root object).<br/>
    /// This is a generated base class of <see cref="DeptItem"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DeptCollection"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DeptItem : BusinessBase<DeptItem>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DeptId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<short> DeptIdProperty = RegisterProperty<short>(p => p.DeptId, "Dept Id");
        /// <summary>
        /// Gets the Dept Id.
        /// </summary>
        /// <value>The Dept Id.</value>
        public short DeptId
        {
            get { return GetProperty(DeptIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DeptName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DeptNameProperty = RegisterProperty<string>(p => p.DeptName, "Dept Name");
        /// <summary>
        /// Gets or sets the Dept Name.
        /// </summary>
        /// <value>The Dept Name.</value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Must fill.")]
        public string DeptName
        {
            get { return GetProperty(DeptNameProperty); }
            set { SetProperty(DeptNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="IsActive"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive, "Is Active");
        /// <summary>
        /// Gets or sets the Is Active.
        /// </summary>
        /// <value><c>true</c> if Is Active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return GetProperty(IsActiveProperty); }
            set { SetProperty(IsActiveProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeptItem"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DeptItem()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnDeptItemSaved;
            DeptItemSaved += DeptItemSavedHandler;
        }

        #endregion

        #region Cache Invalidation

        private void DeptItemSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            DeptNVL.InvalidateCache();
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
                DeptNVL.InvalidateCache();
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

            // DeptName
            BusinessRules.AddRule(new MaxLength(DeptNameProperty, 50));
            BusinessRules.AddRule(new NoDuplicates(DeptNameProperty, "Department names can't be repeated."));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DeptItem"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(IsActiveProperty, true);
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DeptItem"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void DataPortal_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DeptIdProperty, dr.GetInt16("DeptId"));
            LoadProperty(DeptNameProperty, dr.GetString("DeptName"));
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="DeptItem"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.AddDeptItem", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DeptName", ReadProperty(DeptNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DeptIdProperty, (short) cmd.Parameters["@DeptId"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DeptItem"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.UpdateDeptItem", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", ReadProperty(DeptIdProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@DeptName", ReadProperty(DeptNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DeptItem"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(DeptId);
        }

        /// <summary>
        /// Deletes the <see cref="DeptItem"/> object from database.
        /// </summary>
        /// <param name="deptId">The delete criteria.</param>
        protected void DataPortal_Delete(short deptId)
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.DeleteDeptItem", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptId", deptId).DbType = DbType.Int16;
                    var args = new DataPortalHookArgs(cmd, deptId);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
            }
        }

        #endregion

        #region Saved Event

        private void OnDeptItemSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (DeptItemSaved != null)
                DeptItemSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="DeptItem"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> DeptItemSaved;

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
