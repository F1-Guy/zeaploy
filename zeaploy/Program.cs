using zeaploy.Services.Interfaces;
using zeaploy.Services.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ZeaployDbContext>(options => options.UseSqlServer(config.GetConnectionString("ZeaployConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ZeaployDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
    builder.Services.AddScoped<IApplicationService, ApplicationService>();
    builder.Services.AddScoped<ICommentService, CommentService>();
    builder.Services.AddScoped<IMessageService, MessageService>();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
