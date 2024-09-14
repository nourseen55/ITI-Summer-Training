--Q1
select d.Dnum ,d.Dname,e.Fname +' '+e.Lname [Manger Name]
from Departments d join Employee e on e.SSN =d.MGRSSN
--Q2
select d.Dnum ,d.Dname,p.Pname projectName
from Departments d join Project p on d.Dnum=p.Dnum
--Q3
select d.*, concat(e.Fname,' ',e.Lname)EmployeeName
from Employee e join Dependent d on e.SSN =d.ESSN
--Q4
select Pnumber,Pname,Plocation,city
from Project
where city in('Alex','Cairo')
--Q5
select *
from Project
where Pname like 'a%'
--Q6
select *
from Employee 
where Dno=30 and Salary between 1000 and 2000
--Q7
select*
from Employee e join Works_for w on e.SSN =w.ESSn join Project p on
p.Pnumber=w.Pno
where w.Hours>=10 and p.Pname='AL Rabwah' and e.Dno=10
--Q8
select e.Fname+e.Lname 'EmployeeName',s.Fname+s.Lname 'SupervisiorName'
from Employee s join Employee e on s.SSN=e.Superssn
where s.Fname='Kamel' and s.Lname ='Mohamed'
--Q9
select  e.Fname+e.Lname 'EmployeeName',p.Pname 'projectName'
from Employee e join Works_for w on e.SSN =w.ESSn join Project p on
p.Pnumber=w.Pno
order by p.Pname
--Q10
select p.Pnumber,d.Dname,e.Lname,e.Address,e.Bdate
from Employee e join Departments d on e.SSN=d.MGRSSN join Project p on d.Dnum=p.Dnum
where p.City='Cairo'
--Q11
select *
from Employee e join Departments d on e.SSN=d.MGRSSN
--Q12
select *
from Employee e left join  Dependent d on e.SSN =d.ESSN 
--Q13
insert into Employee (Dno,SSN,Superssn,Salary)
values(30,102672,112233,3000)
--Q14
insert into Employee (Dno,SSN)
values(30,102660)
--Q15
update Employee
set Salary=Salary *(1+(20/100))
