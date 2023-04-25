using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphware.Telepath.Messaging
{
    internal class MessagingConfigurationSection : ConfigurationSection
    {
        internal MessagingConfigurationSection(IConfigurationRoot root, string path) : base(root, path)
        {
        }

        internal MessagingType Type
        {
            get => ConfigurationValue(Constants.Type, value => (MessagingType)Enum.Parse(typeof(MessagingType), value));
        }

        internal string Host
        {
            get => ConfigurationValue(Constants.Host);
            set => this[Constants.Host] = value;
        }

        internal string Username
        {
            get => ConfigurationValue(Constants.Username);
            set => this[Constants.Username] = value;
        }

        internal string Password
        {
            get => ConfigurationValue(Constants.Password);
            set => this[Constants.Password] = value;
        }

        #region Private Helpers

        private T ConfigurationValue<T>(string key, Func<string, T> result)
        {
            var value = this[key];

            Debug.Assert(value != null);

            return result(value);
        }

        private string ConfigurationValue(string key) => ConfigurationValue(key, value => value);

        #endregion
    }
}
