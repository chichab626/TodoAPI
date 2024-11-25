# TodoAPI

Steps
1. Create DB - tododb
2. Create tables

```
CREATE TABLE [dbo].[Category] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [Color] VARCHAR (50) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Todo] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (100) NOT NULL,
    [Description] VARCHAR (200) NOT NULL,
    [DueDate]     DATETIME      NOT NULL,
    [CategoryId]  INT           NOT NULL,
    CONSTRAINT [FK_Todo_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]), 
    CONSTRAINT [PK_Todo] PRIMARY KEY ([Id])
);




```

3. appsettings.json
Copy connection string of tododb - from properties
4. Scaffold - in Nuget Console
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=tododb;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context TodoDbContext -UseDatabaseNames

