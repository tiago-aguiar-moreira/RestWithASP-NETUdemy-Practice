using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementsHATEOAS.Hypermedia.Constants;
using ImplementsHATEOAS.Model;
using Microsoft.AspNetCore.Mvc;

namespace ImplementsHATEOAS.Hypermedia.Enricher
{
    public class UserEnricher : ContentResponseEnricher<User>
    {
        private readonly object _lock = new object();

        protected override Task EnrichModel(User content, IUrlHelper urlHelper)
        {
            var path = "api/user/v1";
            string link = GetLink(content.Id, urlHelper, path);

            if(!content.Links.Any(a => a.Href == link && a.Action == HttpActionVerb.GET))
            {
                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.GET,
                    Href = link,
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultGet
                });
            }

            if(!content.Links.Any(a => a.Href == link && a.Action == HttpActionVerb.POST))
            {    
                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.POST,
                    Href = link,
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPost
                });
            }
            
            if(!content.Links.Any(a => a.Href == link && a.Action == HttpActionVerb.PUT))
            {    
                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.PUT,
                    Href = link,
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultPut
                });
            }

            if(!content.Links.Any(a => a.Href == link && a.Action == HttpActionVerb.DELETE))
            {
                content.Links.Add(new HyperMediaLink()
                {
                    Action = HttpActionVerb.DELETE,
                    Href = link,
                    Rel = RelationType.self,
                    Type = "int"
                });
            }

            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}