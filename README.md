# An ASP.NET Core application using Identity with localisation and razor pages

[![Build status](https://ci.appveyor.com/api/projects/status/1ocot03h7hs38siq?svg=true)](https://ci.appveyor.com/project/alekseyaz/aspnetcoreidentitylocalizationtemplate)

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
