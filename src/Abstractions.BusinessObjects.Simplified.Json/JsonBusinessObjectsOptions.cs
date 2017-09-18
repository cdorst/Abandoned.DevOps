namespace DevOps.Abstractions.BusinessObjects.Simplified.Json
{
    /// <remarks>Schemas are created under {System}.{Domain}.{Schema}</remarks>
    public class JsonBusinessObjectsOptions
    {
        public string Domain { get; set; } = "MyProduct";
        public string System { get; set; } = "MyCompany";
    }
}
