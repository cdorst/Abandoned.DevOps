namespace DevOps.Abstractions.Core.Services
{
    public interface IMappingService<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        TOutput Map(TInput input, int parentId = 0);
    }
}
