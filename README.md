# DynamicConfiguration

## Project Purpose
The purpose of the project is to dynamically access the apikeys kept in appsettings.json or web.config files without deployment or recycle.

## How It's Work

**Note:** Before running the project, the sql scripts in the [link](https://github.com/afatih/DynamicConfiguration/blob/master/sqlScripts/CreateAndFillConfigurationTable.sql "Sql Scripts") must be run.

Information about API keys is kept in MSSQL db. If there is a part that is added or changed by checking this information at certain time intervals, the local cache is updated. Then, the information about the desired key is retrieved from the cache after the type control is performed.

Here's how we can apply our library to another project in Startup.cs
```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IDynamicConfigurationProvider>(factory =>
    {
        var memoryCache = factory.GetRequiredService<IMemoryCache>();
        var options = new DynamicConfigurationProviderOptions
        {
            ApplicationName = Configuration.GetSection("ConfigurationSettings:ApplicationName").Value,
            ConnectionString = Configuration.GetSection("ConfigurationSettings:ConnectionString").Value,
            RefreshTimerIntervalInMs = Convert.ToDouble
                (Configuration.GetSection("ConfigurationSettings:RefreshTimerIntervalInMs").Value)
        };
        return new SqlServerConfigurationProvider(memoryCache, options);
    });
}
```    

Example usage

```cs
var SiteName = await _dynamicConfigurationProvider.GetValue<string>("SiteName")
```  

## Used Technologies
 - .Net 5.0
  - Local in-memory cache
  - GenericRepository and UnitOfWork
  - CQRS and Mediator
  - MSSQL for DB connection
  - Dapper as ORM tool
  - ASP .NET Core MVC for Ui.
  - XUnit for unit test.
  - Layered architecture. 

## Project View

### Main Screen
![Project picture1](https://github.com/afatih/DynamicConfiguration/blob/master/screenShoots/mainScreen2.png)

### Create-Edit Screen
![Project picture2](https://github.com/afatih/DynamicConfiguration/blob/master/screenShoots/editScreen.png)
