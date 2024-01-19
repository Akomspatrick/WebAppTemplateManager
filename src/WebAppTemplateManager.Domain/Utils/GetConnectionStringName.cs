namespace WebAppTemplateManager.Domain.Utils
{
    public static class GetConnectionstringName
    {
        public static string GetConnectionStrName(string machineName) => machineName switch
        {
            Constants.FixedValues.Server => Constants.FixedValues.DBServerConnectionStringNameServer,

            Constants.FixedValues.Dev => Constants.FixedValues.DBDevConnectionStringName,

            Constants.FixedValues.Client => Constants.FixedValues.DBClientConnectionStringName,
            _ => Constants.FixedValues.DBClientConnectionStringName

        };
    }
}