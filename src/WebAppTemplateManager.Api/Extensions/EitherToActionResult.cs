﻿
using WebAppTemplateManager.Domain.Errors;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace WebAppTemplateManager.Api.Extensions
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
        public static Task<IActionResult> ToActionResult404<L, R>(this Task<Either<L, R>> either)
         => either.Map((x) => Match404(x));

        public static Task<IActionResult> ToActionResult404(this Task<Either<GeneralFailure, Task>> either) =>
            either.Bind(Match404);

        private static IActionResult Match404<L, R>(this Either<L, R> either) =>
            either.Match<IActionResult>(
                               Left: l => new NotFoundObjectResult(l),

                                              Right: r => new OkObjectResult(r));
        private async static Task<IActionResult> Match404(Either<GeneralFailure, Task> either) =>
            await either.MatchAsync<IActionResult>(
            RightAsync: async t => { await t; return new OkResult(); },
                                     Left: e => new NotFoundObjectResult(e));



        //ToActionResultCreated
        public static Task<IActionResult> ToActionResultCreated<L, R>(this Task<Either<L, R>> either, string endPoint, object data)
         => either.Map((x) => MatchCreated(x, endPoint, data));

        public static Task<IActionResult> ToActionResultCreated(this Task<Either<GeneralFailure, Task>> either) =>
            either.Bind(MatchCreated);

        private static IActionResult MatchCreated<L, R>(this Either<L, R> either, string endPoint, object data)
        {

            var p = either;
            var x = endPoint;
            var y = data;

            return either.Match<IActionResult>(
                                Left: l => new BadRequestObjectResult(l),
                                               Right: r =>
                                               {
                                                   var t = r.ToString();
                                                   var p = new CreatedResult($"{endPoint}/{r}", data);
                                                   return p;
                                               });
        }

        private async static Task<IActionResult> MatchCreated(Either<GeneralFailure, Task> either) =>
            await either.MatchAsync<IActionResult>(
            RightAsync: async t => { await t; return new OkResult(); },
                                     Left: e => new BadRequestObjectResult(e));






        //
    }
}
