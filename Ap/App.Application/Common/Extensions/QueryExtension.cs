using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Domain.Entities;
using App.Utility.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Yozian.Extension;
using Yozian.Extension.Pagination;

namespace App.Application.Common.Extensions
{
    /// <summary>
    /// </summary>
    public static class QueryExtension
    {
        /// <summary>
        /// 供所有 fetch all 使用
        /// (應該被限制最大資料撈取數量)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static Task<List<TEntity>> ToLimitedListAsync<TEntity>(
            this IQueryable<TEntity> @this,
            CancellationToken cancellationToken
        )
        {
            return @this.Take(AppConstants.FindAllLimit).ToListAsync(cancellationToken);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> WhereWhenNotEmpty<T>(
            this IQueryable<T> @this,
            string value,
            Expression<Func<T, bool>> predicate
        )
        {
            return @this.WhereWhen(!string.IsNullOrEmpty(value), predicate);
        }


        /// <summary>
        /// caution: entities will not be tracked
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TQuery"></typeparam>
        /// <returns></returns>
        public static async Task<Page<TEntity>> ToPageAsync<TEntity, TQuery>(
            this IQueryable<TEntity> @this,
            TQuery query,
            bool useConstraints = true
        )
            where TQuery : IPageableQuery
        {
            query = DefinedConstraints(query, useConstraints);

            var pageable = await @this
               .ToPaginationAsync(query.Page, query.Size);

            return pageable.ToPage(AppConstants.NavigationPageSize);
        }


        /// <summary>
        /// caution: entities will not be tracked
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TQuery"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <returns></returns>
        public static async Task<Page<TOutput>> ToPageAsync<TEntity, TQuery, TOutput>(
            this IQueryable<TEntity> @this,
            TQuery query,
            Func<TEntity, TOutput> converter,
            bool useConstraints = true
        )
            where TEntity : class
            where TQuery : PageableQuery
        {
            query = DefinedConstraints(query, useConstraints);

            var pageable = await @this
               .ToPaginationAsync(query.Page, query.Size);

            return pageable.MapTo(converter).ToPage(AppConstants.NavigationPageSize);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public static async Task<T> FindOneAsync<T>(
            this IQueryable<T> @this,
            CancellationToken cancellationToken = default
        )
            where T : class
        {
            var item = await @this.FirstOrDefaultAsync(cancellationToken);

            if (null == item)
            {
                Debug.Write(@this.Expression.Print());

                throw new MyBusinessException(ResponseCodes.NotFoundError, typeof(T).Name);
            }

            return item;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public static async Task<T> FindOneAsync<T>(
            this IQueryable<T> @this,
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default
        )
            where T : class
        {
            var item = await @this.FirstOrDefaultAsync(predicate, cancellationToken);

            if (null != item)
            {
                return item;
            }

            var msg = typeof(T).Name;

            // 
            if (typeof(T).IsPrimitive)
            {
                msg = predicate.Body.Print();
            }

            throw new MyBusinessException(
                ResponseCodes.NotFoundError,
                msg
            );
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public static async Task<TOut> FindOneAsync<T, TOut>(
            this IQueryable<T> @this,
            Expression<Func<T, bool>> predicate,
            Func<T, TOut> converter,
            CancellationToken cancellationToken = default
        )
            where T : class
            where TOut : class
        {
            var item = await @this.FirstOrDefaultAsync(predicate, cancellationToken);

            if (null == item)
            {
                throw new MyBusinessException(ResponseCodes.NotFoundError, typeof(T).Name);
            }

            return converter(item);
        }

        /// <summary>
        /// 檢查是否存在，如果存在就噴 exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public static async Task ShouldNotExistsAsync<T>(
            this IQueryable<T> @this,
            Expression<Func<T, bool>> predicate,
            string hint = "",
            CancellationToken cancellationToken = default
        )
            where T : class
        {
            var exists = await @this.AnyAsync(predicate, cancellationToken);

            if (exists)
            {
                throw new MyBusinessException(ResponseCodes.AlreadyExistsError, hint);
            }
        }

        /// <summary>
        /// 若欄位有重複排序, 則以第一個 apply 者為主，後者會被捨棄
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IOrderedQueryable<T> ApplySortProperties<T>(
            this IQueryable<T> @this,
            IDynamicSortable dynamicSortable,
            params SortProperty[] applyDefaultSorts
        )
            where T : class
        {
            //
            dynamicSortable.SortProperties ??= new List<SortProperty>();

            if (null != applyDefaultSorts && applyDefaultSorts.Length > 0)
            {
                var toBeApplied = applyDefaultSorts
                   .Except(dynamicSortable.SortProperties);

                dynamicSortable.SortProperties.AddRange(toBeApplied);
            }

            var isIOrderedQueryable = @this.Expression.Type == typeof(IOrderedQueryable<T>);

            IOrderedQueryable<T> orderedQuery;

            if (isIOrderedQueryable)
            {
                orderedQuery = @this as IOrderedQueryable<T>;
            }
            else
            {
                orderedQuery = @this.OrderBy(e => 0);
            }

            if (0 == dynamicSortable.SortProperties.Count)
            {
                return orderedQuery;
            }

            var type = typeof(T);

            var availableProperties = type.GetProperties()
               .Select(x => x.Name)
               .ToList();

            var illegalSortProperties =
                dynamicSortable.SortProperties
                   .Select(x => x.PropertyName.ToPascalCase())
                   .Except(availableProperties)
                   .ToList();

            if (illegalSortProperties.Any())
            {
                throw new MyBusinessException(
                    ResponseCodes.InvalidSortProperty,
                    string.Join(",", illegalSortProperties),
                    dynamicSortable
                );
            }

            return dynamicSortable.SortProperties
               .DistinctBy(e => e.PropertyName)
               .Aggregate(
                    orderedQuery,
                    (acc, sp) =>
                    {
                        var pi = type.GetProperty(sp.PropertyName.ToPascalCase());

                        // skip non-exists property
                        if (null == pi)
                        {
                            throw new ArgumentException($"無效的排序欄位 {sp.PropertyName}");
                        }

                        if (sp.SortOrder == SortOrder.None)
                        {
                            return acc;
                        }

                        var parameter = Expression.Parameter(type, $"{type.Name}_sort");
                        var selector = Expression.PropertyOrField(parameter, pi.Name);
                        var sortMethod = sp.SortOrder == SortOrder.Asc ? "ThenBy" : "ThenByDescending";

                        var expression = Expression.Call(
                            typeof(Queryable),
                            sortMethod,
                            new[]
                            {
                                acc.ElementType,
                                selector.Type
                            },
                            acc.Expression,
                            Expression.Quote(Expression.Lambda(selector, parameter))
                        );

                        return acc.Provider.CreateQuery<T>(expression) as IOrderedQueryable<T>;
                    }
                );
        }


        /// <summary>
        /// 處理 entity 建立時間起迄查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> ApplyCreateAtRangeConstraint<T>(
            this IQueryable<T> @this,
            ICreateAtRangeQuery constraints,
            bool includeBoundaries = true
        )
            where T : EntityBase
        {
            return @this
               .WhereWhen(constraints.CreateAtStart.HasValue, e => e.DateCreate > constraints.CreateAtStart.Value)
               .WhereWhen(constraints.CreateAtEnd.HasValue, e => e.DateCreate < constraints.CreateAtEnd.Value);
        }


        /// <summary>
        /// 處理 IDateRangeLimited 啟用起迄時間查詢 (entity and view)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> ApplyDateRangeConstraint<T>(
            this IQueryable<T> @this,
            IDateRangeLimitedRequest constraints,
            bool includeBoundaries = true
        )
            where T : IDateRangeLimited
        {
            if (!constraints.StartDate.HasValue)
            {
                return @this;
            }

            if (includeBoundaries)
            {
                return @this
                   .Where(e => e.StartDate > constraints.StartDate.Value)
                   .Where(e => e.StopDate < constraints.StopDate.Value);
            }

            return @this
               .Where(e => e.StartDate >= constraints.StartDate.Value)
               .Where(e => e.StopDate <= constraints.StopDate.Value);
        }


        /// <summary>
        /// 支援 client like pattern, string property only
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IQueryable<TSource> WhereSymbolizedLike<TSource>(
            this IQueryable<TSource> @this,
            Expression<Func<TSource, string>> property,
            string value
        )
        {
            var symbol = "*";
            var type = typeof(TSource);

            // ignore condition
            if (string.IsNullOrEmpty(value))
            {
                return @this;
            }

            // use like method
            Expression<Func<string, bool>> likeExpression = s => EF.Functions.Like(default, default);
            var likeMethod = (likeExpression.Body as MethodCallExpression)?.Method;

            var parameterExpression = Expression.Parameter(type, "e");
            var memberExpression = Expression.Property(parameterExpression, property.GetMemberName());

            var pattern = value.Contains(symbol) ? value.Replace(symbol, "%") : $"%{value}%";

            var constantExpression = Expression.Constant(pattern, typeof(string));
            var bodyExpression = Expression.Call(
                likeMethod!,
                new[]
                {
                    Expression.Property(
                        null,
                        typeof(EF).GetProperty(nameof(EF.Functions))!
                    ) as Expression,
                    memberExpression,
                    constantExpression
                }
            );

            return @this
               .Where(
                    Expression.Lambda<Func<TSource, bool>>(
                        bodyExpression,
                        parameterExpression
                    )
                );
        }


        /// <summary>
        /// 供字串 單值或 array 查詢
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        public static IQueryable<TSource> WhereStrListIn<TSource, TProperty>(
            this IQueryable<TSource> @this,
            Expression<Func<TSource, TProperty>> property,
            string value
        )
        {
            if (string.IsNullOrEmpty(value))
            {
                return @this;
            }

            var type = typeof(TSource);

            var propertyType = typeof(TProperty);

            var values = value.Split(",")
               .Select(x => (TProperty) Convert.ChangeType(x, propertyType))
               .ToList();

            Expression<Func<List<TProperty>, bool>> containsExpr = s => s.Contains(default);

            var containsMethod = (containsExpr.Body as MethodCallExpression)?.Method;

            var parameterExpression = Expression.Parameter(type, "s");
            var memberExpression = Expression.Property(parameterExpression, property.GetMemberName());

            var constantExpression = Expression.Constant(values, typeof(List<TProperty>));
            var bodyExpression = Expression.Call(
                constantExpression,
                containsMethod!,
                memberExpression
            );

            return @this
               .Where(
                    Expression.Lambda<Func<TSource, bool>>(
                        bodyExpression,
                        parameterExpression
                    )
                );
        }

        /// <summary>
        /// 查詢限制筆數
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> ApplyLimitConstraint<T>(this IQueryable<T> @this, ILimitedFetch request)
        {
            var limit = Math.Abs(request.Limit ?? AppConstants.FindAllLimit);

            if (limit > AppConstants.FindAllLimit)
            {
                limit = AppConstants.FindAllLimit;
            }

            return @this.Take(limit);
        }

        /// <summary>
        /// 查詢限制筆數
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable<T> ApplySearchLimit<T>(this IQueryable<T> @this)
        {
            return @this.Take(AppConstants.MaxRecordsForFetch);
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <returns></returns>
        private static TQuery DefinedConstraints<TQuery>(TQuery query, bool useConstraints)
            where TQuery : IPageableQuery
        {
            // check page * size value
            if (query.Size == -1)
            {
                query.Size = AppConstants.FindAllLimit;
            }

            query.Page ??= 1;
            query.Size ??= 10;

            if (query.Page < 1)
            {
                query.Page = 1;
            }

            if (query.Size < 1)
            {
                query.Size = 10;
            }

            if (useConstraints
                && query.Size != AppConstants.FindAllLimit
                && query.Size > AppConstants.MaxPaginationSize)
            {
                query.Size = 10;
            }

            return query;
        }
    }
}
