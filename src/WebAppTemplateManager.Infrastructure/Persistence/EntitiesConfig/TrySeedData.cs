
using WebAppTemplateManager.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppTemplateManager.Infrastructure.Persistence
{
    public static class TrySeedData
    {


        public async static Task EnsureUsers(this WebApplication app)
        {

            using var scope = app.Services.CreateScope();
            //Migration Should have been Created Might not have been Ran/Runned
            {
                try
                {
                    await scope.ServiceProvider.GetRequiredService<WebAppTemplateManagerContext>().Database.MigrateAsync();
                    var ctx = scope.ServiceProvider.GetRequiredService<WebAppTemplateManagerContext>();
                    // if (await ctx.Database.EnsureCreatedAsync())
                    {

                        var testData = ctx.ModelTypeGroups.Any();
                        if (!testData)
                        {
                            var data = new List<ModelTypeGroup>
                            {
                                ModelTypeGroup.Create("LOADCELLS_GROUP", "AUTOMATIC", "FLOW TYPES FOR LOADCELL", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
                                ModelTypeGroup.Create("TESTLINKS_GROUP", "MANUAL", "FLOW TYPES FOR TESTLINKS", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
                                ModelTypeGroup.Create("SCALES/PAD", "MANUAL", "FLOW TYPES FOR SCALES/PAD", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"))
                            };
                            ctx.ModelTypeGroups.AddRange(data);
                            ctx.SaveChanges();


                        }

                        var modelTypes = ctx.ModelTypes.Any();
                        if (!modelTypes)
                        {
                            var data = new List<ModelType>
                            {
                                ModelType.Create("FIRSTMODELTYPE", "LOADCELLS_GROUP", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
                                ModelType.Create("SECONDMODELTYPE", "TESTLINKS_GROUP", Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")),
                                ModelType.Create("THIRDMODELTYPE", "SCALES/PAD", Guid.Parse("3c69923e-a68e-4348-b06c-7007f527355d"))
                            };
                            ctx.ModelTypes.AddRange(data);
                            ctx.SaveChanges();
                        }

             




                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }


    }
}
