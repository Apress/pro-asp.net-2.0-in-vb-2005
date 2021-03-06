if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountEmployees]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountEmployees]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployee]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllEmployees]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllEmployees]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployee]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeesByPage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeesByPage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployee]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE CountEmployees
AS
SELECT COUNT(EmployeeID) FROM Employees
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE DeleteEmployee
@EmployeeID	      int
AS

DELETE FROM Employees WHERE EmployeeID = @EmployeeID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetAllEmployees
AS
SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE GetEmployee
@EmployeeID	  int
AS
SELECT EmployeeID, FirstName, LastName, TitleOfCourtesy FROM Employees
  WHERE EmployeeID = @EmployeeID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE GetEmployeesByPage
@PageNumber	int,
@PageSize	int
AS

-- create a temporary table with the columns we are interested in
CREATE TABLE #TempEmployees
(
	ID 		int IDENTITY PRIMARY KEY,
	EmployeeID	int,
	LastName	nvarchar(20),
	FirstName	nvarchar(10),
	Title		nvarchar(30),
	TitleOfCourtesy	nvarchar(25),
	Address		nvarchar(60),
	City		nvarchar(15),
	Region		nvarchar(15),
	Country		nvarchar(15),
	Notes		ntext
)

-- fill the temp table with all the employees
INSERT INTO #TempEmployees
(
	EmployeeID,
	LastName,
	FirstName,
	Title,
	TitleOfCourtesy,
	Address,
	City,
	Region,
	Country,
	Notes
)
SELECT 
	EmployeeID,
	LastName,
	FirstName,
	Title,
	TitleOfCourtesy,
	Address,
	City,
	Region,
	Country,
	Notes
FROM 
  Employees ORDER BY EmployeeID ASC

-- declare two variables to calculate the range of records to extract for the specified page
DECLARE @FromID int
DECLARE @ToID int
-- calculate the first and last ID of the range of records we need
SET @FromID = ((@PageNumber - 1) * @PageSize) + 1
SET @ToID = @PageNumber * @PageSize

-- select the page of records
SELECT * FROM #TempEmployees WHERE ID >= @FromID AND ID <= @ToID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE InsertEmployee
@TitleOfCourtesy varchar(25),
@LastName        varchar(20),
@FirstName       varchar(10),
@EmployeeID	      int OUTPUT
AS

INSERT INTO Employees
  (TitleOfCourtesy, LastName, FirstName, HireDate) 
  VALUES (@TitleOfCourtesy, @LastName, @FirstName, GETDATE());

SET @EmployeeID = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

