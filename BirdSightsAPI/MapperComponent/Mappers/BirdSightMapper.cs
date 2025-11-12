using Application.Interfaces;
using Domain.Entities;
using RepositoryComponent.Models;

namespace MapperComponent.Mappers
{
    public class BirdSightMapper : IMapper<BirdSightModel, BirdSight>
    {
        public BirdSight Map(BirdSightModel @in)
        {
            return new BirdSight(@in.Id, @in.BirdId, @in.Count, @in.Date);
        }

        public BirdSight Map(BirdSightModel @in, BirdSight @out)
        {
            @out.Id = @in.Id;
            @out.BirdId = @in.BirdId;
            @out.Count = @in.Count;
            @out.Date = @in.Date;

            return @out;
        }
    }
}
