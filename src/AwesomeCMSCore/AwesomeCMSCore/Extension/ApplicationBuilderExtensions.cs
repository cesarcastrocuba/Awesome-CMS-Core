﻿using AwesomeCMSCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeCMSCore.Extension
{
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Serve static file base on module
        /// To access module static file simply use /ModuleName/path-to-file
        /// </summary>
        /// <param name="app"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IApplicationBuilder ServeStaticModuleFile(this IApplicationBuilder app, IList<ModuleInfo> modules)
        {
            foreach (var module in modules)
            {
                var wwwrootDir = new DirectoryInfo(Path.Combine(module.Path, "wwwroot"));
                if (!wwwrootDir.Exists)
                {
                    continue;
                }

                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(wwwrootDir.FullName),
                    RequestPath = new PathString("/" + module.ShortName)
                });
            }

            return app;
        }

        public static IApplicationBuilder SetupEnv(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            return app;
        }  

        public static IApplicationBuilder UseCustomizeMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
