namespace DevOps.Abstractions.Core.Services
{
    public interface IFileParseService<TFile>
    {
        TFile Parse(string path);
    }
}
