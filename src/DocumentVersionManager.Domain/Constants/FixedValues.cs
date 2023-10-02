using System;
using System.Collections.Generic;
using System.Data;
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
        public const int ModelTypeNameMaxLength = 128;

        public const int ModelTypeNameMinLength = 2;

        //Model Constants   
        public const int ModelNameMaxLength = 128;

        public const int ModelNameMinLength = 2;


        public const string DBConnectionStringName = "constr";

        public const string DEFAULT_DOCUMENT_PATH = "F:\\MASSLOAD\\DWG\\Load Cell - Standard\\";
    }
}
