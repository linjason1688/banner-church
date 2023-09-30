using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Exceptions;
using App.Infrastructure.Dtos.Services;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    [SingletonService(typeof(IJwtManager<IdentityJwtPayload>))]
    public class JwtManager : IJwtManager<IdentityJwtPayload>
    {
        private const string Secret = "App.Secret@e4cf4b7b3c834c0e9f32b0d26183e2a7";

        private readonly IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        private readonly IJwtDecoder decoder;
        private readonly IJwtEncoder encoder;
        private readonly IJsonSerializer serializer = new JsonNetSerializer();
        private readonly IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();


        public JwtManager()
        {
            this.encoder = new JwtEncoder(this.algorithm, this.serializer, this.urlEncoder);

            //
            IDateTimeProvider provider = new UtcDateTimeProvider();

            var validator = new JwtValidator(this.serializer, provider);

            this.decoder = new JwtDecoder(this.serializer, validator, this.urlEncoder, this.algorithm);
        }

        public Task<string> EncodeAsync(
            IdentityJwtPayload payload,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            return Task<string>.Factory.StartNew(() => this.Encode(payload), cancellationToken);
        }

        public Task<IdentityJwtPayload> DecodeAsync(
            string token,
            bool verify = true,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            return Task<IdentityJwtPayload>.Factory.StartNew(() => this.Decode(token, verify), cancellationToken);
        }

        private string Encode(IdentityJwtPayload payload)
        {
            var token = this.encoder.Encode(payload, Secret);

            return token;
        }

        private IdentityJwtPayload Decode(string token, bool verify = true)
        {
            try
            {
                var json = this.decoder.Decode(token, Secret, verify);
                var data = this.serializer.Deserialize<IdentityJwtPayload>(json);

                return data;
            }
            catch (Exception)
            {
                // we dont care what error here
                throw new MyBusinessException(ResponseCodes.IllegalJwtToken);
            }
        }
    }
}
