# Repository

## What is a Repository?

> 
>
> “A Repository mediates between the domain and data mapping layers, acting like an in-memory domain object collection.” (Martin Fowler) 
>
> 

![Repository](repository.drawio.png)

First of all, let’s state the obvious:

- A Repository class is called like so because it is a place where the application stores its domain entities. And I want to emphasize this: domain entities; not database entities, not DTOs, not View Models or any other type of objects, but domain entities.

Each Repository class must contain a single type of domain entity. In other words, there must be created a Repository class for each type of domain entity.

## Benefits

- **Use the storage like an in-memory collection**
  - Allows the rest of the application to work with the data as it would be an in-memory collection.
  - "A Repository [...] provides a more object-oriented view of the persistence layer. (Martin Fowler)"
  - The repository should provide `Get`, `Add`, `Remove`, but no `Update` method.
  - No `Save` method, also.
    - The `Save` method should be present in the `UnitOfWork` class.
- **Hides the details of accessing the data storage.**
  - The data may be stored in a database, a file on disk (xml, json, binary, etc...) or even a web service. The repository class encapsulates the details that come with each storage type.
  - The framework used to access the data (like Entity Framework, NHibernate, Dapper, ADO.NET, etc.) is also a detail.
- **Eliminates duplicate query logic.**
  - This is the place where we can write queries that will be used, later, in multiple places in the rest of the application.
  - Indeed, there is also other ways of avoiding code duplication without using repository classes. For example, to create extended methods for `DbSet<T>` where to write those queries.