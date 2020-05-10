# ref-dnc-ddb-aws
Reference Application with .NET Core with DynamoDB on AWS (Application of Expenses)


## Architecture Composition

.NET Core : 
DynamoDB :
AWS :


## Reference Application 
### Name : Finance exanses
### Use Cases
1) Allow users to register the expenses
2) List of all expenses which a user has registered
3) List all expenses which a user has registered for a specifice date or a category or a status
4) List all expenses which a user has registered where the user isn't sure of the category or date
5) Provide an overall stats (Total, Average, status, etc) of expenses
6) List all expenses and all users for administrative purposes
7) Update the already registered expense

### Database Model
- Key model : Composite primary key
- Partition Key(var: <Guid>UserId) - GUID for a user
- Sort Key(var: <string>InvoiceKey) - Unique Invoice Name (= GUID + ItemName)
 * role as a sencondary index
- Invoice Date(var: <string>InvoiceDate) - Date of invoice of expense
- Payment Date(var: <string>PaymentDate) - Date of payment for remittance
- Remittance Status(var: <string>FinanceStatus) - Status of Process (e.g. Requested, Processing, Paid)
- Currency Codes by Country(var: <string>CurrencyCode) - Currency Code (e.g. GBP, EUR, USD)
- Amount(var: <int>Amount - Amount of Item
- Invoice Category: (var: <string>InvoiceCategory - Category of expenses (e.g. Accommodation, Meals, Taxi, Bus, Train, Gift, Stationary, - Course, Book, etc)
- Budget Type(var: <string>BudgetType - Budget Type of expenses (e.g. Travel, Welfare, Entertainment, Sample, Education, Others) 
- Remarks(var: <string>Remarks - Description of Item(expense)



## Development Environment
### Frontend App 
#### React JS
Template : https://github.com/tabler/tabler-react/tree/master/example

Build initial App
```
npx create-react-app ./
```

Dependancy / Packages
```

```
