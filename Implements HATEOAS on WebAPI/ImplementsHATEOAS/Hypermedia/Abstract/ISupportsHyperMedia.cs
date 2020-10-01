using System.Collections.Generic;

namespace ImplementsHATEOAS.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}