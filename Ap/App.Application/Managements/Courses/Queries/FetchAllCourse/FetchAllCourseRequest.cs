#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Application.Managements.CourseManagements.Dtos;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Application.Managements.Organizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Courses.Queries.FetchAllCourse
{
    /// <summary>
    /// 查詢  Course 所有資料
    /// </summary>

    public class FetchAllCourseRequest
        : IRequest<List<CourseView>>, ILimitedFetch
    {
        /// <inheritdoc />

        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllCourseHandler
        : IRequestHandler<FetchAllCourseRequest, List<CourseView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllCourseHandler(
            IMapper mapper,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseView>> Handle(
            FetchAllCourseRequest request,
            CancellationToken cancellationToken
        )
        {
            var main = await this.appDbContext
     .Courses
     .ApplyLimitConstraint(request)
     .ProjectTo<CourseView>(this.mapper.ConfigurationProvider)
     .ToListAsync(cancellationToken);

            if (main.Count > 0)
            {
                var idS = main.Select(c => c.Id);

                //CourseOrganizationView
                var orgLst = await this.appDbContext.CourseOrganizations
                                       .Where(c => idS.Contains(c.CourseId))
                                       .ProjectTo<CourseOrganizationView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);

                var orgArr = await this.appDbContext.Organizations
                                       .Where(c => orgLst.Select(d => d.OrganizationId).Distinct().Contains(c.Id))
                                       .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);
                foreach(var org in orgLst)
                {
                    org.organization = orgArr.FirstOrDefault(c => c.Id == org.OrganizationId);
                }


                //CoursePriceView
                var prsLst = await this.appDbContext.CoursePrices
                                       .Where(c => idS.Contains(c.CourseId))
                                       .ProjectTo<CoursePriceView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);


                //CourseTimeScheduleView
                var ctsLst = await this.appDbContext.CourseTimeSchedules
                                       .Where(c => idS.Contains(c.CourseId))
                                       .ProjectTo<CourseTimeScheduleView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);
                var teaLst = await this.appDbContext.CourseTimeScheduleTeachers
                                       .Where(c => ctsLst.Select(c => c.Id).Contains(c.CourseTimeScheduleId))
                                       .ProjectTo<CourseTimeScheduleTeacherView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);
                ctsLst.ForEach(c => c.CourseTimeScheduleTeachers =
                                    teaLst.Where(d => d.CourseTimeScheduleId == c.Id).ToList());
                //CourseManagementView
                var crmLst = await this.appDbContext.CourseManagements
                                       .Where(c => main.Select(c => c.CourseManagementId).Contains(c.Id))
                                       .ProjectTo<CourseManagementView>(this.mapper.ConfigurationProvider)
                                       .ToListAsync(cancellationToken);
                //CourseAppendixBase
                var cadLst = await this.appDbContext.CourseAppendixs
                                 .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                                 .ProjectTo<CourseAppendixBase>(this.mapper.ConfigurationProvider)
                                 .ToListAsync(cancellationToken);

                foreach (var obj in main)
                {
                    obj.CourseOrganizations = orgLst.Where(c => c.CourseId == obj.Id).ToList();
                    obj.CoursePrices = prsLst.Where(c => c.CourseId == obj.Id).ToList();
                    var lst = ctsLst.Where(c => c.CourseId == obj.Id).ToList();
                    obj.CourseTimeSchedules = lst;
                    obj.CourseInformations = string.Join("<BR>", lst.Select(c => $"{c.Place} {c.ClassDay} {c.ClassTimeS} {c.ClassTimeE}"));
                    obj.CourseAppendices = cadLst.Where(c => c.CourseId == obj.Id).ToList();
                }

            }

            return main;
        }
    }
}
