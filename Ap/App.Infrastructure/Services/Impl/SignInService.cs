using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.IO;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Impl
{
    [ScopedService(typeof(ISignInService))]
    public class SignInService : ISignInService
    {
        private readonly IAppDbContext appDbContext;

        public SignInService(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<SignInResult> SignInAsync(SignIn sign, CancellationToken cancellationToken)
        {
            // TODO: implement signIn process
            //在這邊加上查 Memebership User MOD_MEMBER, 然後把資訊填到 SignInResult
            var membership =
                await this.appDbContext.ModMembers
                   // .Where(m => string.IsNullOrWhiteSpace(m.Identifier.ToString()) == sign.Account)
                   .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return new SignInResult()
            {
                Account = membership.Identifier,
                Name = membership.Name
            };
        }
    }
}
