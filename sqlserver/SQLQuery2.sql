create database day3constraint
create table Instructor(
ID  int identity primary key,
Fname varchar(20),
Lname varchar(20),
Salary decimal default 3000,
overtime decimal,
BD date,
hiredate date default getdate(),
Address varchar(50),
Age as year(getdate())-year(BD),
NetSalary as isnull(salary,0)+isnull(overtime,0) persisted, 
constraint c1 check (Address in('cairo','alex')),
constraint c2 check(salary between 1000 and 5000),
constraint c4 unique(overtime)
)
create table Course(
CID int identity primary key,
Cname varchar(50),
duration int ,
constraint uni_dur unique(duration)
)
create table Lab(
LID int identity ,
Location varchar(50), 
capacity int,
CID int ,
constraint pri_lab primary key(LID,CID),
constraint ck_cap check(capacity<20),
constraint fk_lab foreign key(CID) references course(CID) on  delete cascade on update cascade
)
create table ins_course(
inst_id int ,
cid int,
constraint pri_ins_course primary key(inst_id,CID),
constraint fk_inst_id foreign key (inst_id) references Instructor(ID) on  delete cascade on update cascade,
constraint fk_cid foreign key (cid) references Course(CID) on  delete cascade on update cascade
)