using BundlerMinifier.TagHelpers;
using Company.WebApplication1.Data;
using Company.WebApplication1.Services.Mail;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.WebApplication1
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            return services;
        }

        public static IServiceCollection ConfigureDataStores(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }

        public static IdentityBuilder ConfigureIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;    // уникальный email
                config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
                config.SignIn.RequireConfirmedEmail = false;
            });

            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddDefaultTokenProviders();

            return builder;
        }

        public static AuthenticationBuilder ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            AuthenticationBuilder builder = services.AddAuthentication();

            if (configuration["Authentication:Facebook:IsEnabled"] == "true")
            {
                builder.AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                });
            }

            if (configuration["Authentication:Google:IsEnabled"] == "true")
            {
                builder.AddGoogle(googleOptions =>
                    {
                        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                    });
            }

            return builder;
        }

        public static IMvcBuilder ConfigureMvc(this IServiceCollection services, IConfiguration configuration)
        {
            IMvcBuilder builder = services.AddMvc();

            builder.AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/");

                    options.Conventions.AllowAnonymousToPage("/Error");
                    options.Conventions.AllowAnonymousToPage("/Account/AccessDenied");
                    options.Conventions.AllowAnonymousToPage("/Account/ConfirmEmail");
                    options.Conventions.AllowAnonymousToPage("/Account/ExternalLogin");
                    options.Conventions.AllowAnonymousToPage("/Account/ForgotPassword");
                    options.Conventions.AllowAnonymousToPage("/Account/ForgotPasswordConfirmation");
                    options.Conventions.AllowAnonymousToPage("/Account/Lockout");
                    options.Conventions.AllowAnonymousToPage("/Account/Login");
                    options.Conventions.AllowAnonymousToPage("/Account/LoginWith2fa");
                    options.Conventions.AllowAnonymousToPage("/Account/LoginWithRecoveryCode");
                    options.Conventions.AllowAnonymousToPage("/Account/Register");
                    options.Conventions.AllowAnonymousToPage("/Account/ResetPassword");
                    options.Conventions.AllowAnonymousToPage("/Account/ResetPasswordConfirmation");
                    options.Conventions.AllowAnonymousToPage("/Account/SignedOut");
                });

            builder.SetCompatibilityVersion(CompatibilityVersion.Latest);

            return builder;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailManagerOptions>(configuration.GetSection("Email"));

            if (configuration["Email:EmailProvider"] == "SendGrid")
            {
                services.Configure<SendGridAuthOptions>(configuration.GetSection("Email:SendGrid"));
                services.AddSingleton<IMailManager, SendGridMailManager>();
            }
            else
            {
                services.AddSingleton<IMailManager, EmptyMailManager>();
            }

            services.AddScoped<Services.Profile.ProfileManager>();

            return services;
        }

        public static IServiceCollection ConfigureBundler(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            services.AddBundles(options =>
            {
                options.UseBundles = configuration.GetValue("BundlerMinifier:UseBundles", options.UseBundles);
                options.UseMinifiedFiles = configuration.GetValue("BundlerMinifier:UseMinifiedFiles", options.UseMinifiedFiles);
                options.AppendVersion = configuration.GetValue("BundlerMinifier:AppendVersion", options.AppendVersion);
            });

            return services;
        }
    }
}
