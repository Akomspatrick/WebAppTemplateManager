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
    {    //Database Connection String Name 
        public const string DBConnectionStringName = "Constr";
        //ModelType Constants
        public const int ModelTypeNameMaxLength = 128;
        public const int ModelTypeNameMinLength = 2;
        public const int ModelTypeIdMinLength = 36;
        public const int ModelTypeIdMaxLength = 68;



        //Model Constants   
        public const int ModelNameMaxLength = 128;
        public const int ModelNameMinLength = 2;
        public const int ModelIdMaxLength = 30;
        public const int ModelIdMinLength = 2;


        //DocumentType Constants



        public const string DEFAULT_DOCUMENT_PATH = "F:\\MASSLOAD\\DWG\\Load Cell - Standard\\";
        public const int DocumentTypeMaxLength = 128;

        public const int DocumentTypeMinLength = 2;
    }
}
