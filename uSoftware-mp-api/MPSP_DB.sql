BEGIN TRANSACTION scriptMPSP

CREATE DATABASE mpsp_db;
GO

USE mpsp_db;
GO

--######################################################################################
----------------------------------------------------------------------------[ Usuarios ]###
--######################################################################################

CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Login] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Ativo] [Bit] DEFAULT 1 NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_UsuarioID] PRIMARY KEY CLUSTERED (ID)
) 
GO


--######################################################################################
----------------------------------------------------------------------------[ Cidadaos ]###
--######################################################################################

CREATE TABLE [dbo].[Cidadaos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](50) NOT NULL,
	[RG] [varchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Celular] [varchar](50) NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Complemento] [varchar](100) NULL,
	[UsuarioID] INT NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_CidadaoID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Cidadaos]  WITH CHECK ADD  CONSTRAINT [FK_Cidadaos_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([ID])
GO

--######################################################################################
----------------------------------------------------------------------------[ Promotores ]###
--######################################################################################

CREATE TABLE [dbo].[Promotores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[UsuarioID] INT NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_PromotorID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Promotores]  WITH CHECK ADD  CONSTRAINT [FK_Promotores_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([ID])
GO

--######################################################################################
----------------------------------------------------------------------------[ FaixasAtendimento ]###
--######################################################################################

CREATE TABLE [dbo].[FaixasAtendimento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HorarioInicio] [varchar](50) NOT NULL,
	[HorarioFim] [varchar](50) NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_FaixaAtendimentoID] PRIMARY KEY CLUSTERED (ID)
) 
GO

--######################################################################################
----------------------------------------------------------------------------[ AreasAtuacoes ]###
--######################################################################################

CREATE TABLE [dbo].[AreasAtuacoes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](MAX) NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_AreaAtuacaoID] PRIMARY KEY CLUSTERED (ID)
) 
GO

--######################################################################################
----------------------------------------------------------------------------[ Promotorias ]###
--######################################################################################

CREATE TABLE [dbo].[Promotorias](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[FaixaAtendimentoID] INT NOT NULL,
	[AreaAtuacaoID] INT NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_PromotoriaID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Promotorias]  WITH CHECK ADD  CONSTRAINT [FK_Promotorias_FaixasAtendimento] FOREIGN KEY([FaixaAtendimentoID])
REFERENCES [dbo].[FaixasAtendimento] ([ID])
GO

ALTER TABLE [dbo].[Promotorias]  WITH CHECK ADD  CONSTRAINT [FK_Promotorias_AreasAtuacoes] FOREIGN KEY([AreaAtuacaoID])
REFERENCES [dbo].[AreasAtuacoes] ([ID])
GO


--######################################################################################
----------------------------------------------------------------------------[ Ouvidoria ]###
--######################################################################################

CREATE TABLE [dbo].[Ouvidoria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Feedback] [varchar](MAX) NOT NULL,
	[PromotoriaID] INT NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_OuvidoriaID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Ouvidoria]  WITH CHECK ADD  CONSTRAINT [FK_Ouvidoria_Promotorias] FOREIGN KEY([PromotoriaID])
REFERENCES [dbo].[Promotorias] ([ID])
GO


--######################################################################################
----------------------------------------------------------------------------[ Atendimentos ]###
--######################################################################################

CREATE TABLE [dbo].[Atendimentos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataAgendamento] [datetime] NOT NULL,
	[CidadaoID] INT NOT NULL,
	[PromotoriaID] INT NOT NULL,
	[PromotorID] INT NOT NULL,
	[AreaAtuacaoID] INT NOT NULL,
	[Protocolo] [varchar](100) NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[Etapa] [varchar](100) NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_AtendimentoID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Cidadaos] FOREIGN KEY([CidadaoID])
REFERENCES [dbo].[Cidadaos] ([ID])
GO

ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Promotorias] FOREIGN KEY([PromotoriaID])
REFERENCES [dbo].[Promotorias] ([ID])
GO

ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_Promotores] FOREIGN KEY([PromotorID])
REFERENCES [dbo].[Promotores] ([ID])
GO

ALTER TABLE [dbo].[Atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_Atendimentos_AreasAtuacoes] FOREIGN KEY([AreaAtuacaoID])
REFERENCES [dbo].[AreasAtuacoes] ([ID])
GO

--######################################################################################
----------------------------------------------------------------------------[ Uploads ]###
--######################################################################################

CREATE TABLE [dbo].[Uploads](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CidadaoID] INT NOT NULL,
	[AtendimentoID] INT NOT NULL,
	[URL] [varchar](MAX) NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_UploadID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Uploads]  WITH CHECK ADD  CONSTRAINT [FK_Uploads_Cidadaos] FOREIGN KEY([CidadaoID])
REFERENCES [dbo].[Cidadaos] ([ID])
GO

ALTER TABLE [dbo].[Uploads]  WITH CHECK ADD  CONSTRAINT [FK_Uploads_Atendimentos] FOREIGN KEY([AtendimentoID])
REFERENCES [dbo].[Atendimentos] ([ID])
GO

--######################################################################################
----------------------------------------------------------------------------[ Opinioes ]###
--######################################################################################

CREATE TABLE [dbo].[Opnioes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CidadaoID] INT NOT NULL,
	[PromotoriaID] INT NOT NULL,
	[Descricao] [varchar](MAX) NOT NULL,
	[CriadoEm] [datetime] NOT NULL DEFAULT GETDATE(),
	[RemovidoEm] [datetime] NULL,
	CONSTRAINT [PK_OpniaoID] PRIMARY KEY CLUSTERED (ID)
) 
GO

ALTER TABLE [dbo].[Opnioes]  WITH CHECK ADD  CONSTRAINT [FK_Opnioes_Cidadaos] FOREIGN KEY([CidadaoID])
REFERENCES [dbo].[Cidadaos] ([ID])
GO

ALTER TABLE [dbo].[Opnioes]  WITH CHECK ADD  CONSTRAINT [FK_Opnioes_Promotorias] FOREIGN KEY([PromotoriaID])
REFERENCES [dbo].[Promotorias] ([ID])
GO


--COMMIT TRANSACTION scriptMPSP
--ROLLBACK TRANSACTION scriptMPSP