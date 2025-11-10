namespace Application.Interfaces
{
    public interface IMapper<TIn, TOut>
    {
        public TOut Map(TIn @in);
    }
}
