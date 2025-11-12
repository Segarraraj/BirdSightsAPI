using Application.Interfaces;
using Domain.Entities;
using RepositoryComponent.Models;

namespace MapperComponent.Mappers
{
    public class BirdSightModelMapper : IMapper<BirdSight, BirdSightModel>
    {
        public BirdSightModel Map(BirdSight @in)
        {
            return new BirdSightModel(@in.Id, @in.BirdId, @in.Count, @in.Date, DateTime.Now);
        }

        public BirdSightModel Map(BirdSight @in, BirdSightModel @out)
        {
            @out.Id = @in.Id;
            @out.BirdId = @in.BirdId;
            @out.Count = @in.Count;
            @out.Date = @in.Date;

            return @out;
        }
    }
}
