# TodoAPI

Steps
1. Create DB - tododb
2. Create tables

```
CREATE TABLE [dbo].[Category] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NOT NULL,
    [Color]     NVARCHAR (50)  NULL,
    [IsDefault] BIT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Create the TodoItem table
CREATE TABLE [dbo].[TodoItem] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [IsCompleted] BIT            DEFAULT ((0)) NOT NULL,
    [CategoryId]  INT            NULL,
    [CreatedAt]   DATETIME       DEFAULT (getdate()) NOT NULL,
    [DueDate]     DATE           NOT NULL,
    [DueTime]     TIME (7)       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);




```

