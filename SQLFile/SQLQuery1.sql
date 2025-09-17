
create table FilesTable(
IDTable int primary key,
RandomDate Date,
RandomEuString nvarchar(20),
RandomRuString nvarchar(20),
RandomNumber BIGINT,
RandomDecimalNumber DECIMAL(10,8)
);
select * from FilesTable
delete from  FilesTable; 

create procedure GetNumber as
begin 
DECLARE @Summary BIGINT
DECLARE @MEDIAN DECIMAL(10,8)
	select @Summary = SUM(RandomNumber) from FilesTable;
	select @MEDIAN = AVG(RandomDecimalNumber) from FilesTable;

	select @Summary;
	select @MEDIAN;
end;


exec GetNumber