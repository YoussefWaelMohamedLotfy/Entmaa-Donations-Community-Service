using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.DTOs;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public TagRepository(MainContext context) : base(context)
        {

        }

        public IEnumerable<Tag> GetTags(List<TagDTO> tags)
        {
            var result = new List<Tag>();

            for (int i = 0; i < tags.Count(); i++)
            {
                var tag = MainContext.Tags.Find(tags[i].Id);
                result.Add(tag);
            }

            return result;
        }
    }
}