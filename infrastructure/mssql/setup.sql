Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;

GO

Use AUMS;  
CREATE USER MT FOR LOGIN MT;
GRANT CREATE TABLE TO MT;
GRANT ALTER, SELECT, INSERT ON SCHEMA::dbo TO MT;

GO


SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [IpInfo] (
    [Id] int  NOT NULL ,
    [IpAddress] varchar(16)  NOT NULL ,
    [SendGrantId] int  NOT NULL ,
    CONSTRAINT [PK_IpInfo] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)

CREATE TABLE [SendGrant] (
    [Id] int  NOT NULL ,
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

COMMIT TRANSACTION QUICKDBD

GO
