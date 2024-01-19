using LanguageExt;

namespace WebAppTemplateManager.Api.Extentions
{
    public static class InputExtension
    {
        public static Either<L, R> EnsureInputIsNotNull<L, R>(this R theInput, L errorMsg)
        {
            if (theInput.IsNull())
            {
                return errorMsg;
            }
            return theInput;


        }
        public static Either<Task<L>, Task<R>> EnsureInputIsNotNullAsync<L, R>(this R theInput, L errorMsg)
        {
            if (theInput.IsNull())
            {
                return Task.FromResult(errorMsg);
            }
            return Task.FromResult(theInput);


        }
        public static Either<L, R> EnsureInputIsNotEmpty<L, R>(this R theInput, L errorMsg)
        {
            if (theInput.ToString() == string.Empty)
            {
                return errorMsg;
            }
            return theInput;


        }


    }
}
