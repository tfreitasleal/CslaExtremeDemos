using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// DeptCollection (dynamic root list).<br/>
    /// This is a generated base class of <see cref="DeptCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="DeptItem"/> objects.
    /// </remarks>
    [Serializable]
    public partial class DeptCollection : DynamicBindingListBase<DeptItem>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="DeptItem"/> item is in the collection.
        /// </summary>
        /// <param name="deptId">The DeptId of the item to search for.</param>
        /// <returns><c>true</c> if the DeptItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(Int16 deptId)
        {
            foreach (var deptItem in this)
            {
                if (deptItem.DeptId == deptId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DeptCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="DeptCollection"/> collection.</returns>
        public static DeptCollection NewDeptCollection()
        {
            return DataPortal.Create<DeptCollection>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DeptCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="DeptCollection"/> collection.</returns>
        public static DeptCollection GetDeptCollection()
        {
            return DataPortal.Fetch<DeptCollection>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeptCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DeptCollection()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DeptCollection"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetDeptCollection", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="DeptCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.Fetch<DeptItem>(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
