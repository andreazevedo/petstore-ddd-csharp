using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PetStore.Core.Helper
{
    /// <summary>
    /// Represents a paged collection
    /// </summary>
    /// <typeparam name="T">List elements' type</typeparam>
    public class PagedResult<T>
    {
        #region Fields

        private readonly ReadOnlyCollection<T> _result;
        private readonly int _total;
        private readonly int _pageSize;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a paged list.
        /// </summary>
        /// <param name="result">Data</param>
        /// <param name="total">Total number of registers</param>
        /// <param name="pageSize">The size of the page</param>
        public PagedResult(IEnumerable<T> result, int total, int pageSize)
        {
            _result = new ReadOnlyCollection<T>(new List<T>(result));
            _total = total;
            _pageSize = pageSize;
        }

        /// <summary>
        /// Creates an empty list.
        /// </summary>
        public PagedResult()
            : this(null, 0, 0)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Data collection
        /// </summary>
        public ICollection<T> Result
        {
            get { return _result; }
        }

        /// <summary>
        /// Total number of registers (not only of this specific "page").
        /// </summary>
        public int Total
        {
            get { return _total; }
        }

        /// <summary>
        /// Number of registers in this "page".
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
        }

        /// <summary>
        /// Informs whether the collection is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Result.Count == 0;
            }
        }

        #endregion
    }
}
