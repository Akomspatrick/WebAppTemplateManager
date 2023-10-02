using LanguageExt;

namespace DocumentVersionManager.Api.Extentions
{
    public static class InputExtension
    {
        public static Either<L, R> EnsureInputIsNotNull<L, R>(this R theInput, L errorMsg)
        {
            if (theInput.IsNull() || theInput.ToString() == string.Empty)
            {
                return errorMsg;
            }
            return theInput;


        }



    }
}
