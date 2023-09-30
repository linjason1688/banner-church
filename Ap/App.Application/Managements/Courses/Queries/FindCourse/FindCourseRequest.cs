#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.CourseAppendixs.Dtos;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.Courses.Dtos;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Courses.Queries.FindCourse
{
    /// <summary>
    /// 取得  Course 單筆明細
    /// </summary>

    public class FindCourseRequest
        : IRequest<CourseView>
    {

        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindCourseRequestHandler
        : IRequestHandler<FindCourseRequest, CourseView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindCourseRequestHandler(
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
        public async Task<CourseView> Handle(
            FindCourseRequest request,
            CancellationToken cancellationToken
        )
        {
            var obj = await this.appDbContext
                                .Courses
                                .Where(e => e.Id == request.Id)
                                .ProjectTo<CourseView>(this.mapper.ConfigurationProvider)
                                .FindOneAsync(cancellationToken);

            var lst = await this.appDbContext.ShoppingOrderDetails.Where(c => c.CourseId == obj.Id).ToListAsync();
           
            var stu = await this.appDbContext.UserCourses.Where(c => c.CourseId == obj.Id).ToListAsync();
            var ment = await this.appDbContext.CourseManagements.Where(c => c.Id == obj.CourseManagementId).FirstOrDefaultAsync();


            var les = await this.appDbContext.CourseTimeSchedules
                                .Where(c => c.CourseId == obj.Id)
                                .ProjectTo<CourseTimeScheduleView>(this.mapper.ConfigurationProvider)
                                .ToListAsync();
            var teaLst = await this.appDbContext.CourseTimeScheduleTeachers
                       .Where(c => les.Select(c => c.Id).Contains(c.CourseTimeScheduleId))
                       .ProjectTo<CourseTimeScheduleTeacherView>(this.mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
            les.ForEach(c => c.CourseTimeScheduleTeachers =
                                teaLst.Where(d => d.CourseTimeScheduleId == c.Id).ToList());


            var prsLst = await this.appDbContext.CoursePrices
                                  .Where(c => c.CourseId == obj.Id)
                                  .ProjectTo<CoursePriceView>(this.mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);
            var cadLst = await this.appDbContext.CourseAppendixs
                      .Where(c => c.CourseId == obj.Id)
                      .ProjectTo<CourseAppendixBase>(this.mapper.ConfigurationProvider)
                      .ToListAsync(cancellationToken);


            obj.SignUpCount = lst.Count();
            obj.PaymentCount = lst.Count(c => c.OrderDetailStatus != "0");
            obj.CourseTimeSchedules = les;
            obj.CourseInformations = string.Join("<BR>", les.Select(c => $"{c.Place} {c.ClassDay} {c.ClassTimeS} {c.ClassTimeE}"));
            obj.StudentCount = stu.Count();
            obj.CourseManagementTitle = ment?.Title;
            obj.CoursePrices = prsLst;
            obj.CourseAppendices = cadLst;
            return obj;
        }
    }
}
