```c#
services
 .AddOptions<AppSettings>()
 .Bind(cfg) // optionsBuilder.Services.Configure<TOptions>(optionsBuilder.Name, config, configureBinder);
 .ValidateDataAnnotations(); // optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(new DataAnnotationValidateOptions<TOptions>(optionsBuilder.Name));

```

```
serviceCollection.Configure<AppSettings>(cfg) 

// will actualy

services.AddOptions();
services.AddSingleton<IOptionsChangeTokenSource<TOptions>>(new ConfigurationChangeTokenSource<TOptions>(name, config));
services.AddSingleton<IConfigureOptions<TOptions>>(new NamedConfigureFromConfigurationOptions<TOptions>(name, config, configureBinder));
        
```

