using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// CountryCollection (editable root list).<br/>
    /// This is a generated base class of <see cref="CountryCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CountryItem"/> objects.
    /// </remarks>
    [Serializable]
    public partial class CountryCollection : BusinessBindingListBase<CountryCollection, CountryItem>
    {

        #region Collection Business Methods

        /// <summary>
        /// Adds a new <see cref="CountryItem"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        public new void Add(CountryItem item)
        {
            if (Contains(item.CountryId))
                throw new ArgumentException("CountryItem already exists.");

            base.Add(item);
        }

        /// <summary>
        /// Removes a <see cref="CountryItem"/> item from the collection.
        /// </summary>
        /// <param name="countryId">The CountryId of the item to be removed.</param>
        public void Remove(short countryId)
        {
            foreach (var countryItem in this)
            {
                if (countryItem.CountryId == countryId)
                {
                    Remove(countryItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="CountryItem"/> item is in the collection.
        /// </summary>
        /// <param name="countryId">The CountryId of the item to search for.</param>
        /// <returns><c>true</c> if the CountryItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(short countryId)
        {
            foreach (var countryItem in this)
            {
                if (countryItem.CountryId == countryId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="CountryItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="countryId">The CountryId of the item to search for.</param>
        /// <returns><c>true</c> if the CountryItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(short countryId)
        {
            foreach (var countryItem in DeletedList)
            {
                if (countryItem.CountryId == countryId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="CountryCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="CountryCollection"/> collection.</returns>
        public static CountryCollection NewCountryCollection()
        {
            return DataPortal.Create<CountryCollection>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="CountryCollection"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="CountryCollection"/> collection.</returns>
        public static CountryCollection GetCountryCollection()
        {
            return DataPortal.Fetch<CountryCollection>();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CountryCollection()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnCountryCollectionSaved;

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Cache Invalidation

        private void OnCountryCollectionSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            CountryNVL.InvalidateCache();
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
                CountryNVL.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CountryCollection"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetCountryCollection", ctx.Connection))
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
        /// Loads all <see cref="CountryCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<CountryItem>(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="CountryCollection"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.CslaExtremeDemosConnection, false))
            {
                base.Child_Update();
                ctx.Commit();
            }
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
