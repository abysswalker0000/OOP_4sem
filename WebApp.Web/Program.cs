using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using WebApp.Domain.Interfaces;
using WebApp.Domain.Services;
using WebApp.Infrastructure.DAL.Interfaces;
using WebApp.Infrastructure.DAL.Services;
using Firebase.Authentication;
using Google.Cloud.Storage.V1;
using Firebase.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Auth/AuthenticatedPage");
});

var firebaseProjectName = builder.Configuration.GetValue<string>("reviewwebapp-b7470");
var firebaseApiKey = builder.Configuration.GetValue<string>("AIzaSyCJ5Wz7tfWiDQoGC1M-4gibKkETbYolMK4");

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"../WebApp.Infrastructure/Json/reviewwebapp-b7470-firebase-adminsdk-ejznp-390d7a24cc.json");
builder.Services.AddSingleton(FirebaseApp.Create());

builder.Services.AddSingleton<IFirestoreService>(s => new FirestoreService(
    FirestoreDb.Create("reviewwebapp-b7470")
    ));


builder.Services.AddSingleton<IFirebaseStorageService>(s => new FirebaseStorageService(StorageClient.Create()));

builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
    { ApiKey = "AIzaSyCJ5Wz7tfWiDQoGC1M-4gibKkETbYolMK4",
    AuthDomain = $"reviewwebapp-b7470.firebaseapp.com",
    Providers = new FirebaseAuthProvider[]
    {
        new EmailProvider()

    }
    }));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, (o) => { });
builder.Services.AddSingleton<IFirebaseAuthService, FirebaseAuthService>();

builder.Services.AddSingleton<IFirebaseAuthService, FirebaseAuthService>();
builder.Services.AddSession();


var app = builder.Build();
app.UseRouting();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();




app.Use(async (context, next) =>
{
    var token = context.Session.GetString("token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});



app.UseStatusCodePages(async contextAccessor =>
{
    var response = contextAccessor.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        response.Redirect("/Auth/UnauthenticatedPage");
    }
});



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
