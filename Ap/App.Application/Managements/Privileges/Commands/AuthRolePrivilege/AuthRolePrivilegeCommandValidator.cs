#region


#endregion

using System.Linq;
using App.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Managements.Privileges.Commands.AuthRolePrivilege
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthRolePrivilegeCommandValidator
        : AbstractValidator<AuthRolePrivilegeCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public AuthRolePrivilegeCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.RoleId)
               .NotNull();

            this.RuleFor(r => r.PrivilegeAuthItems)
               .CustomAsync(
                    async (items, context, cancellationToken) =>
                    {
                        if (items == null || !items.Any())
                        {
                            return;
                        }

                        var authFuncIds = items.Select(x => x.PrivilegeId).Distinct().ToList();

                        var existsAuthIds = await appDbContext.Privileges
                           .Where(e => authFuncIds.Contains(e.Id))
                           .Select(e => e.Id)
                           .ToListAsync(cancellationToken);

                        var illegalIds = authFuncIds.Except(existsAuthIds).ToList();

                        if (illegalIds.Any())
                        {
                            var illegalItems = items
                               .Where(x => illegalIds.Contains(x.PrivilegeId))
                               .ToList();

                            context.AddFailure(
                                $"無效的權限: {string.Join(", ", illegalItems.Select(x => $"{x.FunctionId}({x.PrivilegeId})"))}"
                            );
                        }
                    }
                );
        }
    }
}
