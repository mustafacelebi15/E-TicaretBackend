using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extentions;
using System.Data;
using System.Security.Claims;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            Console.WriteLine("Roller::::" + roles);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;

            // Tüm claim'leri konsola yazdır
            Console.WriteLine("Kullanıcıya ait tüm claimler:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
            }

            // ClaimTypes.Role claim'lerini filtrele
            var roleClaims = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            if (!roleClaims.Any())
            {
                Console.WriteLine("Kullanıcıya ait hiçbir rol bulunamadı.");
                throw new Exception(Messages.AuthorizationDenied);
            }

            Console.WriteLine("Kullanıcının rolleri: " + string.Join(", ", roleClaims));

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    Console.WriteLine($"Yetkilendirme başarılı. Kullanıcı rolü: {role}");
                    return;
                }
            }

            throw new Exception(Messages.AuthorizationDenied);
        }

    }
}
