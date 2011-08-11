using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.DomainObjects;
using PetStore.Core.DomainObjects.Log;
using PetStore.Core.DomainObjects.Log.Validation;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.Logging;
using PetStore.Core.Repository.Log;

namespace PetStore.Core.Services.Log
{
    /// <summary>
    /// Error handling service
    /// </summary>
    public class ErrorService
    {
        #region Constants

        public const int ErrorsPageSize = 15;

        #endregion

        #region Fields

        private readonly IErrorRepository _errorRepository;

        #endregion

        #region Constructors

        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a paged list containing the errors that occurred.
        /// Order by date descending.
        /// </summary>
        /// <param name="type">Error type. Works just like a "LIKE '%{0}%'".</param>
        /// <param name="handled">true for handled errors, false for unhandled errors and null para all errors.</param>
        /// <param name="start">Starting at (used for paging).</param>
        /// <returns>Paged list with the errors.</returns>
        public virtual PagedResult<Error> GetErrorsPagedList(string type, bool? handled, int start)
        {
            return _errorRepository.FindByFilter(type, handled, start, ErrorsPageSize);
        }

        /// <summary>
        /// Returns a paged list containing the errors that occurred.
        /// Ordered by informed property.
        /// </summary>
        /// <param name="type">Error type. Works just like a "LIKE '%{0}%'".</param>
        /// <param name="handled">true for handled errors, false for unhandled errors and null para all errors.</param>
        /// <param name="start">Starting at (used for paging).</param>
        /// <param name="orderBy">Property that would be used for paging.</param>
        /// <param name="asc">true for ascending or false for descending.</param>
        /// <returns>Paged list with the errors.</returns>
        public virtual PagedResult<Error> GetErrorsPagedList(string type, bool? handled, int start, string orderBy = "GeneratedAt", bool asc = false)
        {
            if (String.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "GeneratedAt";
            }
            return _errorRepository.FindByFilter(type, handled, start, ErrorsPageSize, orderBy, asc);
        }

        /// <summary>
        /// Register a handled exception
        /// </summary>
        /// <param name="exception">Exception</param>
        public void RegisterException(Exception exception)
        {
            Check.Argument.IsNotNull(exception, "exception");

            RegisterException(exception, true, null);
        }

        /// <summary>
        /// Register a exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="handled">Informs whether the exception was handled.</param>
        public void RegisterException(Exception exception, bool handled)
        {
            Check.Argument.IsNotNull(exception, "exception");

            RegisterException(exception, handled, null);
        }

        /// <summary>
        /// Register a handled exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="additionalInformation">Additional information about this exception.</param>
        public void RegisterException(Exception exception, string additionalInformation)
        {
            RegisterException(exception, true, additionalInformation);
        }

        /// <summary>
        /// Register a exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="handled">Informs whether the exception was handled.</param>
        /// <param name="additionalInformation">Additional information about this exception.</param>
        public void RegisterException(Exception exception, bool handled, string additionalInformation)
        {
            if (!(exception is DomainException))
            {
                Logger.Exception(exception);
            }

            Error error = DomainObjectsFactory.Log.CreateError(exception, handled, additionalInformation);
            try
            {
                CreateError(error);
            }
            catch (ErrorValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.Exception(ex);
            }
        }

        /// <summary>
        /// Gets an error by ID
        /// </summary>
        /// <param name="id">Error ID</param>
        /// <returns>Error</returns>
        public Error GetById(int id)
        {
            return _errorRepository.FindById(id);
        }

        /// <summary>
        /// Removes an error.
        /// </summary>
        /// <param name="error">Error</param>
        public void Remove(Error error)
        {
            _errorRepository.Remove(error);
        }

        #endregion

        #region Private Methods

        private void CreateError(Error error)
        {
            IList<string> brokenRules;
            if (!((IValidatable<Error>)error).Validate(new ErrorValidator(), out brokenRules))
            {
                throw new ErrorValidationException(brokenRules);
            }

            _errorRepository.Add(error);
        }

        #endregion
    }
}
