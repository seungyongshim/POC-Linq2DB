Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;
GO

Use AUMS;

CREATE TABLE [IpInfo] (
    [Id] int IDENTITY(1,1) NOT NULL ,
    [IpAddress] varchar(16)  NOT NULL ,
    [SendGrantId] int  NOT NULL ,
    CONSTRAINT [PK_IpInfo] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)

CREATE TABLE [SendGrant] (
    [Id] int IDENTITY(1,1) NOT NULL ,
    [Name] varchar(10)  NOT NULL ,
    CONSTRAINT [PK_SendGrant] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)

ALTER TABLE [IpInfo] WITH CHECK ADD CONSTRAINT [FK_IpInfo_SendGrantId] FOREIGN KEY([SendGrantId])
REFERENCES [SendGrant] ([Id])

ALTER TABLE [IpInfo] CHECK CONSTRAINT [FK_IpInfo_SendGrantId]

CREATE INDEX [idx_IpInfo_IpAddress]
ON [IpInfo] ([IpAddress])

GO

INSERT INTO [SendGrant] ([Name]) VALUES ("Mail")
INSERT INTO [SendGrant] ([Name]) VALUES ("SMS")

GO

CREATE USER MT FOR LOGIN MT
GRANT CREATE TABLE TO MT
GRANT ALTER, SELECT, INSERT ON SCHEMA::dbo TO MT

GO