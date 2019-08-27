using AutoMapper;
using Todo.Api.Domian.Models;
using Todo.Api.Resources;

namespace Todo.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTodoResource, TodoItem>();
        }
    }
}
