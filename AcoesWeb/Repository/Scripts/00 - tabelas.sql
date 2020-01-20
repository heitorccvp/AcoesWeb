USE [TESTE]
GO


if OBJECT_ID('associados') is null
begin

CREATE TABLE [dbo].[associados](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) NULL,
	[cnpj] varchar(30),
	CONSTRAINT pk_id_associados PRIMARY KEY (id),
) 
end
GO

if OBJECT_ID('farmacias') is null
begin

CREATE TABLE [dbo].[farmacias](
	[id] [int] identity (1,1) NOT NULL,
	[id_associado] int not null,
	[nome] varchar(150) NULL,
	[local] varchar(150) null, 
	CONSTRAINT pk_id_farmacias PRIMARY KEY (id),
	CONSTRAINT fk_farmacias_associados FOREIGN KEY (id_associado)
    REFERENCES associados(id)
)
end
GO

if OBJECT_ID('gondolas') is null
begin

CREATE TABLE [dbo].[gondolas](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) NULL,
	[id_farmacia] int not null,
	[id_posicao] int NULL,
	[altura] decimal(5,2) null,
	[largura] decimal(5,2) null,
	CONSTRAINT pk_id_gondolas PRIMARY KEY (id),
	CONSTRAINT fk_gondolas_farmacias FOREIGN KEY (id_farmacia)
    REFERENCES farmacias(id)
)
end
GO


if OBJECT_ID('partes') is null
begin

CREATE TABLE [dbo].[partes](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) NULL,
	[id_gondola] int not null,
	[id_posicao] int null,
	[altura] decimal(5,2)   null,
	[largura] decimal(5,2) null,
	CONSTRAINT pk_id_partes PRIMARY KEY (id),
	CONSTRAINT fk_partes_gondolas FOREIGN KEY (id_gondola)
    REFERENCES gondolas(id)
)
end
GO

if OBJECT_ID('posicao') is null
begin

CREATE TABLE [dbo].[posicao](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) null
	CONSTRAINT pk_id_posicao PRIMARY KEY (id)
)
end
GO

if OBJECT_ID('status') is null
begin

CREATE TABLE [dbo].[status](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) null
	CONSTRAINT pk_id_status PRIMARY KEY (id)
)
end
GO

if OBJECT_ID('fornecedores') is null
begin

CREATE TABLE [dbo].[fornecedores](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) null
	CONSTRAINT pk_id_fornecedores PRIMARY KEY (id)
)
end
GO

if OBJECT_ID('produtos') is null
begin

CREATE TABLE [dbo].[produtos](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) null,
	[id_fornecedor] int not null
	CONSTRAINT pk_id_produtos PRIMARY KEY (id),
		CONSTRAINT fk_produtos_fornecedores FOREIGN KEY (id_fornecedor)
    REFERENCES fornecedores(id)
)
end
GO

if OBJECT_ID('aprovadores') is null
begin

CREATE TABLE [dbo].[aprovadores](
	[id] [int] identity (1,1) NOT NULL,
	[nome] varchar(150) null
	CONSTRAINT pk_id_aprovadores PRIMARY KEY (id)
)
end
GO

if OBJECT_ID('acoesMkt') is null
begin

CREATE TABLE [dbo].[acoesMkt](
	[id] [int] identity (1,1) NOT NULL,
	[Nome] [varchar](150) NULL,
	[id_associado] int not null,
	[id_farmacia] int not null,
	[id_gondola] int not null,
	[id_partes] int not null,
	[id_fornecedor] int null,
	[id_status] int null,
	[id_aprovador] int null,
	[valor] decimal not null,
	[dataVenda] datetime null,
	[dataAgendamento] datetime null, 
	[dataPagamento] datetime null,
	CONSTRAINT pk_id_acoes PRIMARY KEY (id),
	CONSTRAINT fk_acoes_id_associado FOREIGN KEY (id_associado)
    REFERENCES associados(id),
	CONSTRAINT fk_acoes_farmacias FOREIGN KEY (id_farmacia)
    REFERENCES farmacias(id),	
	CONSTRAINT fk_acoes_gondolas FOREIGN KEY (id_gondola)
    REFERENCES gondolas(id),
	CONSTRAINT fk_acoes_partes FOREIGN KEY (id_partes)
    REFERENCES partes(id),
	CONSTRAINT fk_acoes_fornecedores FOREIGN KEY (id_fornecedor)
    REFERENCES fornecedores(id),
	CONSTRAINT fk_acoes_status FOREIGN KEY (id_status)
    REFERENCES status(id),
	CONSTRAINT fk_acoes_aprovadores FOREIGN KEY (id_aprovador)
    REFERENCES aprovadores(id)
)

end
GO




