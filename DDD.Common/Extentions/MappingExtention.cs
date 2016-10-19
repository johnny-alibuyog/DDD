using ExpressMapper;

namespace DDD.Common.Extentions
{
    public static class MappingExtention
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            if (source == null)
                return default(TDestination);

            return (destination != null)
                ? Mapper.Map<TSource, TDestination>(source, destination)
                : Mapper.Map<TSource, TDestination>(source);
        }
    }
}
