namespace DevOps.Abstractions.Core.Services
{
    public interface IDirectoryParseMapToParentService<TFile, TParent>
        where TFile : class
        where TParent : class
    {
        TParent Parse(string path);
    }
}