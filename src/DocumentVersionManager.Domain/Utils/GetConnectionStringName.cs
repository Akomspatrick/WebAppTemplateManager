namespace DocumentVersionManager.Domain.Utils
{
    public static class GetConnectionstringName
    {

        public static string GetConnectionStrName(string constr)
        {
            try
            {
                switch (Environment.MachineName)
                {
                    case Constants.FixedValues.Server:
                        break;
                    case Constants.FixedValues.Dev:
                        constr = Constants.FixedValues.DBDevConnectionStringName;
                        break;
                    case Constants.FixedValues.Client:
                        constr = Constants.FixedValues.Client;
                        break;
                    default:
                        throw new Exception("No Connection Name Constant  Found in FixValues");
                }

                return constr;
            }
            catch (Exception ex)
            {

                throw new Exception("Error  retrieving Machine Name");
            }

        }
    }
}