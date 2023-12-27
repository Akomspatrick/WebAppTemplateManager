using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace DocumentVersionManager.Api.Extensions
{
    public static class EitherToActionResult
    {
        public static Task<IActionResult> ToActionResult<L, R>(this Task<Either<L, R>> either)
        => either.Map(Match);
        public static Task<IActionResult> ToActionResult(this Task<Either<GeneralFailure, Task>> either) =>
            either.Bind(Match);

        private static IActionResult Match<L, R>(this Either<L, R> either) =>
            either.Match<IActionResult>(
                Left: l => new BadRequestObjectResult(l),
                Right: r => new OkObjectResult(r));

        private async static Task<IActionResult> Match(Either<GeneralFailure, Task> either) =>
            await either.MatchAsync<IActionResult>(
                RightAsync: async t => { await t; return new OkResult(); },
                Left: e => new BadRequestObjectResult(e));


//404
       public static Task<IActionResult> ToActionResult404<L, R>(this Task<Either<L, R>> either, AutoMapper.IMapper _mapper, Type sourceType, Type destinationType)
        => either.Map((x) => Match404(x, _mapper,  sourceType ,destinationType));
        //{
        //    var p = either;
        //    var result = p.Result;

        //    var x = either.Map((x)=>Match404(x, _mapper));
        //    var y = x.Result;

        //    return x;
        //}

        //private static ModelTypeResponseDTO MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(ApplicationModelTypeResponseDTO result)
        // => new ModelTypeResponseDTO(result.ModelTypeId, result.ModelTypeName, CovertToModelResponse(result.Models));
        //private static ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        // => models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName,null)).ToList();

        public static Task<IActionResult> ToActionResult404(this Task<Either<GeneralFailure, Task>> either) =>
            either.Bind(Match404);

        private static IActionResult Match404<L, R>(this Either<L, R> either, AutoMapper.IMapper _mapper, Type sourceType ,Type destinationType) =>
            either.Match<IActionResult>(
                               Left: l => new NotFoundObjectResult(l),
                                              Right: r => new OkObjectResult(_mapper.Map(r, sourceType, destinationType)));

        //private static ModelTypeResponseDTO ConvertT<R>(R? r , AutoMapper.IMapper _mapper)
        //{
        //    try
        //    {
        //        var x=  _mapper.Map<ModelTypeResponseDTO>(r);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
           
        //  return   MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(r as ApplicationModelTypeResponseDTO);
        //}

        private async static Task<IActionResult> Match404(Either<GeneralFailure, Task> either) =>
            await either.MatchAsync<IActionResult>(
            RightAsync: async t => { await t; return new OkResult(); },
                                     Left: e => new NotFoundObjectResult(e));  
    }
}
