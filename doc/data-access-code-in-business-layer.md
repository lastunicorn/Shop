# Data Access Code in Business Layer

## 1) ADO.NET

A wile ago, around 10-15 years ago, we were using ADO.NET. And, in that time, many of the applications were having the ADO code mixed together with the business code.

It looked something like this:

```csharp
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
            // log the exception
        }
    }
}

return programs;
```

Back then, some smart guys, decided it is not a good practice to mix this code (the ADO code) with the business logic code.

Why? What are the disadvantages?

### Disadvantages

- **Big amount of code**
  - To be able to work easier, it is better to extracted in a different function or even a different class.
- **Different levels of abstraction => Different concerns**
  - The business logic code and the ADO code represent different levels of abstractions. The data access details (ADO) is of low importance while we are developing the business logic. In the business layer we want to focus on the business logic, not the details and particularities of how we access the data.
- **Hard to change the database and/or the data access library**
  - If we want to use other types of database (for example: NoSQL databases) or other libraries (for example an ORM) it is very hard, next to impossible, to do so without rewriting almost all the application.

## 2) Entity Framework (Linq)

The same query looks like this in Entity Framework:

```csharp
using (DbContext dbContext = new DbContext())
{
    return dbContext.Programs
        .Where(x => x.Name == "Boston Program")
        .ToList();
}
```

We have to agree it is a lot shorter, easier to write and understand. But, <u>is it ok now to mix this code with the business logic code, just because it is shorter</u>?

Does the disadvantages mentioned before disappeared just because we are using Linq?

### Example of data access details in Business

The following code will **crush at runtime** because of particularities of the Entity Framework's Linq. The method `NameIsBoston` cannot be translated into SQL.

```csharp
private void DoSomething()
{
    using (DbContext dbContext = new DbContext())
    {
        List<Program> programs dbContext.Programs
            .Where(x => NameIsBoston(x))
            .ToList();
        
        // Do something with the programs.
    }
}

private bool NameIsBoston(Program program)
{
    return program.Name == "Boston Program";
}
```

Do we want this type of concern to be 