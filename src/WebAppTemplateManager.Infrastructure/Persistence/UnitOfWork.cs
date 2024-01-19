using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;


namespace WebAppTemplateManager.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly WebAppTemplateManagerContext _ctx;

        private ModelTypeRepository _modelTypeRepository;

        // private GenericRepository<object> _asyncRepository;

        //private GenericRepository _asyncRepository;//<T> where T : BaseEntity;

        public UnitOfWork(WebAppTemplateManagerContext ctx)
        {
            _ctx = ctx;

        }


        public IModelTypeRepository ModelTypeRepository => _modelTypeRepository ??= new ModelTypeRepository(_ctx);


        public IModelTypeGroupRepository ModelTypeGroupRepository => throw new NotImplementedException();

        // AsyncRepository may not work as expected because it will keep generating new instance of GenericRepository for each call
        // therefore i will go back to indivial repository instance untill i figure out how to make it work
        // BUT THE REAL PROBLEM IS THAT YOU CANT CREATE AN INSTANCE OF A GENERIC CLASS I NEED TO BE SPECIFIC ABOUT THE TYPE

        // public IGenericRepository<T> AsyncRepository<T>() where T : BaseEntity => new GenericRepository<T>(_ctx);


        // public IGenericRepository<T>  AsyncRepository1<T>() where T : BaseEntity =>  _asyncRepository ??=  new GenericRepository<T>(_ctx);


        public async Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Its not been used to commit for now individual repo implemented savechanges");
            _ctx.SavingChanges += (s, e) =>
            {

                Console.WriteLine("Saving Changes.....");
                Console.WriteLine("Saving Changes.....");
            };
            try
            {
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //log this problem into dbase
                return GeneralFailures.ProblemAddingEntityIntoDbContext("ALL");
            }

        }

        public void Dispose()
        {
            _ctx?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
