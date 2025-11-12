using Application.Interfaces;
using Domain.Entities;
using RepositoryComponent.Models;

namespace MapperComponent.Mappers
{
    public class BirdModelMapper : IMapper<Bird, BirdModel>
    {
        public BirdModel Map(Bird @in)
        {
            return new BirdModel(@in.Id, @in.Name, DateTime.Now);
        }

        public BirdModel Map(Bird @in, BirdModel @out)
        {
            @out.Id = @in.Id;
            @out.Name = @in.Name;

            return @out;
        }
    }
}
