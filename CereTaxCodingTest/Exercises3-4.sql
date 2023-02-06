CREATE TABLE dbo.Customers(
    Id int IDENTITY(1,1) NOT NULL,
    FirstName varchar(50) NOT NULL,
    MiddleName varchar(50) NULL,
    LastName varchar(50) NOT NULL,
    DateOfBirth date NOT NULL,
    -- address would be a separate table or broken out into multiple fields for multiple reasons
    Address varchar(255) NOT NULL
    CONSTRAINT PK_Customers PRIMARY KEY CLUSTERED
    (
        Id ASC
    ))
GO


INSERT INTO dbo.Customers
    (FirstName, MiddleName, LastName, DateOfBirth, Address)
VALUES
    ('Charles', 'Alan', 'Sexton', '05/24/1981', '200 Mocks Church Rd. Advance NC 27006'),
    ('Dummy', NULL, 'Test', '05/24/1982', '270 Mocks Church Rd. Advance NC 27006'),
    ('Dummy1', NULL, 'Testing', '05/24/1983', '271 Mocks Church Rd. Advance NC 27006'),
    ('Dummy2', NULL, 'Testing 2', '05/24/1984', '272 Mocks Church Rd. Advance NC 27006'),
    ('John', NULL, 'Doe', '05/24/1985', '273 Mocks Church Rd. Advance NC 27006'),
    ('Bob', NULL, 'Billy', '05/24/1986', '274 Mocks Church Rd. Advance NC 27006'),
    ('Hello', 'Sql', 'World', '05/24/1987', '275 Mocks Church Rd. Advance NC 27006'),
    ('Testing', NULL, 'Sql', '05/24/1988', '276 Mocks Church Rd. Advance NC 27006')
GO


-- 
-- Test Execution
-- EXEC [dbo].[GetCustomersWhereLastNameStartsWith]
CREATE PROCEDURE dbo.GetCustomersWhereLastNameStartsWith
    @startsWith VARCHAR(50) = 'Test'
AS
BEGIN
    SELECT
        Id,
        FirstName,
        LastName
    FROM Customers
    WHERE LastName LIKE (@startsWith + '%')
END
GO