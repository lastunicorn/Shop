# Return `IQueriable` from Repositories

## 1) ADO.NET

A wile ago, around 10-15 years ago, we were using ADO.NET. And, in that time, many of the applications were having the ADO.NET code mixed together with the business code.

It looked something like this:

```csharp
private void SomeBusinessMethod()
{
    List<Program> programs = new List<Program>();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sql = "SELECT * from Program where Name = @programName";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@programName", programName);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Program program = new Program();

                        program.ProgramId = long.Parse(reader["ProgramId"].ToString());
                        program.Name = reader["Name"].ToString();
                        program.Enabled = bool.Parse(reader["City"].ToString());
                        program.City = reader["City"].ToString();
                        // ...

                        programs.Add(program);
                    }

                    reader.Close();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                // Log the exception.
            }
        }
    }

    // Do something with the list of programs.
}
```

> **Note**: Please note, there are three important aspects in the above code:
>
> - **Connection details**
>   - The `SqlConnection`, `SqlCommand`, `SqlDataReader` objects.
> - **Query**
>   - That `string sql = "...";` variable.
>   - Describes what actions we want to execute on the database.
>   - Is written in SQL language.
> - **Data mapping**
>   - That `while` loop and the creation of the `Program` instances.
>   - Creates C# objects to store the data from the response.

Back then, some smart guys, decided that it is not a good practice to mix this code (the ADO.NET code) with the business logic code.

But Why? What are the disadvantages?

### Disadvantages

- **Big amount of code**
  - Indeed, it is easier to work with small functions.
  - We can extract the ADO.NET logic in a different function or even a different class.
- **Different concerns**
  - The business logic code and the ADO.NET code have, indeed different concerns. In the business layer we want to focus on the business logic, not the details and particularities of how we access the data.
- **Hard to change the database and/or the data access library**
  - If we want to use other types of databases (for example: NoSQL databases) or other libraries (for example an ORM) it is very hard, next to impossible, to do so without rewriting almost all the application.

## 2) Entity Framework

Later, it comes in the picture Entity Framework. The same query from above, now looks like this:

```csharp
private void SomeBusinessMethod()
{
    using (DbContext dbContext = new DbContext())
    {
	    List<Program> programs = dbContext.Programs
            .Where(x => x.Name == "Boston Program")
            .ToList();
        
        // Do something with the list of programs.
    }
}
```

> Notes:
>
> - **Connection details**
>   - Not visible anymore.
> - **Query**
>   - Still visible, but is written in C# (Linq over `IQueriable`).
>   - The SQL query is not visible anymore. It is automatically built by Entity Framework.
> - **Data mapping**
>   - Not visible anymore.
>   - Now, the data mapping is automated. No need to do it by hand.

We have to agree, the code is a lot shorter, easier to write and understand. But, <u>does the disadvantages mentioned before disappeared just because we are using Linq?</u>

### Previous Disadvantages

- **Big amount of code**
  - Not anymore.
- **Different concerns**
  - This one still stands.
  - The Linq query's concern is to create the SQL query that will retrieve the correct data. There can be all kinds of data access details there, in the Linq query:
    - `Include` statements needed only because Entity Framework is used.
    - We must be careful not to use forbidden methods that cannot be translated to SQL.
    - Database performance concerns:
      - Different queries may bring the same data, but have different performance.
  - Proof  that Linq query is a Data Access Layer detail:
    - Replace it with a stored procedure (for performance reasons). What code will you touch? Is it just the code in th eRepository or is it also the code in the Use Case?
    - What if we need (let's say for performance reasons) to change the Linq query with a call to a stored procedure? This is a concern of the data access, but can we currently do it without the need to change the business code? Unfortunately, no.
- **Hard to change the database and/or the data access library**
  - This one still stands.
  - If the database must be changed with another type (an in-memory or a NoSQL database, for example), a lot of business code must be updated.

## 3) Data Query in Business Layer vs Data Access Layer

### Query in Business Layer

The following code will **crush at runtime** because of particularities of the Entity Framework's Linq. The method `NameIsBoston` cannot be translated into SQL code.

[Business Layer]

```csharp
protected class SomeUseCase
{
    private void DoSomething()
    {
        List<Program> programs = ProgramRepository.GetAll()
            .Where(x => NameIsBoston(x))
            .ToList();

        // Do something with the programs.
    }

    private bool NameIsBoston(Program program)
    {
        return program.Name == "Boston Program";
    }
}
```

[Data Access Layer]

```csharp
public class ProgramRepository
{
    public IQueriable<Program> GetAll()
    {
        return dbContext.Programs;
    }
}
```

Do we want this type of concern to be handled in the Business Layer or, better, in the Data Access Layer?

The use case should be free to do whatever it wants with that data retrieved by the Repository, without the concerns of some specific database details.

### Query in Data Access Layer

[Business Layer]

```csharp
protected class SomeUseCase
{
    private void DoSomething()
    {
        List<Program> programs = ProgramRepository.GetAllInBoston()
            .ToList();

        // Do something with the programs.
    }
}
```

[Data Access Layer]

```csharp
public class ProgramRepository
{
    public IEnumerable<Program> GetAllInBoston()
    {
        return dbContext.Programs
            .Where(x => x.Name == "Boston Program");
    }
}
```

In this case, the repository is returning a in-memory collection of data. No SQL execution is involved. The business knows about in-memory object, it is free to whatever it wants with the collection.