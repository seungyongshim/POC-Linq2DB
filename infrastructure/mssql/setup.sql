Create Login MT with password = 'q1w2e3r4t5Y^U&I*O(P)';
Create DATABASE AUMS;
GO

Use AUMS;
GO

-- 테이블 순서는 관계를 고려하여 한 번에 실행해도 에러가 발생하지 않게 정렬되었습니다.

-- UserInfos Table Create SQL
CREATE TABLE UserInfos
(
    UserInfoId  int        NOT NULL    IDENTITY, 
    EmpNo       char(5)    NULL, 
    CmpCode     char(2)    NULL, 
    CONSTRAINT PK_UserInfo PRIMARY KEY (UserInfoId)
)
GO

CREATE INDEX IX_UserInfo_1
    ON UserInfos(EmpNo, CmpCode)
GO

CREATE UNIQUE INDEX UQ_UserInfo_1
    ON UserInfos(EmpNo, CmpCode)
GO


-- IpInfos Table Create SQL
CREATE TABLE IpInfos
(
    IpInfoId      int            NOT NULL    IDENTITY, 
    IpAddress     varchar(16)    NULL, 
    GrantSend     smallint       NULL, 
    UserInfoId    int            NULL, 
    PermissionYN  bit            NULL, 
    UseYN         bit            NULL, 
    CONSTRAINT PK_IpInfo PRIMARY KEY (IpInfoId)
)
GO

CREATE INDEX IX_IpInfo_1
    ON IpInfos(IpAddress)
GO

CREATE UNIQUE INDEX UQ_IpInfo_1
    ON IpInfos(IpAddress)
GO

ALTER TABLE IpInfos
    ADD CONSTRAINT FK_IpInfos_UserInfoId_UserInfos_UserInfoId FOREIGN KEY (UserInfoId)
        REFERENCES UserInfos (UserInfoId)
GO





-- 계정 생성

CREATE USER MT FOR LOGIN MT
GRANT CREATE TABLE TO MT
GRANT ALTER, SELECT, INSERT, UPDATE  ON SCHEMA::dbo TO MT

GO
