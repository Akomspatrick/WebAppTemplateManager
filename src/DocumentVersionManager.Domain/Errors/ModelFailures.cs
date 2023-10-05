using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Errors
{
    public enum ModelFailures
    {
        [Description("Model Typename already Exist in Repository")]
        DuplicateModelTypeName,
        [Description("Error Retrieving  List From  Repository")]
        ErrorRetrievingListDataFromRepository,
        [Description("Error Retrieving  Single Entity From  Repository")]
        ErrorRetrievingSingleDataFromRepository,
        [Description("Error Adding entity  into to Repository")]
        ProblemAddingEntityIntoDbContext,
        [Description("Error Deleting entity  in Repository")]
        ProblemDeletingEntityFromRepository,
        [Description("Error Updating entity  in Repository")]
        ProblemUpdatingEntityInRepository,
    }
}
