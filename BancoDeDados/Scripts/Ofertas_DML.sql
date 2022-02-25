use Ofertas;

--Tipo usuario
Insert into TipoUsuario(nomeTipoUsuario)
Values ('Administrador'),('Consumidor'),('Fornecedor');
go

--usuario
insert into Usuario(idTipoUsuario,email,senha)
values ('1','admin@email.com','admin123'),
	   ('2','shock@email.com','shock123'),
	   ('2','lucas@email.com','lucas123'),
	   ('2','martins@email.com','martins123'),
	   ('3','henrique@email.com','henrique123'),
	   ('3','natan@email.com','natan123'),
	   ('3','jhon@email.com','jhon123')
go

--categoria
insert into Categoria(nomeCategoria)
values ('Alimentos'),
	   ('Roupas'),
	   ('Cosméticos'),
	   ('Acessorios'),
	   ('Mais Vendidos'),
	   ('Eletrodoméstico')
go

--fornecedor
insert into Fornecedor(idUsuario,nome,cnpj,endereco,telefone)
values('5','SuperMercado Extra','10203040506070','Alameda Barão de Limeira, 486','1135526128'),
	  ('6','Brecho Barão','70605040302010','Rua Natanael Tito Salmon, 317','11937033197'),
	  ('7','Casas Bahia','30405020107060','Praça Ramos de Azevedo, 131','1143258989')
go

--consumidor
insert into Consumidor(idUsuario,nome,cpf,tefelone)
values ('2','Marcos Paulo','89839721810','11982984378'),
	   ('3','Lucas Mendes','19760733838','11977328590'),
	   ('4','Matheus Martins','18251851823','11932314567')

--produto
insert into Produto(idFornecedor,idCategoria,nomeProduto,dataValidade,imagemProduto,descricao,preco)
values('1','1','Leite Piracujaba Integral 1L','19/03/2022','','','8.00'),
	  ('1','1','Farinha de trigo Sol Especial 1Kg','09/03/2022','','','5.00'),
	  ('1','1','Aveia sem Glúten Jasmine Flocos 200g ','11/03/2022','','','7.00'),
	  ('2','2','Camiseta Branca Lisa','22/10/2022','','','22.00'),
	  ('3','6','Liquidificador Mondial Com Filtro 2L','10/11/2022','','','85.00')