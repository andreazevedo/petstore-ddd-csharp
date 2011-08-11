using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.DomainObjects.Log;
using PetStore.Core.Helper;

namespace PetStore.Core.Repository.Log
{
    public interface IErrorRepository : IRepository<Error>
    {
        #region Methods

        /// <summary>
        /// Returns a paged list containing the errors that occurred.
        /// Order by date descending.
        /// </summary>
        /// <param name="type">Error type. Works just like a "LIKE '%{0}%'".</param>
        /// <param name="handled">true for handled errors, false for unhandled errors and null para all errors.</param>
        /// <param name="start">Starting at (used for paging).</param>
        /// <param name="max">Number of registers (used for paging.).</param>
        /// <returns>Paged list with the errors.</returns>
        PagedResult<Error> FindByFilter(string type, bool? handled, int start, int max);

        /// <summary>
        /// Returns a paged list containing the errors that occurred.
        /// Ordered by informed property.
        /// </summary>
        /// <param name="type">Error type. Works just like a "LIKE '%{0}%'".</param>
        /// <param name="handled">true for handled errors, false for unhandled errors and null para all errors.</param>
        /// <param name="start">Starting at (used for paging).</param>
        /// <param name="max">Number of registers (used for paging.).</param>
        /// <param name="orderBy">Property that would be used for paging.</param>
        /// <param name="asc">true for ascending or false for descending.</param>
        /// <returns>Paged list with the errors.</returns>
        PagedResult<Error> FindByFilter(string type, bool? handled, int start, int max, string orderBy = "GeneratedAt", bool asc = false);

        /// <summary>
        /// Returns the number of errors that matches the parameters informed
        /// </summary>
        /// <param name="type">Error type. Works just like a "LIKE '%{0}%'".</param>
        /// <param name="handled">true for handled errors, false for unhandled errors and null para all errors.</param>
        /// <returns>Number of errors.</returns>
        int CountByFilter(string type, bool? handled);

        #endregion
    }
}
