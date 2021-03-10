# Entity Framework vs Custom Repositories

## Entity Framework

Entity Framework already implements the Repository and Unit of Work patterns:

**`DbSet<T>` is a Repository**

- (+) Hides the details of accessing the data
- (+) Emulates an in-memory collection
- (-) We have no place where to write custom queries that can be later used in multiple places in the rest of the application.

**`DbContext` is a Unit of Work**

- (+) Ensures data consistency
  - It provides the `SaveChanges` method.

## Important Decision

> Do we really need to create our custom `Repository` and `UnitOfWork` classes if we already use the Entity Framework Core?
>
This is a decision that must be taken by each team on each project, but please, take it consciously. Make a meeting, discuss the subject, talk about advantages and disadvantages, and then take the decision.

Here are some advantages and disadvantages that I can think of for creating custom Repository and Unit of Work classes.

## Custom Repositories and Unit of Work

### Advantages

**Helps to avoid code duplication.**

- The Repository classes offers a place where we can write queries that are needed in multiple places in the application.
- Note: There are, indeed, other ways to avoid this code duplication. For example, by creating extended methods for DbSet<T> where the queries can be placed.

**Encapsulates the data queries (the Linq queries written on `IQueriable`**)

Linq on `IQueriable` are a detail of the data storage type and ORM framework used.

- Not any data storage can be accessed using `IQueriable`.
- It comes with limitations that needs extra attention that we do not want to handle in the business layer:
  - We cannot use local methods in the queries because they cannot be translated into SQL code.
  - We may need `Include` directives (in Entity Framework) not necessary if other frameworks are used.
- By creating a `Repositpory` class, we can limit the need to think of these database details only when we work in the Data Access module.

**Encapsulates (hides) the usage of Entity Framework.**

- Entity Framework is a detail of the Data Access Layer. None of the other modules of the application should be aware of its existence. They should not be able to tell if Entity Framework, NHibernate, Dapper, ADO.NET or any other data access technology is used.
- By doing so, it allows us to easily test the other modules, update the Entity Framework to a new version or replace it with another mechanism.

### Disadvantages

- Creating an additional abstraction layer (`I{Name}Repository` and `IUnitOfWork`), adds complexity to the application.

## How to check if some logic is part of the Data Access or Business Layer?

Replace the Data Access with another one (an an in-memory one, for example) that does not use Entity Framework. Did you need to make adjustments to the Business Layer classes? If yes, then, that code is not part of the Business, it is Data Access.