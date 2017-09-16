using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// JobCollection (editable child list).<br/>
    /// This is a generated base class of <see cref="JobCollection"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="Person"/> editable root object.<br/>
    /// The items of the collection are <see cref="JobItem"/> objects.
    /// </remarks>
    [Serializable]
    public partial class JobCollection : BusinessBindingListBase<JobCollection, JobItem>
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="JobItem"/> item from the collection.
        /// </summary>
        /// <param name="jobId">The JobId of the item to be removed.</param>
        public void Remove(int jobId)
        {
            foreach (var jobItem in this)
            {
                if (jobItem.JobId == jobId)
                {
                    Remove(jobItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="JobItem"/> item is in the collection.
        /// </summary>
        /// <param name="jobId">The JobId of the item to search for.</param>
        /// <returns><c>true</c> if the JobItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int jobId)
        {
            foreach (var jobItem in this)
            {
                if (jobItem.JobId == jobId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="JobItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="jobId">The JobId of the item to search for.</param>
        /// <returns><c>true</c> if the JobItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int jobId)
        {
            foreach (var jobItem in DeletedList)
            {
                if (jobItem.JobId == jobId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="JobCollection"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public JobCollection()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

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
        /// Loads all <see cref="JobCollection"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<JobItem>(dr));
            }
            OnFetchPost(args);
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
