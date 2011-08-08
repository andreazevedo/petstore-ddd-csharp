using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.Configuration
{
    /// <summary>
    /// Application settings
    /// </summary>
    public interface IConfigurationSettings
    {
        /// <summary>
        /// Application settings collection
        /// </summary>
        NameValueCollection AppSettings { get; }
    }
}
