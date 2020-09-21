# An ASP.NET Core application using Identity with localisation and razor pages

[![Build status](https://ci.appveyor.com/api/projects/status/1ocot03h7hs38siq?svg=true)](https://ci.appveyor.com/project/alekseyaz/aspnetcoreidentitylocalizationtemplate) [![NuGet Status](http://img.shields.io/nuget/v/AspNetCoreIdentityLocalizationTemplate.svg?style=flat-square)](https://www.nuget.org/packages/AspNetCoreIdentityLocalizationTemplate/) [Change log](https://github.com/alekseyaz/aspnetcoreidentitylocalizationtemplate/blob/master/Changelog.md)

Локализация стандартного шаблона ASP.NET Core Identity с Razor Pages, добавил en-US, ru-RU, настроил переключение, минимум изменений с оригиналом, оформил в видел nuget пакета.

## Features

- ASP.NET Core 3.1
- Latest ASP.NET Core Identity with Razor Pages
- Localization en-US, ru-RU
- minimum changes to the standard template
- npm with bundleconfig used for frontend packages

## Using the template

### install

From NuGet:

```
dotnet new -i AspNetCoreIdentityLocalizationTemplate
```

Locally built nupkg:

```
dotnet new -i AspNetCoreIdentityLocalizationTemplate.1.0.0.nupkg
```

Local folder:

```
dotnet new -i <PATH>
```

Where `<PATH>` is the path to the folder containing .template.config.

### run

```
dotnet new sts -n YourCompany.Sts
```

Use the `-n` or `--name` parameter to change the name of the output created. This string is also used to substitute the namespace name in the .cs file for the project.

### Setup, Using the application for your System

- Change the EF Core code from SqlServer to your required database
- Change the ApplicationUser class as required, remove/add the properties
- Add the migrations and create the database
- Define the deployment URLs, create the certs, and use these in your application (Startup, config files)
- Add the external providers for login as required, or remove
- Remove the UI views which are not required
- Add remove the resource file localizations and also in the Startup.
- Add the client configuration to the Config.cs class (dev, test, staging, prod, or whatever)
- Add the security headers as required, CSP, IFrame, XSS, HSTS, ...

### uninstall

```
dotnet new -u AspNetCoreIdentityLocalizationTemplate
```

## Development

### build

https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template

```
nuget pack content/AspNetCoreIdentityLocalizationTemplate.nuspec
```

### dotnet Migrations

#### open the cmd in project folder:

```
dotnet restore

dotnet ef migrations add sts_init --context ApplicationDbContext --verbose

dotnet ef database update  --verbose
```

## Links

http://docs.identityserver.io/en/release/

https://github.com/IdentityServer/IdentityServer4
