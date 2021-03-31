SELECT 
	c.[Id], 
	CONCAT(c.[FirstName], ' ', c.[LastName]) as Name,  
	c.[Document],
	COUNT(o.[Id]) as ORDERS
FROM 
	CUSTOMER c 
INNER JOIN 
	[Order] o
ON
	o.[Id] = c.[Id]