# Dependency Injection improvements in Asp.net Core 
A list of attributes that allows for injecting your services/managers/etc.. directly from your class instead of Startup.cs.

An article for more information is found here [Dependency Injection improvements in Asp.net Core](https://bit.ly/3kD0lIr)

## How to use
For <= .net5 projects: Inside <b>Startup.cs</b> file, put the following in the first line of the method: <b>ConfigureServices</b>:

    InjectionFactory.StartInjection(services, Configuration, Assembly.GetExecutingAssembly());

After that, follow either of the examples: </br>

## Example1:

If you have a service called "NotificationService" that implements the interface "INotificationService" instead
of writing

    services.AddTransient<INotificationService, NotificationService>();

You can write directly in the NotificationService.cs class: </br>

    [InjectAs(ServiceLifetime.Transient, typeof(INotificationService))]
    public class NotificationService {
        .
        .
        .
    }

## Example2:
If you have a configuration section "JwtSettings" in appsettings.json instead of writing:

    services.Configure<JwtAuthSettings>(Configuration.GetSection("JwtSettings"));


You can write directly in the JwtAuthSettings.cs class: </br>

    [InjectAsConfigureSection("JwtSettings")]
    public class JwtAuthSettings {
        .
        .
        .
    }
