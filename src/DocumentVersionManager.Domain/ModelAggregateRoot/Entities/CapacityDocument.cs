using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{

    public class CapacityDocument : BaseEntity
    {
        public string ModelName { get; init; }
        public int Capacity { get; init; }
        public string DocumentPath { get; init; }


        public CapacityDocument(string modelName, int capacity, string documentPath)
        {
            ModelName = modelName;
            Capacity = capacity;
            DocumentPath = documentPath;
        }

        public bool IsValid()
        {
            return Validate(ModelName, Capacity, DocumentPath) == null;
        }

        //public static List<CapacityDocument> GetAll()
        //{
        //    MySqlConnection conn = MassloadQMS.CreateMySqlConnection();
        //    MySqlCommand cmd = conn.CreateCommand();
        //    MySqlDataReader reader;

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT `model_name`, `capacity`, `documents_path` FROM `modelcapacitydocuments` ORDER BY `model_name`, `capacity`;";

        //    List<CapacityDocument> result = new List<CapacityDocument>();
        //    try
        //    {
        //        conn.Open();
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            CapacityDocument item = new CapacityDocument(
        //                reader.GetString(0),
        //                reader.GetInt32(1),
        //                reader.GetString(2));

        //            result.Add(item);
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString() + "\n" + cmd.CommandText);
        //    }

        //    return result;
        //}

        //public static List<CapacityDocument> GetByModelName(string modelName)
        //{
        //    MySqlConnection conn = MassloadQMS.CreateMySqlConnection();
        //    MySqlCommand cmd = conn.CreateCommand();
        //    MySqlDataReader reader;

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT `model_name`, `capacity`, `documents_path` FROM `modelcapacitydocuments` WHERE `model_name` = '" + modelName + "' ORDER BY `capacity`;";

        //    List<CapacityDocument> result = new List<CapacityDocument>();
        //    try
        //    {
        //        conn.Open();
        //        reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            CapacityDocument item = new CapacityDocument(
        //                reader.GetString(0),
        //                reader.GetInt32(1),
        //                reader.GetString(2));

        //            result.Add(item);
        //        }

        //        conn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString() + "\n" + cmd.CommandText);
        //    }

        //    return result;
        //}

        //public static string GetDocumentPath(string modelName, int capacity)
        //{
        //    MySqlConnection conn = MassloadQMS.CreateMySqlConnection();
        //    MySqlCommand cmd = conn.CreateCommand();

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT `documents_path` FROM `modelcapacitydocuments` WHERE `model_name` = '" + modelName + "' AND capacity = " + capacity + ";";

        //    string result = null;
        //    try
        //    {
        //        conn.Open();
        //        result = cmd.ExecuteScalar()?.ToString() ?? null;
        //        conn.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString() + "\n" + cmd.CommandText);
        //    }

        //    return result;
        //}

        public static string Validate(string modelName, int capacity, string documentPath)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                return ModelValidationErrors.Invalid_Model_Name;
            }

            if (capacity <= 0)
            {
                return ModelValidationErrors.Invalid_Capacity;
            }

            if (string.IsNullOrWhiteSpace(documentPath) || !Directory.Exists(documentPath))
            {
                return ModelValidationErrors.Invalid_Document_Path;
            }

            return null;
        }


    }
}