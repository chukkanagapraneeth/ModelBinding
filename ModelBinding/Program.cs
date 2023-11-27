using ModelBinding.CusomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new PersonModelBinderProvider());
});
builder.Services.AddControllers();
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();