
1. Create a new project and pick up Asp.Net Core Web Application and chose WEB API and name it BlogPostApp.API
 1.1 Add Controlles PostController and TagsController in Controllers folder
 1.2 Add Services folder with folders:
     -Helpers
     -Interfaces
     -Mappers
     -Repositories
     -ViewModel with folders:
       -Post
       -Tag
 1.3 Go to folder Properies and in folder launchSettings.json change "launchUrl": to "post"
 1.4 In appsettings.json folder add conncetion string 
    "connectionstrings": {
    "defaultconnection": "server=.;database=BlogPostDB;trusted_connection=true;multipleactiveresultsets=true" }
 1.5 Folder Startup open and add next content to section "ConfigureServices(IServiceCollection services)"
    
    services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ITagRepository, TagRepositroy>();
 1.6 Go to Dependencies and in manage nuga packages add references:
     -Microsoft.EntityFrameworkCore.SqlServer
     -Microsoft.Extensions.DependencyInjection
     -Microsoft.IdentityModel.Tokens
     -Newtonsoft.Json
     -System.Collections
     -Microsoft.CrmSdk.CoreAssemblies

2. Click on a solution and add a new project and chose Class Library (.Net Core) and name it BlogPostApp.Data
 2.1 Add folder Context and Model
 2.2 Go to Dependencies and in manage, NuGet packages add reference Microsoft.EntityFrameworkCore
	
3. Go to BlogPostApp.API and on reference add BlogPostApp.Data



      
