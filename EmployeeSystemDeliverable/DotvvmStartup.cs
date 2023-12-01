using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using EmployeeSystemDeliverable.BLL.Services;
using EmployeeSystemDeliverable.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeSystemDeliverable
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("Detail", "Employee/Detail/{Id}", "Views/Employee/Detail.dothtml");
            config.RouteTable.Add("Edit","Employee/Edit/{Id}", "Views/Employee/Edit.dothtml");
            config.RouteTable.Add("Create", "Employee/Create", "Views/Employee/Create.dothtml");

            config.RouteTable.Add("DetailSkill", "Skill/DetailSkill/{Id}", "Views/Skill/DetailSkill.dothtml");
            config.RouteTable.Add("CreateSkill", "Skill/CreateSkill", "Views/Skill/CreateSkill.dothtml");
            config.RouteTable.Add("EditSkill", "Skill/EditSkill/{Id}", "Views/Skill/EditSkill.dothtml");

            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/css/bootstrap.min.css")
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/js/bootstrap.min.js"),
                Dependencies = new[] { "bootstrap-css" , "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/jquery.min.js")
            });
            config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/Resources/style.css")
            });
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
            options.Services.AddScoped<EmployeeService>();
            options.Services.AddScoped<SkillService>();
            
        }
    }
}
