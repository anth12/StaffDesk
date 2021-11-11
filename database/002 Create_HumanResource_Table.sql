
CREATE TABLE [dbo].[HumanResource](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] [NVARCHAR](255) NOT NULL,
	[LastName] [NVARCHAR](255) NOT NULL,
	[EmailAddress] [NVARCHAR](255) NOT NULL,
	[DateOfBirth] DATE NULL,
	[Status] INT NOT NULL,
	[EmployeeNumber] [NVARCHAR](20) NOT NULL,
	[DepartmentId] INT NOT NULL
	
    FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id])
)
