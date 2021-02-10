# Common Mistakes

## 1) Repositories that return View Models

The Repositories store Domain entities, they should accept and return Domain entities, not View Models, or any other object.

```csharp
public IEnumerable<OrderViewModel> GetOrders() 
{
    return dbContext.Orders
        .Select(x => new OrderViewModel(x))
        .ToList();
}
```

## 2) `Save`/`Update` methods in repositories

The `Repository` is supposed to be used as an in-memory collection of objects, like a `List<T>`. So, no need of these methods.

**Note**: The `DBSet<T>` class from Entity Framework has an `Update()` method, but, even if it has the same name, this method serves a different purpose. It is there to attach objects to the `DbContext`, without retrieving them from the actual database. I find the name of this method misleading.

### `Update` method

Do not create an `Update` method in the `Repository` class in order to save the changes made to an entity.

```csharp
Order order = orderRepository.Get(5);
order.State = OrderState.Completed;
orderRepository.Update(order);
```

Instead, let the `Repository` keep track of the changes for you (Entity Framework already offers this functionality) and ask the `UnitOfWork` to persist all changes at the end.

```csharp
Order order = unitOfWork.orderRepository.Get(5);
order.State = OrderState.Completed;

unitOfWork.Complete();
```

### `Save` method

Do not create a `Save` method in each `Repository` class.

```csharp
orderRepository.Add(order);
orderRepository.Save();
 
paymentRepository.Add(payment);
paymentRepository.Save();
```

Instead, create a `Complete` method in the `UnitOfWork` that will save all the changes from all the repositories at the end.

```csharp
unitOfWork.orderRepository.Add(order);
unitOfWork.paymentRepository.Add(payment);

unitOfWork.Complete();
```

## 3) Repositories that return `IQueryable`

By returning `IQueriable`, the repository allows other parts of the application to construct the queries that are sent to the database. But one of the reasons to use Repositories is exactly to encapsulate these queries. The queries are a private part of a `Repository` class. They should not leak into the rest of the application. (OOP – Encapsulation)

```csharp
public IQueriable<Order> GetOrders()
{
	return dbContext.Orders
    	.Where(x => x.CustomerId == 1234);
}
```

