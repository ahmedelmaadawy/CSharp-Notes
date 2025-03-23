# Introduction

Concurrency management is a critical aspect of database applications, ensuring data integrity when multiple users attempt to modify the same record simultaneously. In SQL Server, **row versioning** provides an effective way to handle concurrency by maintaining a version of each row that updates automatically on modification. Additionally, hashing mechanisms like **CHECKSUM** can be used for lightweight data integrity checks.

When working with **Entity Framework Code First**, managing concurrency becomes even more crucial, as changes made in-memory need to be synchronized with the database. EF provides built-in support for **optimistic concurrency control**, leveraging **Row Version (timestamp)** fields to detect conflicts and prevent data loss.

In this article, we will explore:

- How **Row Version** works in SQL Server for tracking changes.
- Implementing **Row Version** in **Entity Framework Code First** for concurrency management.
- Best practices for handling concurrency in .NET applications.

By the end, you'll have a clear understanding of how to ensure data consistency in your applications using SQL Server and Entity Framework.
# Optimistic vs Pessimistic Concurrency Control 
## Optimistic concurrency control (OCC) 
Assume that conflicts are rare and allow multiple transactions to proceed without locking resources it checks if data is changed from the last time it was read 
EX: Row Versioning
## Pessimistic Concurrency Control (PCC)
Assumes conflicts are likely and prevent them by locking records when they are accessed the other transactions must wait until the lock is released 
EX: lock or SELECT FOR UPDATE in SQL
# Row Version
A type of optimistic concurrency control is row version 
The `rowversion` data type in SQL Server is a unique binary number that is automatically generated and updated whenever a row is modified. This data type is particularly useful for version-stamping table rows, allowing for efficient concurrency control and tracking changes over time.

Row version in SQL is automatic generated whenever a row is inserted or updated this ensures that each row has a unique row version. 

what makes row version great for concurrency control is the simplicity of it and performance remember that you do not need to lock the record you can check whether a record has been updated or not this reduces conflicts .

remember that row version is only unique per table .
## How to implement Row Version in SQL
When defining a `rowversion` column in a SQL Server table, you can do so as follows:
```SQL
CREATE TABLE ExampleTable ( 
  ID INT PRIMARY KEY,
  Data NVARCHAR(100), 
  RowVer ROWVERSION );
```
# EF Code First Row Version

Here is how to write a model with Row version using data annotation :

```C#
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
}
```
we use the `[Timestamp]` attribute to map a property to a SQL Server `rowversion` column.

Using Fluent API :
```C#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>()
        .Property(p => p.Version)
        .IsRowVersion();
}
```

update operation with row version 
```C#
var person = await context.People.SingleAsync(b => b.FirstName == "John");
person.FirstName = "Paul";
await context.SaveChangesAsync();
```
1. In the first step, a Person is loaded from the database; this includes the concurrency token, which is now tracked as usual by EF along with the rest of the properties.
2. The Person instance is then modified in some way - we change the `FirstName` property.
3. We then instruct EF Core to persist the modification. Since a concurrency token is configured, EF Core sends the following SQL to the database:

```SQL
UPDATE [People] SET [FirstName] = @p0
WHERE [PersonId] = @p1 AND [Version] = @p2;
```
Note that in addition to the `PersonId` in the WHERE clause, EF Core has added a condition for `Version` as well; this only modifies the row if the `Version` column hasn't changed since the moment we queried it.

In the normal ("optimistic") case, no concurrent update occurs and the UPDATE completes successfully, modifying the row; the database reports to EF Core that one row was affected by the UPDATE, as expected. However, if a concurrent update occurred, the UPDATE fails to find any matching rows and reports that zero were affected. As a result, EF Core's `SaveChanges()` throws a `DbUpdateConcurrencyException`, which the application must catch and handle appropriately.

# Handling Concurrency Exceptions

If another transaction modifies the record before `SaveChanges()`, the update **fails** because `Version` has changed. This results in a **`DbUpdateConcurrencyException`**, which you must handle: 
```C#
try
{
    await context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException ex)
{
//Your logic to handle concurrency conflict
}
```

# Conclusion
**Row Versioning** is a powerful technique for **optimistic concurrency control** in SQL Server. 
**Entity Framework Code First** makes it easy to implement using the `[Timestamp]` attribute.  