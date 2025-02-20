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
        public int? num_typos { get; set; } // No permitir errores tipográficos
        public string[]? sort_by { get; set; }

        public bool? prefix { get; set; }              // Evita coincidencias parciales no deseadas
        public bool? exact_match { get; set; }           // Permite buscar dentro de palabras más largas
        public bool? split_join_tokens { get; set; }      // Permite encontrar "mafur" dentro de "holamafures"
        public double? drop_tokens_threshold { get; set; } // No eliminar palabras clave importantes
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
