using CocktailsAndFoodAPI.Data;
using CocktailsAndFoodAPI.Entities;
using CocktailsAndFoodAPI.Interfaces;
using CocktailsAndFoodAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<DataCollection>();
builder.Services.AddSingleton<Drinks>();
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		policy.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader();
	});
});

//These require a valid OpenAI API key
//------------------------------------------------
//builder.Services.AddSingleton<ChatService>();
//builder.Services.AddScoped<AISuggestionService>();
//------------------------------------------------


builder.Services.AddScoped<IDrinksService, DrinksService>();
builder.Services.AddScoped<IFoodService, FoodService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
