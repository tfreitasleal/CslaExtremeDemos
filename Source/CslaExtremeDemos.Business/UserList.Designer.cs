using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;

namespace CslaExtremeDemos.Business
{

    /// <summary>
    /// UserList (read only list).<br/>
    /// This is a generated base class of <see cref="UserList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="UserInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class UserList : ReadOnlyBindingListBase<UserList, UserInfo>
    {

        #region Event handler properties

        [NotUndoable]
        private static bool _singleInstanceSavedHandler = true;

        /// <summary>
        /// Gets or sets a value indicating whether only a single instance should handle the Saved event.
        /// </summary>
        /// <value>
        /// <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        /// </value>
        public static bool SingleInstanceSavedHandler
        {
            get { return _singleInstanceSavedHandler; }
            set { _singleInstanceSavedHandler = value; }
        }

        #endregion

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="UserInfo"/> item is in the collection.
        /// </summary>
        /// <param name="userId">The UserId of the item to search for.</param>
        /// <returns><c>true</c> if the UserInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int userId)
        {
            foreach (var userInfo in this)
            {
                if (userInfo.UserId == userId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Fields

        private static UserList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory UserList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(UserList list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="UserList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="UserList"/> collection.</returns>
        public static UserList GetUserList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<UserList>();

            return _list;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public UserList()
        {
            // Use factory methods and do not use direct creation.
            UserSaved.Register(this);

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Saved Event Handler

        /// <summary>
        /// Handle Saved events of <see cref="User"/> to update the list of <see cref="UserInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void UserSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (User)e.NewObject;
            if (((User)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(UserInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((User)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.UserId == obj.UserId)
                    {
                        IsReadOnly = false;
                        var rlce = RaiseListChangedEvents;
                        RaiseListChangedEvents = true;
                        this.RemoveItem(index);
                        RaiseListChangedEvents = rlce;
                        IsReadOnly = true;
                        break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.UserId == obj.UserId)
                    {
                        child.UpdatePropertiesOnSaved(obj);
                        var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index);
                        OnListChanged(listChangedEventArgs);
                        break;
                    }
                }
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="UserList"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.CslaExtremeDemosDatabaseConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetUserList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="UserList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<UserInfo>(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
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

        #region UserSaved nested class

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="User"/>
        /// to update the list of <see cref="UserInfo"/> objects.
        /// </summary>
        private static class UserSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a UserList instance to handle Saved events.
            /// to update the list of <see cref="UserInfo"/> objects.
            /// </summary>
            /// <param name="obj">The UserList instance.</param>
            public static void Register(UserList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (UserList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    User.UserSaved += UserSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="User"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void UserSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((UserList) reference.Target).UserSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered UserList instances.
            /// </summary>
            public static void Unregister()
            {
                User.UserSaved -= UserSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
