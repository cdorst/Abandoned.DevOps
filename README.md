# DevOps

This repo contains libraries to aid in DevOps automation.
Though still a work-in-progress, the goal of this solution is to provide a way to bootstrap a progressive web application (running Vue JS with an ASP.NET Core server) given a business-object schema as JSON. This bootstrapper should also generate an Azure Resource Manager template and host the produced source code as a project on Visual Studio Team Services (including Build and Release definitions).

In short, this enables authoring declarative templates for building web applications. Libraries contained in this repo define the declarative-template schema and process the template to generate source code, Visual Studio Team Services, and Azure Resource Manager template assets.

## Projects

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