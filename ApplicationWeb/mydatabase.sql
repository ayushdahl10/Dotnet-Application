select * from info

drop table info

create table info
(

id int primary key identity(1,1),
city_name varchar(40),
country_name varchar(40),
longitude varchar(30),
latitude varchar(30)

)

create proc getInfo
as
begin 
select * from info
end

exec getInfo

create proc addinfo @city_name varchar(40) , @country_name varchar(40), @longitude varchar(30), @latitude varchar(30)  
as 
begin 
if @city_name=city_name
insert into info(city_name,country_name,longitude,latitude)
select @city_name , @country_name , @longitude ,@latitude
end 
