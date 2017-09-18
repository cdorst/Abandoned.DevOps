# DevOps.Abstractions.BusinessObjects

## Summary

Namespace contains concepts that represent software "business objects", their properties, relationships between them, and schema, domain, and system categorization levels.

###
- Each **System** contains one or more **Domains**.
- Each **Domain** contains one or more **Schema**.
- Each **Schema** contains one or more **Concept**.
- Each **Concept** contains *properties* and *relationships* to other concepts.
- Each Concept has one (and only one) parent Schema.
- Each Schema has one (and only one) parent Domain
- Each Domain has one (and only one) parent System.

## Semantics

### System
A **System** represents a collection of one or more **Domains**.

Instances of this abstraction yield:
- VisualStudio Solution
- Git repository
- VSTS Build definition (to run on Pull Requests into `master` branch)
- Client application (MVC, Angular, Xamarin, UWP, etc.)

### Domain
Domains may be *based* on one (and only one) other domain. The intention of this restriction is that it will simplify code generating a database context for the domain. `[Domain]DbContext : [BaseDomain]DbContext`
Compose a **Domain** model with multiple **Domain** nodes chained together by setting the `Domain.BaseDomain` property.

Instances of this abstraction yield:
- VisualStudio class library project
- VisualStudio Solution project reference
- EntityFramework DbContext class (& IServiceCollection extension, etc.)
- Services / Web API / API client library
- VSTS Build & Release definitions (builds triggered by changes under project path in commit to `master`)

Domains that are referenced as the BaseDomain of another Domains are intended to be ignored in generating DbContexts, applications, etc.

### Schema

### Concept