--Q1
select D.Dependent_name as dependent_name, D.Sex as dependent_gender
from Dependent D join Employee E on D.ESSN = E.SSN
where D.sex= 'F' and E.Sex = 'F'
union
select D.Dependent_name as dependent_name, D.Sex as dependent_gender
from Dependent D join Employee E ON D.ESSN = E.SSN
where D.Sex = 'M' AND E.Sex = 'M';
--Q2
select Pname,sum(w.Hours)Hours
from Project p join Works_for w on p.Pnumber=w.Pno
group by Pname
--Q3
select d.*
from Departments d join Employee e on d.Dnum=e.Dno
where e.SSN=(select min(ssn) from Employee )
--Q4
select Dname,max(salary) MaxSal ,min(salary) MinSal,avg(salary)AvgSal
from Departments d join Employee e on d.Dnum =e.Dno
group by d.Dname
--Q5--
select distinct e.Fname +' ' +e.Lname 'Manger Name'
from Employee e join Departments d on e.SSN=d.MGRSSN 
left join Dependent dd on e.SSN=dd.ESSN
HAVING COUNT(dd.ESSN) = 0;
--Q6
select Dnum,Dname,count(MGRSSN) numofemp
from Departments  d join Employee e on d.Dnum =e.Dno
group by Dnum,Dname
having avg(e.Salary)< all(select avg (salary) from Employee)
--Q7--
select Fname+' '+Lname employeeName,Pname 
from Employee e join Works_for w on e.SSN=w.ESSn join Project p on w.Pno=p.Pnumber order by e.Dno , e.Fname,e.Lname
--Q8
select (salary)
from Employee 
where (salary)in(select top 2 salary from Employee order by Salary desc)
--Q9
select *
from Employee e join Dependent d on e.SSN=d.ESSN
where d.Dependent_name like '[e.Fname ]%' or d.Dependent_name like '%[e.Fname ]%'
--Q10
select SSN,Fname
from Employee
where exists(select * from Dependent)
--Q11
insert into Departments (Dname,Dnum,MGRSSN,[MGRStart Date])
values('DEPT IT',100,112233 ,'1-11-2006')
--Q12
update Departments set MGRSSN=968574 where Dnum=100
update Departments set MGRSSN=102672 where Dnum=20
update Employee set Superssn=102672 where SSN=102660 
--Q13
update Departments set MGRSSN=102672 where dnum=10delete from  Dependent where ESSN=223344 

delete from Dependent where ESSN=223344

update Departments set MGRSSN = NULL
where MGRSSN = 223344;

delete from Works_for where ESSn=223344
update Employee set Superssn = NULL
where Superssn = 223344;

delete from Employee where SSN=223344
--Q14
update Employee
set salary = salary * 1.3 
where SSN IN (
    select W.ESSN
    from Works_for W
    join Project P on W.Pno = P.Pnumber
    where P.Pname = 'Al Rabwah'
);
