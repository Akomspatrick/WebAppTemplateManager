namespace DocumentVersionManager.Api
{
    public static class DocumentVersionManagerAPIEndPoints
    {
        public const string APIBase = "api";
        public static class CapacityDocument
        {
            public const string Controller = "CapacityDocument";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Document
        {
            public const string Controller = "Document";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentBasePath
        {
            public const string Controller = "DocumentBasePath";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentDocumentType
        {
            public const string Controller = "DocumentDocumentType";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentType
        {
            public const string Controller = "DocumentType";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Model
        {
            public const string Controller = "Model";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelType
        {
            public const string Controller = "ModelType";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ModelVersion
        {
            public const string Controller = "ModelVersion";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class Product
        {
            public const string Controller = "Product";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class ShellMaterial
        {
            public const string Controller = "ShellMaterial";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestFlowType
        {
            public const string Controller = "TestFlowType";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class TestPoint
        {
            public const string Controller = "TestPoint";
            public const string Create = $"{APIBase}/{Controller}";
            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/JsonBody";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
    }
}