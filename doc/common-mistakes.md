# Common Mistakes

## 1) Repositories that return View Models

The Repositories store Domain entities, they should accept and return Domain entities, not View Models, or any other type of objects.

[No]

```csharp
public IEnumerable<OrderViewModel> GetOrders() 
{
    return dbContext.Orders
        .Select(x => new OrderViewModel(x))
        .ToList();
}
```

## 2) `Update` method in repositories

The `Repository` is supposed to be used as an in-memory collection of objects, like a `List<T>`.

Do not create an `Update` method in the `Repository` class in order to save the changes made to an entity.

[No]

```csharp
Order order = orderRepository.Get(5);
order.State = OrderState.Completed;
orderRepository.Update(order);
```

Instead, let the `Repository` keep track of the changes for you (Entity Framework already offers this functionality) and ask the `UnitOfWork` to persist all changes at the end.

[Yes]

```csharp
Order order = unitOfWork.orderRepository.Get(5);
order.State = OrderState.Completed;

unitOfWork.Complete();
```

**Note**: The `DBSet<T>` class from Entity Framework has an `Update()` method, but, even if it has the same name, this method serves a different purpose. It is there to attach objects to the `DbContext`, without retrieving them from the actual database. I find the name of this method misleading.

## 3) `Save` method in repositories

Do not create a `Save` method in each `Repository` class.

[No]

```csharp
orderRepository.Add(order);
orderRepository.Save();
 
paymentRepository.Add(payment);
paymentRepository.Save();
```

Instead, create a `Complete` method in the `UnitOfWork` that will save all the changes from all the repositories at the end.

[Yes]

```csharp
unitOfWork.orderRepository.Add(order);
unitOfWork.paymentRepository.Add(payment);

unitOfWork.Complete();
```

In this way, the `UnitOfWork` can save the changes from all the repositories, in a transactional way.

## 4) Repositories that return `IQueryable`

By returning `IQueriable`, the Repository allows other parts of the application to construct the queries that are sent to the database. But one of the reasons to use Repositories is exactly to encapsulate these queries. The queries are a private part of a `Repository` class. They should not leak into the rest of the application. (OOP – Encapsulation)

[No]

```csharp
public IQueriable<Order> GetOrders()
{
	return dbContext.Orders
    	.Where(x => x.CustomerId == 1234);
}
```

[Yes]

```csharp
public IEnumerable<Order> GetOrders()
{
	return dbContext.Orders
    	.Where(x => x.CustomerId == 1234);
}
```

By returning `IEnumerable`, all the subsequent Linq queries that may be written by the caller will be executed on the collection in memory.

In this way, all the Linq queries that are executed on the database as SQL are encapsulated into the `Repository` class (Data Access Layer). No data access logic is leaking into the other layers of the application.