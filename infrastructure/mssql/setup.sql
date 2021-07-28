Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;
GO

Use AUMS;

CREATE TABLE [IpInfo] (
    [IpInfoId] int IDENTITY(1,1) NOT NULL ,
    [IpAddress] varchar(16)  NOT NULL ,
    [GrantSend] smallint NOT NULL ,
    CONSTRAINT [PK_IpInfo] PRIMARY KEY CLUSTERED (
        [IpInfoId] ASC
    )
)

CREATE UNIQUE INDEX [idx_IpInfo_IpAddress]
ON [IpInfo] ([IpAddress])

GO

CREATE USER MT FOR LOGIN MT
GRANT CREATE TABLE TO MT
GRANT ALTER, SELECT, INSERT ON SCHEMA::dbo TO MT

GO