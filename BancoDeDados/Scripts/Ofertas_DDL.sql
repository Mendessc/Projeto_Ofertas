create database Ofertas;
go 

use Ofertas;

create table TipoUsuario(
idTipoUsuario int primary key identity,
nomeTipoUsuario varchar(20) not null
);
go

create table Categoria(
idCategoria int primary key identity,
nomeCategoria varchar (100) not null
);
go

create table Usuario(
idUsuario int primary key identity,
idTipoUsuario int foreign key references TipoUsuario(idTipoUsuario),
email varchar(256) not null,
senha varchar(20) not null
);
go

create table Fornecedor(
idFornecedor int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
nome varchar(100) not null,
cnpj varchar(14) not null,
endereco varchar(100) not null,
telefone varchar(11) not null
);
go

create table Consumidor(
idConsumidor int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
nome varchar(100) not null,
cpf varchar (11) not null,
tefelone varchar (11) not null
);
go 

create table Produto(
idProduto int primary key identity,
idFornecedor int foreign key references Fornecedor(idFornecedor),
idCategoria int foreign key references Categoria(idCategoria),
nomeProduto varchar(200) not null,
dataValidade date not null,
imagemProduto varchar(255) not null,
descricao varchar(200) not null,
preco float not null
);
go

create table Reservas(
idReserva int primary key identity,
idConsumidor int foreign key references Consumidor(idConsumidor),
idProduto int foreign key references Produto(idProduto)
);
go

/*drop table Reservas;
drop table Produto;
drop table Consumidor;
drop table Fornecedor;
drop table Usuario;
drop table Categoria;
drop table TipoUsuario;*/
