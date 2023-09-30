#region

using System.Linq;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Utility.Extensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.Users.Commands.AssignUserRole
{
    /// <summary>
    /// 
    /// </summary>
    public class AssignUserRoleCommandValidator
        : AbstractValidator<AssignUserRoleCommand>
    {
        public AssignUserRoleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.UserId)
               .CustomAsync(
                    async (val, context, cancellationToken) =>
                    {
                        var exists = await appDbContext.Users.AnyAsync(e => e.Id == val, cancellationToken);

                        if (!exists)
                        {
                            context.AddFailure("Not Found!");
                        }
                    }
                );

            this.RuleFor(r => r.RoleIds)
               .CustomAsync(
                    async (val, context, cancellationToken) =>
                    {
                        if (val.IsNullOrEmpty())
                        {
                            return;
                        }

                        var ids = await appDbContext.Roles
                           .Where(e => val.Contains(e.Id))
                           .Select(e => e.Id)
                           .ToListAsync(cancellationToken);

                        if (val.Count != ids.Count)
                        {
                            var invalidIds = val.Except(ids).ToList().FlattenToString(",");
                            context.AddFailure($"Invalid RoleIds: {invalidIds}");
                        }
                    }
                );
        }
    }
}
