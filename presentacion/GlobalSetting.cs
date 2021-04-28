using System;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace presentacion
{
    public class GlobalSetting
    {
        #region Attributes
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GlobalSetting()
        {
            instance = this;
        }
        #endregion

        #region Properties
        /* VARIABLES GLOBALES */
        #endregion

        #region Server
#if DEBUG
        /// <value>Base URL del REST API.</value>
        public static string BackendUrl = $"";
        public static string AppVersion = AppInfo.VersionString + " -Developer- ";
#else
#endif
        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(BackendUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
        #endregion Server

        #region Singleton
        /// <value>Instancia de la clase.</value>
        private static GlobalSetting instance;
        /// <summary>Singleton</summary>
        /// <remarks>Restringir la creación de objetos pertenecientes a una clase o el valor de un tipo a un único objeto. Su intención consiste en garantizar que una clase solo tenga una instancia y proporcionar un punto de acceso global a ella</remarks>
        /// <returns>Singleton <see cref="presentacion.GlobalSetting" /> </returns>
        public static GlobalSetting GetInstance()
        {
            if (instance == null)
            {
                return new GlobalSetting();
            }

            return instance;
        }
        #endregion
    }
}
