using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplateManager.Infrastructure.Utils
{
    public class GeneralUtils
    {

        public static MySqlServerVersion GetMySqlVersion()
        {
            return new MySqlServerVersion(new Version(8, 0));
        }
    }
}
