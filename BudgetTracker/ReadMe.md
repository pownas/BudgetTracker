# BudgetTracker.Blazor




## Skapa databasen 

### Fel som uppstod vid skapande av databas
När jag skapade migrations via: 

```ps
cd .\BudgetTracker.Blazor\BudgetTracker.Blazor\
dotnet ef migrations add InitialCreate
```

Så fick jag varningarna: 
```ps
Build succeeded.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Belopp' on entity type 'TransactionIca'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]
      No store type was specified for the decimal property 'Saldo' on entity type 'TransactionIca'. This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values in 'OnModelCreating' using 'HasColumnType', specify precision and scale using 'HasPrecision', or configure a value converter using 'HasConversion'.
Done. To undo this action, use 'ef migrations remove'
```
