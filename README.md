# TodoAPI

Steps
1. Create DB - tododb
2. Create tables

```
CREATE TABLE Category (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment primary key
    Name NVARCHAR(255) NOT NULL,     -- Name of the category
    Color NVARCHAR(50),              -- Color representation (e.g., HEX code)
    IsDefault BIT NOT NULL DEFAULT 0 -- Indicates if this is the default category
);

-- Create the TodoItem table
CREATE TABLE TodoItem (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment primary key
    Title NVARCHAR(255) NOT NULL,     -- Title of the to-do item
    Description NVARCHAR(MAX),        -- Detailed description of the to-do item
    IsCompleted BIT NOT NULL DEFAULT 0, -- Status of completion
    CategoryId INT NOT NULL,          -- Foreign key referencing Category table
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Creation timestamp
    DueDate DATE NOT NULL,            -- Due date for the task
    DueTime TIME NOT NULL,            -- Due time for the task
    FOREIGN KEY (CategoryId) REFERENCES Category(Id) -- Foreign key constraint
);




```

3. appsettings.json
Copy connection string of tododb - from properties
4. Scaffold - in Nuget Console
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=tododb;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context TodoDbContext -UseDatabaseNames

