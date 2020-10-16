using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CollegePicker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Template to set up server
            // services.AddTransient<IUserProfileRepository, UserProfileRepository>();


            //IF we use firebase, this is an example of frontside 
            //var firebaseProjectId = Configuration.GetValue<string>("FirebaseProjectId");
            //var googleTokenUrl = $"https://securetoken.google.com/{firebaseProjectId}";
            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = googleTokenUrl;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //            ValidateIssuer = true,
            //            ValidIssuer = googleTokenUrl,
            //            ValidateAudience = true,
            //            ValidAudience = firebaseProjectId,
            //            ValidateLifetime = true
            //            };
            //    });



            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
