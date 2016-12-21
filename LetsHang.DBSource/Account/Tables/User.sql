CREATE TABLE [Account].[User] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)  NOT NULL,
    [LastName]     VARCHAR (50)  NOT NULL,
    [PublicName]   VARCHAR (50)  NOT NULL,
    [EmailAddress] VARCHAR (255) NOT NULL,
    [Password]     VARCHAR (15)  NOT NULL,
    [GenderId]     INT           NOT NULL,
    [StatusId]     INT           NOT NULL,
    [CreatedDate]  DATETIME      NOT NULL,
    [UpdatedDate]  DATETIME      NOT NULL,
    [UpdatedBy]    INT           NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

