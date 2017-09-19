# DevOps

This repo contains libraries to aid in DevOps automation.
Though still a work-in-progress, the goal of this solution is to provide a way to bootstrap a progressive web application (running Vue JS with an ASP.NET Core server) given a business-object schema as JSON. This bootstrapper should also generate an Azure Resource Manager template and host the produced source code as a project on Visual Studio Team Services (including Build and Release definitions).

In short, this enables authoring declarative templates for building web applications. Libraries contained in this repo define the declarative-template schema and process the template to generate source code, Visual Studio Team Services, and Azure Resource Manager template assets.

## Projects

See below for projects contained in this repository. Click on project name to navigate to project README file.

Project | Purpose | Depends on
--------|--------
Abstractions.Core | Contains generic services (mostly related to interacting with EntityFramework DbContext entities).  | 
Abstractions.UniqueStrings | Provides a simple DbContext for storing string values uniquely. Useful for composing a normalized, relational database DbContext. | Abstractions.Core
Abstractions.BusinessObjects | Entities and DbContext for storing 'business object' schema as data. Useful for generating source code, work items, or any other DevOps assets based on this schema data. | Abstractions.UniqueStrings
Abstractions.BusinessObjects.Simplified | Provides a simplified wrapper for ingesting Abstractions.BusinessObjects entities. | Abstractions.BusinessObjects
Abstractions.BusinessObjects.Simplified.Json | Further simplifies ingesting BusinessObjects data. Useful for ingesting schema definition from .json files. | Abstractions.BusinessObjects.Simplified
Abstractions.SourceCode | Contains source code file abstractions. | Abstractions.BusinessObjects
Abstractions.SourceCode.Solutions | Adds abstractions generating for Visual Studio solutions and projects. | Abstractions.SourceCode
Abstractions.SourceCode.TypeDeclarations | Adds abstractions for generating C# .cs type declarations. | Abstractions.SourceCode.Solutions
Abstractions.SourceCode.VueJs | Adds abstractions for generating Vue JS .vue component declarations | Abstractions.SourceCode.TypeDeclarations
Abstractions.Platforms.AspNetCore | Contains abstractions for generating ASP.NET Core server applications. | Abstractions.Core

## Output

Given that this is a work-in-progress, the outputs listed below may not reflect the current working state of the DevOps automation tooling, but rather provide a goal of what this tooling should be able to create:
- Project / Team on Visual Studio Team Services (VSTS)
- Git Repository on VSTS
- VSTS Build definition
- VSTS Release definition
- ASP.NET Core server application
- API endpoints for resources (within server application)
- EntityFramework Core database context w/ migrations (within server application)
- Client-side Vue component app (w/ Webpack served from server app)
- Automated test code (invoked from VSTS Build & Release)
- C# client SDK for interacting with API resources
- NuGet package(s) for client SDK

### Future outputs

Once the DevOps tooling is capable of producing the above outputs, the ability to produce the following outputs should be integrated into the tooling:
- Universal Windows Platform app
- Xamarin.Forms app
- TV / Watch apps

Each of the above is an alterative front-end experience to the Vue JS progressive web application. With .NET Standard, these platforms can share a data access layer that consumes the client SDK which interacts with the ASP.NET Core web API resources.

Additionally, it may be desirable to generate GraphQL server & client code, Power BI reports & dashboards, etc.