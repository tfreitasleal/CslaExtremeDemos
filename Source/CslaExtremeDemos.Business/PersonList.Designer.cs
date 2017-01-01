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
    /// PersonList (read only list).<br/>
    /// This is a generated base class of <see cref="PersonList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="PersonInfo"/> objects.
    /// </remarks>
    [Serializable]
    public partial class PersonList : ReadOnlyBindingListBase<PersonList, PersonInfo>
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
        /// Determines whether a <see cref="PersonInfo"/> item is in the collection.
        /// </summary>
        /// <param name="personId">The PersonId of the item to search for.</param>
        /// <returns><c>true</c> if the PersonInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int personId)
        {
            foreach (var personInfo in this)
            {
                if (personInfo.PersonId == personId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Fields

        private static PersonList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory PersonList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(PersonList list)
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
        /// Factory method. Loads a <see cref="PersonList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="PersonList"/> collection.</returns>
        public static PersonList GetPersonList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<PersonList>();

            return _list;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public PersonList()
        {
            // Use factory methods and do not use direct creation.
            PersonSaved.Register(this);

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
        /// Handle Saved events of <see cref="Person"/> to update the list of <see cref="PersonInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void PersonSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (Person)e.NewObject;
            if (((Person)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(PersonInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((Person)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.PersonId == obj.PersonId)
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
                    if (child.PersonId == obj.PersonId)
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
        /// Loads a <see cref="PersonList"/> collection from the database or from the cache.
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
                using (var cmd = new SqlCommand("dbo.GetPersonList", ctx.Connection))
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
        /// Loads all <see cref="PersonList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<PersonInfo>(dr));
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

        #region PersonSaved nested class

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="Person"/>
        /// to update the list of <see cref="PersonInfo"/> objects.
        /// </summary>
        private static class PersonSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a PersonList instance to handle Saved events.
            /// to update the list of <see cref="PersonInfo"/> objects.
            /// </summary>
            /// <param name="obj">The PersonList instance.</param>
            public static void Register(PersonList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (PersonList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    Person.PersonSaved += PersonSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="Person"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void PersonSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((PersonList) reference.Target).PersonSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered PersonList instances.
            /// </summary>
            public static void Unregister()
            {
                Person.PersonSaved -= PersonSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
