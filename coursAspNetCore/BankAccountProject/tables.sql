--- Table customer
CREATE TABLE customer(
id int primary key identity(1,1),
first_name varchar(255) not null,
last_name varchar(255) not null,
phone varchar(10) not null,
email varchar(255) not null);

-- Table account
CREATE TABLE account(
id int primary key identity(1,1),
amount decimal not null,
customer_id int not null
);

-- Table opération
CREATE TABLE operation(
id int primary key identity(1,1),
amount decimal not null,
account_id int not null,
date_operation datetime not null
);

--Table saving account
CREATE TABLE saving_account(
id int primary key identity(1,1),
account_id int not null,
interest decimal not null);

--Table Paid account
CREATE TABLE paid_account(
id int primary key identity(1,1),
account_id int not null,
operation_cost decimal not null);