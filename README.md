# DevOps

This repo contains libraries to aid in DevOps automation.
Though still a work-in-progress, the goal of this solution is to provide a way to bootstrap a progressive web application (running Vue JS with an ASP.NET Core server) given a business-object schema as JSON. This bootstrapper should also generate an Azure Resource Manager template and host the produced source code as a project on Visual Studio Team Services (including Build and Release definitions).

This enables authoring declarative templates for building web applications. Libraries contained in this repo define the declarative-template schema and process the template to generate source code, Visual Studio Team Services, and Azure Resource Manager template assets.

## Projects

See below for projects contained in this repository. Click on project name to navigate to project README file.

### Abstractions

Projects in the *DevOps.Abstractions* namespace contain domain entity classes for DevOps concepts and associated Entity Framwork Core DbContexts and services.

Each domain within DevOps.Abstractions builds upon the last, forming an inheritance chain. The DbContext used by a code generation application is any DbContext that is based on another DevOps.Abstractions DbContext (where each DevOps.Abstractions DbContext is based on another DevOps.Abstractions DbContext recursively - terminating at DevOps.Abstractions.UniqueStrings [which depends on Abstractions.Core])

Each library is listed below in order of least dependent to most dependent. Every project on the list depends on the previous project and is a dependeny of subsequent projects.

Project | Purpose | Use
------- | ------- | ---
Abstractions.Core | Contains generic services (mostly related to interacting with Entity Framework entities) | Use generic services for data access
Abstractions.UniqueStrings | Stores and represents string values uniquely | Use these references instead of the `string`/`varchar` types in dependent models
Abstractions.Files | Model generated source code `File`s | Generate a file for each `File` 
Abstractions.Files.MarkdownDocuments | Model .md Markdown documents | Generate README.md files 
Abstractions.Agile.WorkItems | Model Agile work hierarchically (`Epic`>`Feature`>`UserStory`>`Task`) | Track DevOps automtation in an Agile process
Abstractions.Operations.Infrastructure | Model infrastructure requirements | Create (Azure Resource Manager) declarative templates
Abstractions.Operations.ContinuousIntegration | Model source code `PullRequest` and `Build` requirements | Construct VSTS Build pipelines
Abstractions.Operations.ContinuousDelivery | Model build artifact `Release` requirements | Construct VSTS Release pipelines
Abstractions.SourceCode.TypeDeclarations | Model `Class`, `Interface`, etc. declarations | 
Abstractions.SourceCode.TypeDeclarations.Namespaces | Group type declarations into `Namespace`s | Generate namespace folder-level README.md
Abstractions.SourceCode.Projects | Model `Project` files. Group `Namespace`s into `Project`s | Generate {project}.csproj and README.md
Abstractions.SourceCode.Projects.Tests.XUnit | Adds abstractions for building XUnit test libraries 
Abstractions.SourceCode.Projects.Domain | Adds domain class library project and tests 
Abstractions.SourceCode.Projects.Domain.EntityFramework | Adds EntityFramework DbContext and services 
Abstractions.SourceCode.Projects.AspNet.App.Db.EntityFramework | Adds ASP.NET project | Migrate Entity Framework context and host app
Abstractions.SourceCode.Projects.AspNet.App.Db.SqlViews | Adds normalized SQL `VIEW`s for Entity Framework entities | Use to simplify report authoring
Abstractions.SourceCode.Projects.AspNet.Api | Adds ASP.NET API projects | Web API microservices for Entity Framework data
Abstractions.SourceCode.Projects.AspNet.App.Js.Bower | Model Bower configuration | Add .bower file to web app
Abstractions.SourceCode.Projects.AspNet.App.Js.Gulp | Model Gulp configuration/tasks | Add gulp file to web app
Abstractions.SourceCode.Projects.AspNet.App.Js.TypeScript | Configure TypeScript compilation | Add TypeScript gulp tasks
Abstractions.SourceCode.Projects.AspNet.App.Js.Karma | Model Karma Js configuration | Add javascript test runner to gulp
Abstractions.SourceCode.Projects.AspNet.App.Js.Jasmine | Model Jasmine Js unit tests | Unit test javascript code
Abstractions.SourceCode.Projects.AspNet.App.Js.DataAccess | Generate generic data access API | Add a generic data-access API
Abstractions.SourceCode.Projects.AspNet.App.Js.DataAccess.DomainApi | Model javascript domain API | Adds javascript domain API objects
Abstractions.SourceCode.Projects.AspNet.App.Js.VuexStore | Model Vuex state store | Add Vuex store javascript to web app
Abstractions.SourceCode.Projects.AspNet.App.Js.VueComponents | Model Vue Js components | Add .vue components to web app
Abstractions.SourceCode.Solutions | Adds abstractions generating for Visual Studio solutions and projects 
Abstractions.SourceCode.Solutions.NuGetConfigs | 
Abstractions.SourceCode.Solutions.MarkdownFiles | 
Abstractions.BusinessObjects | Entities and DbContext for storing 'business object' schema as data. Useful for generating source code, work items, or any other DevOps assets based on this schema data. 
Abstractions.BusinessObjects.Simplified | Provides a simplified wrapper for ingesting Abstractions.BusinessObjects entities. 
Abstractions.BusinessObjects.Simplified.Json | Further simplifies ingesting BusinessObjects data. Useful for ingesting schema definition from .json files. 

#### Extending

Extend the system by adding another library to the end of the list (and basing your DbContext on the library above it), or by inserting a new library between two existing libraries (preserving order). i.e. If you are extending the system by authoring library "Foo", "Foo" should either base on "Bar" (where "Bar" was previously the most dependent library, but now "Foo" is), or "Foo" can be placed between libraries "Baz" and "Qux" (where "Qux" was based on "Baz", but now "Foo" bases on "Baz" and "Qux" bases on "Foo"). 

## Features

Assets produced by this code generator include:
* Visual Studio Solution
* .NET Standard class libraries
* Entity Framework Core database w/ migrations
* Separate ASP.NET Core API projects for each `BusinessObjects.Domain` (microservices)
* ASP.NET Core static file server for progressive web application
* Tests for all generated code
* Code documentation / Markdown README.md files

### Output