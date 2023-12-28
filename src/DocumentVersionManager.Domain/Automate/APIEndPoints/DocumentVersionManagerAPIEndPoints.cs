namespace DocumentVersionManager.Api
{
    public static class DocumentVersionManagerAPIEndPoints
    {
        public const string APIBase = "api";
        public static class CapacityDocument
        {
            public const string Controller = "CapacityDocuments";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Document
        {
            public const string Controller = "Documents";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentBasePath
        {
            public const string Controller = "DocumentBasePaths";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentDocumentType
        {
            public const string Controller = "DocumentDocumentTypes";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentType
        {
            public const string Controller = "DocumentTypes";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Model
        {
            public const string Controller = "Models";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelType
        {
            public const string Controller = "ModelTypes";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelVersion
        {
            public const string Controller = "ModelVersions";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Product
        {
            public const string Controller = "Products";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ShellMaterial
        {
            public const string Controller = "ShellMaterials";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestFlowType
        {
            public const string Controller = "TestFlowTypes";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestPoint
        {
            public const string Controller = "TestPoints";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
    }
}