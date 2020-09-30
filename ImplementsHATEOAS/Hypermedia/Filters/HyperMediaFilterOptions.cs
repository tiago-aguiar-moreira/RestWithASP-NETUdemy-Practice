using System.Collections.Generic;
using ImplementsHATEOAS.Hypermedia.Abstract;

namespace ImplementsHATEOAS.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}