using AutoMapper;

namespace IBKS.Repositories.Base.Paging.Extensions;

public static class PageableMappingExtensions
{
    public static IPageable<TOut> MapTo<TIn, TOut>(this IPageable<TIn> input, IMapper mapper)
    {
        return input.MapTo<TOut>(mapper);
    }

    public static IPageable<TOut> MapTo<TOut>(this IPageable input, IMapper mapper)
    {
        input = input ?? throw new ArgumentNullException(nameof(input));
        mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        return new Pageable<TOut>
        {
            TotalCount = input.TotalCount,
            Count = input.Count,
            Data = input.Data?.Select(mapper.Map<TOut>).ToList(),
        };
    }

    public static IPageable<TOut> MapPageableTo<TIn, TOut>(this IMapper mapper, IPageable<TIn> input)
    {
        return input.MapTo<TIn, TOut>(mapper);
    }

    public static IPageable<TOut> MapPageableTo<TOut>(this IMapper mapper, IPageable input)
    {
        return input.MapTo<TOut>(mapper);
    }
}
