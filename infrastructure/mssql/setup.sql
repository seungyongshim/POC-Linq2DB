Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;
GO

Use AUMS;

CREATE TABLE UserInfo
(
    "UserInfoId"  int        NOT NULL    IDENTITY, 
    "EmpNo"       char(5)    NULL, 
    "CmpCode"     char(2)    NULL, 
     PRIMARY KEY (UserInfoId)
)
GO

CREATE INDEX IX_UserInfo_1
    ON UserInfo(EmpNo, CmpCode)
GO

CREATE UNIQUE INDEX UQ_UserInfo_1
    ON UserInfo(EmpNo, CmpCode)
GO


-- IpInfo Table Create SQL
CREATE TABLE IpInfo
(
    "IpInfoId"      int            NOT NULL    IDENTITY, 
    "IpAddress"     varchar(16)    NULL, 
    "Grant"         smallint       NULL, 
    "UserInfoId"    int            NULL, 
    "PermissionYN"  bit            NULL, 
    "UseYN"         bit            NULL, 
    CONSTRAINT PK_IpInfo PRIMARY KEY (IpInfoId)
)
GO

CREATE INDEX IX_IpInfo_1
    ON IpInfo(IpAddress)
GO

CREATE UNIQUE INDEX UQ_IpInfo_1
    ON IpInfo(IpAddress)
GO

ALTER TABLE IpInfo
    ADD CONSTRAINT FK_IpInfo_UserInfoId_UserInfo_UserInfoId FOREIGN KEY (UserInfoId)
        REFERENCES UserInfo (UserInfoId)
GO

CREATE USER MT FOR LOGIN MT
GRANT CREATE TABLE TO MT
GRANT ALTER, SELECT, INSERT ON SCHEMA::dbo TO MT

GO
