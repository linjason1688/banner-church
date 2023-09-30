#region

using App.Domain.Entities;
using AutoMapper;

#endregion

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class IMapperExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="dest"></param>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        public static FluentMapper<TDestination> MapTo<TDestination>(this IMapper @this, TDestination dest)
            where TDestination : class
        {
            return new FluentMapper<TDestination>(@this, dest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreIEntityBase<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> @this
        )
            where TSource : IEntityBase
            where TDestination : EntityBase
        {
            return @this
               .ForMember(d => d.HandledId, m => m.Ignore())
               .ForMember(d => d.DateCreate, m => m.Ignore())
               .ForMember(d => d.UserCreate, m => m.Ignore())
               .ForMember(d => d.DateUpdate, m => m.Ignore())
               .ForMember(d => d.UserUpdate, m => m.Ignore())
               .ForMember(d => d.HandledId, m => m.Ignore())
               .ForMember(d => d.DateCreate, m => m.Ignore())
               .ForMember(d => d.UserCreate, m => m.Ignore())
               .ForMember(d => d.DateUpdate, m => m.Ignore())
               .ForMember(d => d.UserUpdate, m => m.Ignore())
               .ForMember(d => d.RowVersion, m => m.Ignore());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    public class FluentMapper<TDestination>
        where TDestination : class
    {
        private readonly TDestination destination;
        private readonly IMapper mapper;

        public FluentMapper(IMapper mapper, TDestination destination)
        {
            this.mapper = mapper;
            this.destination = destination;
        }

        public FluentMapper<TDestination> Include<TSource>(TSource data)
        {
            this.mapper.Map(data, this.destination);

            return this;
        }

        public TDestination GetResult()
        {
            return this.destination;
        }
    }
}
