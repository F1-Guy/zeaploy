var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    // Redirects any URL that doesn't map to anything and redirects to index
                    options.Conventions.AddPageRoute("/PageNotFound", "{*url}");
                    options.Conventions.AddPageRoute("/PageNotFound", "ERROR:404 Page Not Found");

                    options.Conventions.AddPageRoute("/Advertisements/Advertisements", "Advertisements");
                    options.Conventions.AddPageRoute("/Applications/Applications", "Applications");
                    options.Conventions.AddPageRoute("/Profile/Profile", "Profile");
                    options.Conventions.AddPageRoute("/Users/Users", "Users");

                    options.Conventions.AddPageRoute("/Account/Login", "Login");
                    options.Conventions.AddPageRoute("/Account/Register", "Register");
                    options.Conventions.AddPageRoute("/Account/Logout", "Logout");
                    options.Conventions.AddPageRoute("/Account/AccessDenied", "ERROR:403 Access Denied");

                    options.Conventions.AddPageRoute("/Privacy", "Privacy Policy");
                });


builder.Services.AddDbContext<ZeaployDbContext>(options => options.UseSqlServer(config.GetConnectionString("ZeaployConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ZeaployDbContext>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapRazorPages();

app.Run();
