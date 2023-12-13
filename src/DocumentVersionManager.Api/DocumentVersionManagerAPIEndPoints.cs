namespace DocumentVersionManager.Api
{
    public static class DocumentVersionManagerAPIEndPoints
    {
        private const string APIBase = "api";
        public static class ModelType
        {
            private const string Controller = "ModelType";
            public const string Create = $"{APIBase}/{Controller}";

            public const string Delete = $"{APIBase}/{Controller}/{{request}}";
            //public const string Get = APIBase + "/" + Controller;
            //public const string GetAll = APIBase + "/" + Controller + "/GetAllAsync"
            public const string GetById = $"{APIBase}/{Controller}/{{NameOrGuid}}";
            // public const string GetByGuid = $"{APIBase}/{Controller}/{{ModelTypeNameOrGuid:guid}}";
            public const string GetByJSONBody = $"{APIBase}/{Controller}/PI";
            public const string Get = $"{APIBase}/{Controller}";
            public const string Update = $"{APIBase}/{Controller}";
        }
        public static class DocumentType
        {
            private const string Controller = "DocumentType";
            public const string Create = APIBase + "/" + Controller;
            public const string Get = APIBase + "/" + Controller;
            public const string GetAll = APIBase + "/" + Controller + "/GetAllAsync";
        }

        public static class Model
        {
            private const string Controller = "Model";
            public const string Create = APIBase + "/" + Controller;
            public const string Get = APIBase + "/" + Controller;
            public const string Delete = APIBase + "/" + Controller;
            public const string GetAll = APIBase + "/" + Controller + "/GetAllAsync";
            public const string Update = APIBase + "/" + Controller;
        }

    }
}
