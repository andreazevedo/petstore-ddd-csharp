using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.Configuration.Implementation
{
    public class ConfigurationSettingsImplementation : IConfigurationSettings
    {
        public NameValueCollection AppSettings
        {
            [DebuggerStepThrough]
            get { return ConfigurationManager.AppSettings; }
        }
    }
}
