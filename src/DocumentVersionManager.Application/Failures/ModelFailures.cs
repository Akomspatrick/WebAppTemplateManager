using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Failures
{

    public enum ModelFailures
    {
        [Description("Model Typename already Exist in Repository")]
        DuplicateModelTypeName,
        [Description("Model Type not found in Repository")]
        ModelTypeNotFoundInRepository,
        [Description("Error Adding entity  into Db context")]
        ProblemAddingEntityIntoDbContext,
    }
}
