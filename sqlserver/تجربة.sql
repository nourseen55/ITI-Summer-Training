select *
from production.products
order by product_id
offset 5 rows 
fetch next 10 rows only;
---
select *
from production.categories
order by category_name
offset 2 rows
fetch next 10 rows only
---
select concat(product_name,cast(list_price as varchar))
from production.products
select concat(product_name,convert(varchar,list_price))
from production.products;
--
with MaxPrice As
(
	select MAX(list_price) as MaxSal
	from production.products
)
select *
from production.products
where list_price<(select * from MaxPrice);
---
with avgprice as (
select AVG(list_price) 'avgsal'
from production.products
)
select *
from production.products
where list_price <(select * from avgprice);
---
create rule r1 as @x>1000;
sp_bindrule r1,'production.products.list_price'
sp_unbindrule r1,'production.products.list_price'
--

create table parent (Pid int Primary key)

create table child(cid int foreign key references Parent(pid))

insert into Parent values(1)
insert into Parent values(2)
insert into child values(1)

begin try 
begin transaction 
insert into child values(5)
insert into child values(11)
commit
end try
begin catch 
rollback
end catch
