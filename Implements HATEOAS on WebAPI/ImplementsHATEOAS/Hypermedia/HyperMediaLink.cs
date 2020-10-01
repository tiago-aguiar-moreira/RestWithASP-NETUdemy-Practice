using System.Text;

namespace ImplementsHATEOAS.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        
        private string href;
        public string Href
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    return new StringBuilder(href).Replace("%2F", "/").ToString();
                }
            }
            set
            {
                href = value;
            }
        }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}