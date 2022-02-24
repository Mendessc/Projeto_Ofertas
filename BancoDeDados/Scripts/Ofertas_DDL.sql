create database Ofertas;
go 

use Ofertas;

create table TipoUsuario(
idTipoUsuario int primary key identity,
nomeTipoUsuario varchar(20)
);
go

create table Categoria(
idCategoria int primary key identity,
nomeCategoria varchar (100)
);
go

create table Usuario(
idUsuario int primary key identity,
idTipoUsuario int foreign key references TipoUsuario(idTipoUsuario),
email varchar(256),
senha varchar(20)
);
go

create table Fornecedor(
idFornecedor int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
nome varchar(100),
cnpj varchar(14),
endereco varchar(100),
telefone varchar(11)
);
go

create table Consumidor(
idConsumidor int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
nome varchar(100),
cpf varchar (11),
tefelone varchar (11)
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


