using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //Como no se le indica nada mas, su default behavior es que el solito va a mapear de esta forma
                //En el origen hay un Id, en el destino tambien, se mapean esas, si hay un Name y en el origen hay un Name, se mapea
            CreateMap<Category, CategoryResource>();
        }
    }
}
