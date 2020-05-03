using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MoodyTunes.Contexts;
using MoodyTunes.Repositories.MoodRepository;
using MoodyTunes.Repositories.MoodLinkRepository;
using MoodyTunes.Repositories.PlaylistRepository;
using MoodyTunes.Repositories.PlaylistMoodRepository;
using MoodyTunes.Repositories.SongPlaylistRepository;
using MoodyTunes.Repositories.SongRepository;
using MoodyTunes.Repositories.UserRepository;

namespace MoodyTunes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IMoodRepository, MoodRepository>();
            services.AddTransient<IMoodLinkRepository, MoodLinkRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            services.AddTransient<IPlaylistMoodRepository, PlaylistMoodRepository>();
            services.AddTransient<ISongPlaylistRepository, SongPlaylistRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials());
            app.UseMvc();


        }

    }
}