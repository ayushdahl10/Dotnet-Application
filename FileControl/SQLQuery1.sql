create database ItemDB

create table items(

id int primary key identity(1,1),
item_name nvarchar(50),
item_quantity decimal(16,2),
item_amount decimal(16,2),
item_discount decimal(16,2),
item_rate decimal(16,2)
)

drop table items

create proc getItems
as
begin 
select * from items
end
exec getItems

create proc addItem @name nvarchar(50) , @quantity  decimal(16,2), @amount  decimal(16,2), @discount  decimal(16,2), @rate  decimal(16,2) 
as 
begin 
insert into items(item_name,item_quantity,item_amount,item_discount,item_rate)
select @name,@quantity,@amount,@discount,@rate
end 