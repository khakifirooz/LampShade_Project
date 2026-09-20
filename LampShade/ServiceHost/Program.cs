using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);


ShopManagementBootstrapper.Configure(
    builder.Services,
    builder.Configuration.GetConnectionString("LampshadeDb")
        ?? throw new InvalidOperationException(
            "Connection string 'LampshadeDb' was not found.")
);

builder.Services.AddRazorPages();

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

app.UseAuthorization();


app.MapRazorPages();

app.MapDefaultControllerRoute();

app.Run();
