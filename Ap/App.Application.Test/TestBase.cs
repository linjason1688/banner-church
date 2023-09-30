using System;
using System.Collections.Generic;
using App.Application.Common.Configs;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Domain.Constants;
using App.Infrastructure.Persistence;
using AutoMapper;
using EntityFrameworkCore.Testing.Moq.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace App.Application.Test
{
    /// <summary>
    /// </summary>
    public abstract class TestBase
    {
        private static readonly MapperConfiguration mapConfig = new(
            c =>
            {
                //
                c.AddMaps(typeof(ApplicationRegister).Assembly);
            }
        );

        /// <summary>
        /// 
        /// </summary>
        public TestBase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public ILogger<T> CreateMockLogger<T>()
        {
            return Mock.Of<ILogger<T>>();
        }


        /// <summary>
        /// mapper 不可以用 mock 的，應該實際進行 mapping
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapper()
        {
            return mapConfig.CreateMapper();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>();

            // 讓 每一個 test 都 independent -> 獨立的 InMemory db
            options.UseInMemoryDatabase("InMemory" + Guid.NewGuid());

            var asMock = new Mock<IAuthService>();

            asMock.SetupGet(x => x.Identity)
               .Returns(
                    new UserIdentity
                    {
                        Version = 0,
                        Id = Guid.Empty,
                        Account = "UnitTest",
                        LastLoginIp = null,
                        Mocked = false,
                        ActualName = "UnitTest",
                        ActualNickName = "UnitTest",
                        ActualEmployeeId = null,
                        ActualDeptName = null,
                        ActualDeptId = null,
                        MockName = null,
                        MockNickName = null,
                        MockEmployeeId = null,
                        MockDeptName = null,
                        MockDeptId = null
                    }
                );

            var appDbContext = new AppDbContext(
                options.Options,
                this.CreateMockLogger<AppDbContext>(),
                Mock.Of<IDateTime>(),
                Mock.Of<IDomainEventService>(),
                asMock.Object,
                Mock.Of<IScopeContextService>()
            );

            return appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IAppDbContext CreateMockedDbContext()
        {
            return new MockedDbContextBuilder<AppDbContext>()
               .UseDbContext(this.CreateInMemoryDbContext())
               .MockedDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected Mock<IAppConfiguration> GetMockAppConfiguration()
        {
            var mock = new Mock<IAppConfiguration>();

            mock.SetupGet(m => m.AppConfig)
               .Returns(
                    new AppConfig
                    {
                        EnableStackTraceInResponse = false,
                        UploadFolderPath = null
                    }
                );

            mock.SetupGet(m => m.SqlConfig)
               .Returns(new SqlConfig());

            mock.SetupGet(m => m.DevConfig)
               .Returns(new DevConfig());

            mock.SetupGet(m => m.ScheduleJobsConfig)
               .Returns(new ScheduleJobsConfig());

            return mock;
        }
    }
}
