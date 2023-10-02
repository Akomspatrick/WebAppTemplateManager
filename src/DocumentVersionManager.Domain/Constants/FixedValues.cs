using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Constants
{
    /// <summary>
    /// This is to help prevent the use of magic strings in the application
    /// </summary>
    public static class FixedValues
    {
        //ModelType Constants
        public static int ModelTypeNameMaxLength = 128;

        public static int ModelTypeNameMinLength = 2;

        //Model Constants   
        public static int ModelNameMaxLength = 128;

        public static int ModelVersionMaxLength = 128;

    }
}
