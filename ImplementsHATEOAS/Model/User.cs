using System;
using System.Collections.Generic;
using ImplementsHATEOAS.Hypermedia;
using ImplementsHATEOAS.Hypermedia.Abstract;

namespace ImplementsHATEOAS.Model
{
    public class User : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}