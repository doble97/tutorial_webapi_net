drop database if exists kario;
create database kario;
use kario;
create table users(
    id int primary key auto_increment,
    name varchar(50) not null,
    last_name varchar(50) not null,
    email varchar(100) not null unique,
    password varchar(200) not null,
    created_at date
);

create table languages(
	id int primary key auto_increment,
    language varchar(20),
    cod_language varchar(2)
);

create table themes (
	id int primary key auto_increment,
    name varchar(50),
    created_at date,
    fk_user int,
    fk_language int,
    foreign key(fk_user) references users(id),
    foreign key(fk_language) references languages(id)
);
create table words(
	id int primary key auto_increment,
    word
);