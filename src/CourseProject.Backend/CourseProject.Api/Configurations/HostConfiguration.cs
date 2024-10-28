namespace CourseProject.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddSerializers()
            .AddMappers()
            .AddValidators()
            .AddCaching()
            .AddEventBus()
            .AddPersistence()
            .AddIdentityInfrastructure()
            .AddNotificationInfrastructure()
            .AddVerificationInfrastructure()
            .AddTemplateInfrastructure()
            .AddMediatR()
            .AddReqeuestContextTools()
            .AddCors()
            .AddDevTools()
            .AddExposers();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        // await app
        //     .MigratedataBaseSchemasAsync();

        // await app.SeedDataAsync();

        app
            .UseCors();

        app
            .UseDevTools()
            .UseExposers();

        return new(app);
    }
}
