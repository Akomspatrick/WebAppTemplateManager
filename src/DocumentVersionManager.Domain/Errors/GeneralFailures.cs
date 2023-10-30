using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Errors
{
    public enum GeneralFailures
    {
        [Description("Data  already Exist in Repository")]
        DuplicatemodelTypesName,
        [Description("Error Retrieving  List From  Repository")]
        ErrorRetrievingListDataFromRepository,
        [Description("Error Retrieving  Single Entity From  Repository/Null Result")]
        ErrorRetrievingSingleDataFromRepository,
        [Description("Error Adding entity  into to Repository")]
        ProblemAddingEntityIntoDbContext,
        [Description("Error Deleting entity  in Repository")]
        ProblemDeletingEntityFromRepository,
        [Description("Error Updating entity  in Repository")]
        ProblemUpdatingEntityInRepository,
        [Description("Data Not Found  in Repository")]
        DataNotFoundInRepository,
    }


    public static class ModelFailuresExtensions
    {

        public static string GetEnumDisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
