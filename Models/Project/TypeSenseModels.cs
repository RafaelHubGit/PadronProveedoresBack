using static PadronProveedoresAPI.Utilities.ProveedorTypeSenseMapping;

namespace PadronProveedoresAPI.Models.Project
{
    public class TypeSenseModels
    {
        
    }
    public class SearchParameters
    {
        public string? q { get; set; }
        public int per_page { get; set; }
        public int page { get; set; }
        public string? query_by { get; set; }
        public string? filter_by { get; set; }
    }

    public class SearchResponse
    {
        public List<SearchResult> Results { get; set; }
    }

    public class SearchResult
    {
        public ProveedorTypeSenseSchema Document { get; set; }
    }
}
