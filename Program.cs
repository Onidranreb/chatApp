using ChatServer.Hubs; // 1. Tells the server where to find your ChatHub.cs file

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSignalR(); // 2. ADD THIS LINE: Registers the SignalR engine

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 3. ADD THIS LINE: Creates the URL endpoint path for your phones to connect to
app.MapHub<ChatHub>("/chathub");

// 4. OPTIONAL: A quick safety endpoint so you can test if the server works in a browser
app.MapGet("/", () => "SignalR Traffic Cop Server is running perfectly!");

// Force the backend server to listen to your specific local network IP
// This forces the server to listen to your actual network IP so the phone can reach it
app.Run("http://0.0.0.0:5000");