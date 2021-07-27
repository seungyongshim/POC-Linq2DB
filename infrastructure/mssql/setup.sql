Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;
GO

Use AUMS;


CREATE TABLE [IpInfo] (
    [IpInfoId] int IDENTITY(1,1) NOT NULL ,
    [IpAddress] varchar(16)  NOT NULL ,
    CONSTRAINT [PK_IpInfo] PRIMARY KEY CLUSTERED (
        [IpInfoId] ASC
    )
)

CREATE TABLE [MNInfoGrantSend] (
    [Id] int IDENTITY(1,1) NOT NULL ,
    [IpInfoId] int  NOT NULL ,
    [GrantSendId] int  NOT NULL ,
    CONSTRAINT [PK_MNInfoGrantSend] PRIMARY KEY CLUSTERED (
        [Id] ASC
    )
)

CREATE TABLE [GrantSend] (
    [GrantSendId] int IDENTITY(1,1) NOT NULL ,
    [Name] varchar(10)  NOT NULL ,
    CONSTRAINT [PK_GrantSend] PRIMARY KEY CLUSTERED (
        [GrantSendId] ASC
    )
)

ALTER TABLE [MNInfoGrantSend] WITH CHECK ADD CONSTRAINT [FK_MNInfoGrantSend_IpInfoId] FOREIGN KEY([IpInfoId])
REFERENCES [IpInfo] ([IpInfoId])

ALTER TABLE [MNInfoGrantSend] CHECK CONSTRAINT [FK_MNInfoGrantSend_IpInfoId]

ALTER TABLE [MNInfoGrantSend] WITH CHECK ADD CONSTRAINT [FK_MNInfoGrantSend_GrantSendId] FOREIGN KEY([GrantSendId])
REFERENCES [GrantSend] ([GrantSendId])

ALTER TABLE [MNInfoGrantSend] CHECK CONSTRAINT [FK_MNInfoGrantSend_GrantSendId]

CREATE INDEX [idx_IpInfo_IpAddress]
ON [IpInfo] ([IpAddress])

GO

INSERT INTO [GrantSend] ([Name]) VALUES ("Mail")
INSERT INTO [GrantSend] ([Name]) VALUES ("SMS")

GO

CREATE USER MT FOR LOGIN MT
GRANT CREATE TABLE TO MT
GRANT ALTER, SELECT, INSERT ON SCHEMA::dbo TO MT

GO