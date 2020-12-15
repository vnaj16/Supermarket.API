using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communications
{
    public class TagResponse : BaseResponse<Tag>
    {
        public TagResponse(Tag resource) : base(resource)
        {
        }

        public TagResponse(string message) : base(message)
        {
        }
    }
}
