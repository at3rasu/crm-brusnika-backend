using CrmBrusnika.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddMvcCore();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<UsersContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrmBrusnikaDb"));
}
);

builder.Services.AddDbContext<TransactionsContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrmBrusnikaDb"));
}
);

builder.Services.AddDbContext<LandsContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrmBrusnikaDb"));
}
);

builder.Services.AddDbContext<ObjectEntitiesContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrmBrusnikaDb"));
}
);

builder.Services.AddControllersWithViews();


builder.Services
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .WithOrigins(
                        "http://172.20.10.2:3000",
                        "http://82.97.243.12:3000",
                        "http://192.168.1.210:3000",
                        "http://localhost:3000",
                        "http://localhost",
                        "http://192.168.1.210")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example v1"));
// }
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();


//app.UseHttpsRedirection();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
