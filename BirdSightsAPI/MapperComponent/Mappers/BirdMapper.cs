using Application.Interfaces;
using Domain.Entities;
using RepositoryComponent.Models;

namespace MapperComponent.Mappers
{
    public class BirdMapper : IMapper<BirdModel, Bird>
    {
        public Bird Map(BirdModel @in)
        {
            return new Bird(@in.Id, @in.Name);
        }

        public Bird Map(BirdModel @in, Bird @out)
        {
            @out.Id = @in.Id;
            @out.Name = @in.Name;

            return @out;
        }
    }
}
