Create Database [TesteCompetenciaDDA]
GO

Use [TesteCompetenciaDDA]
GO

Create Table TipoLancamentoFinanceiro(
	Id int identity(1,1),
	Descricao varchar(50) not null,
	Constraint PK_TipoLancamentoFinanceiro primary key(Id)
)

Create Table LancamentoFinanceiro(
	Id int identity(1,1),
	DataHora Datetime not null,
	Valor money not null,
	TipoId int not null,
	[Status] bit not null,
	Constraint PK_LancamentoFinanceiro primary key(Id),
	Constraint FK_LancamentoFinanceiro_TipoLancamentoFinanceiro Foreign Key(TipoId) references TipoLancamentoFinanceiro(Id)
)

Create Table BalancoDia(
	Id int identity(1,1),
	[Data] Date not null,
	ValorCredito money not null,
	ValorDebito money not null,
	ValorTotal money not null,
	Constraint Pk_BalancoDia primary key(Id)
)
GO