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
npm i d3-scale formik prop-types react-c3js react-google-maps react-router react-router-dom react-simple-maps react-syntax-highlighter refractor tabler-react --save
```

### Backend
#### AWS Amplify
1) Installation / Basic Setup
Get started with Amplify CLI
```
npm install -g @aws-amplify/cli
```

2) Create Amplify User Profile
 * if we have a profile already, we can skip this
 
3) create the initial project as a ('dev') environment
```
$ amplify init
Scanning for plugins...
Plugin scan successful
Note: It is recommended to run this command from the root of your app directory
? Enter a name for the project dexpensys
? Enter a name for the environment dev
? Choose your default editor: Visual Studio Code
? Choose the type of app that you're building javascript
Please tell us about your project
? What javascript framework are you using react
? Source Directory Path:  src
? Distribution Directory Path: build
? Build Command:  npm run build
? Start Command: npm run start
Using default provider  awscloudformation

⠦ Initializing project in the cloud...
:
:

CREATE_COMPLETE
```

4) Add the modules (Auth)
```
(albert) ~/_dev/_web/dnderp $ amplify add auth
Using service: Cognito, provided by: awscloudformation
 
 The current configured provider is Amazon Cognito. 
 
 Do you want to use the default authentication and security configuration? Default configuration
 Warning: you will not be able to edit these selections. 
 How do you want users to be able to sign in? Username
 Do you want to configure advanced settings? No, I am done.
Successfully added resource dnderp03cd1a97 locally
```

5) Add the modules (API)
```
(albert) ~/_dev/_api/dotnetcore-dynamo-aws/ref-dnc-ddb-aws $ amplify status
Scanning for plugins...
Plugin scan successful

Current Environment: dev

| Category | Resource name     | Operation | Provider plugin   |
| -------- | ----------------- | --------- | ----------------- |
| Auth     | dexpensys997ed4bb | Create    | awscloudformation |


(albert) ~/_dev/_api/dotnetcore-dynamo-aws/ref-dnc-ddb-aws $ amplify api add
? Please select from one of the below mentioned services: REST
? Provide a friendly name for your resource to be used as a label for this category in the project: dexpensysapigw
? Provide a path (e.g., /book/{isbn}): /expenses
? Choose a Lambda source Create a new Lambda function
? Provide a friendly name for your resource to be used as a label for this category in the project: dexpensyslambda
? Provide the AWS Lambda function name: dexpensyslambda
? Choose the function runtime that you want to use: .NET Core 3.1
? Choose the function template that you want to use: Serverless
? Do you want to access other resources created in this project from your Lambda function? No
? Do you want to invoke this function on a recurring schedule? No
? Do you want to edit the local lambda function now? No
Succesfully added the Lambda function locally
? Restrict API access No
? Do you want to add another path? No
Successfully added resource dexpensysapigw locally

Some next steps:
"amplify push" will build all your local backend resources and provision it in the cloud
"amplify publish" will build all your local backend and frontend resources (if you have hosting category added) and provision it in the cloud
```

