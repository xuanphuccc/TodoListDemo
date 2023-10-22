using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using TodoListDemo.BL;
using TodoListDemo.Controller;
using TodoListDemo.DL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Cấu hình validate input
        options.InvalidModelStateResponseFactory = (context) =>
        {
            var errors = context.ModelState.Values.SelectMany(error => error.Errors);
            var errorMsgs = string.Join(", ", errors.Select(error => error.ErrorMessage));

            return new BadRequestObjectResult(
            new BaseException()
            {
                ErrorCode = ErrorCode.BadRequest,
                UserMessage = "Thông tin nhập liệu không hợp lệ",
                DevMessage = errorMsgs,
                TraceId = context.HttpContext.TraceIdentifier,
                MoreInfo = "",
                Errors = context.ModelState
            });
        };
    })
    .AddJsonOptions(options =>
    {
        // Tắt bộ chuyển đổi PascalCase sang camelCase
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Unit Of Work
var connectionString = builder.Configuration.GetConnectionString("TodoListDemo");
builder.Services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));

// Add Service
builder.Services.AddScoped<ITaskRepository>(provider => new TaskRepository(new MySqlConnection(connectionString)));
builder.Services.AddScoped<ITaskService, TaskService>();

// Add Cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
