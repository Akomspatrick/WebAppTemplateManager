
using LanguageExt.ClassInstances.Pred;
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
    //public enum GeneralFailure
    //{
    //    [Description("Data  already Exist in Repository")]
    //    DuplicatemodelTypesName,
    //    [Description("Error Retrieving  List From  Repository")]
    //    ErrorRetrievingListDataFromRepository,
    //    [Description("Error Retrieving  Single Entity From  Repository/Null Result")]
    //    ErrorRetrievingSingleDataFromRepository,
    //    [Description("Error Adding entity  into to Repository")]
    //    ProblemAddingEntityIntoDbContext,
    //    [Description("Error Deleting entity  in Repository")]
    //    ProblemDeletingEntityFromRepository,
    //    [Description("Error Updating entity  in Repository")]
    //    ProblemUpdatingEntityInRepository,
    //    [Description("Data Not Found  in Repository")]
    //    DataNotFoundInRepository,
    //}

    public record GeneralFailure(string Code, string ErrorType, string ErrorDescription) : IGeneralFailure;
    public static class GeneralFailures
    {
        public static GeneralFailure DuplicatemodelTypesName(string? value) => new("A01", $"{value} :DuplicatemodelTypesName", "Data  already Exist in Repository");
        public static GeneralFailure ErrorRetrievingListDataFromRepository(string? value) => new("A02", $"{value} ErrorRetrievingListDataFromRepository", "Error Retrieving  List From  Repository");
        public static GeneralFailure ErrorRetrievingSingleDataFromRepository(string? value) => new("A03", $"{value} :ErrorRetrievingSingleDataFromRepository", "Error Retrieving  Single Entity From  Repository/Null Result");
        public static GeneralFailure ProblemAddingEntityIntoDbContext(string? value) => new("A04", $"{value} :ProblemAddingEntityIntoDbContext", "Error Adding entity  into to Repository");
        public static GeneralFailure ProblemDeletingEntityFromRepository(string? value) => new("A05", $"{value} :ProblemDeletingEntityFromRepository", "Error Deleting entity  in Repository");
        public static GeneralFailure ProblemUpdatingEntityInRepository(string? value) => new("A06", $"{value} :ProblemUpdatingEntityInRepository", "Error Updating entity  in Repository");
        public static GeneralFailure DataNotFoundInRepository(string? value) => new("A07", $"{value} : DataNotFoundInRepository", "Data Not Found  in Repository");
        public static GeneralFailure ExceptionThrown(string where, string? summary, string details) => new("A08", $": Exception Thrown:{summary}", $"{details} ");

        //    [Description("Data  already Exist in Repository")]
        //    DuplicatemodelTypesName,
        //    [Description("Error Retrieving  List From  Repository")]
        //    ErrorRetrievingListDataFromRepository,
        //    [Description("Error Retrieving  Single Entity From  Repository/Null Result")]
        //    ErrorRetrievingSingleDataFromRepository,
        //    [Description("Error Adding entity  into to Repository")]
        //    ProblemAddingEntityIntoDbContext,
        //    [Description("Error Deleting entity  in Repository")]
        //    ProblemDeletingEntityFromRepository,
        //    [Description("Error Updating entity  in Repository")]
        //    ProblemUpdatingEntityInRepository,
        //    [Description("Data Not Found  in Repository")]
        //    DataNotFoundInRepository,

    }
    //public static class GeneralFailuresFailuresExtensions
    //{

    //    public static string GetEnumDisplayName(this Enum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

    //        if (attributes != null && attributes.Length > 0)
    //            return attributes[0].Name;
    //        else
    //            return value.ToString();
    //    }
    //    public static string GetEnumDescription(this Enum value)
    //    {
    //        FieldInfo fi = value.GetType().GetField(value.ToString());

    //        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

    //        if (attributes != null && attributes.Length > 0)
    //            return attributes[0].Description;
    //        else
    //            return value.ToString();
    //    }
    //}
}
