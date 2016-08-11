namespace AW.Common.Helpers
{
    using System.Configuration;
    public class ConfigurationHelper
    {
        public static string AdminUserName => ConfigurationManager.AppSettings["AdminUserName"];

        public static string AdminPassword => ConfigurationManager.AppSettings["AdminPassword"];
    }
}
