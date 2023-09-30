#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Managements.Privileges.Dtos;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

#endregion

namespace App.Application.Managements.Privileges.Commands.AuthRolePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthRolePrivilegeCommand : IRequest<Unit>
    {
        /// <summary>
        /// 角色 id
        /// </summary>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 權限異動項目
        /// </summary>
        public IList<PrivilegeAuthItem> PrivilegeAuthItems { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuthRolePrivilegeCommandHandler
        : IRequestHandler<AuthRolePrivilegeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public AuthRolePrivilegeCommandHandler(
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
        public async Task<Unit> Handle(
            AuthRolePrivilegeCommand command,
            CancellationToken cancellationToken
        )
        {
            var rolePrivileges = await this.appDbContext
               .RolePrivilegeMappings
               .Where(e => e.RoleId == command.RoleId)
               .ToListAsync(cancellationToken);

            // 先檢查既有異動項目
            var stateChangedList = rolePrivileges.Join(
                    command.PrivilegeAuthItems,
                    rpm => rpm.PrivilegeId,
                    pas => pas.PrivilegeId,
                    (rpm, pas) => new
                    {
                        rpm,
                        pas
                    }
                )
               .ToList();

            // 更新授權狀態
            stateChangedList.ForEach(
                c =>
                {
                    //
                    c.rpm.Enable = c.pas.Enable;

                    c.rpm.ViewGranted = c.pas.ViewGranted;
                    c.rpm.ModifyGranted = c.pas.ModifyGranted;
                    c.rpm.DeleteGranted = c.pas.DeleteGranted;
                    c.rpm.UploadGranted = c.pas.UploadGranted;
                    c.rpm.DownloadGranted = c.pas.DownloadGranted;
                }
            );

            // 新增缺少之權限

            var toBeAddedRpmEntities = command.PrivilegeAuthItems
               .Where(p => !stateChangedList.Exists(s => s.rpm.PrivilegeId == p.PrivilegeId))
               .Select(
                    pas =>
                    {
                        var rpm = new RolePrivilegeMapping
                        {
                            RoleId = command.RoleId.Value,
                            PrivilegeId = pas.PrivilegeId,
                            Enable = pas.Enable,
                            ViewGranted = pas.ViewGranted,
                            ModifyGranted = pas.ModifyGranted,
                            DeleteGranted = pas.DeleteGranted,
                            UploadGranted = pas.UploadGranted,
                            DownloadGranted = pas.DownloadGranted
                        };

                        return rpm;
                    }
                )
               .ToList();

            await this.appDbContext.RolePrivilegeMappings.AddRangeAsync(toBeAddedRpmEntities, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return default;
        }
    }
}
