/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.1.91
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : PC-202103201839\MSSQLSERVER1:1433
 Source Catalog        : BMFV2Base
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 16/10/2024 15:28:28
*/


-- ----------------------------
-- Table structure for tb_car_info
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_car_info]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_car_info]
GO

CREATE TABLE [dbo].[tb_car_info] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [car_no] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [name] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [phone] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [bz] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_car_info] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_CarRecord
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_CarRecord]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_CarRecord]
GO

CREATE TABLE [dbo].[tb_CarRecord] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [car_no] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [add_time] datetime  NULL,
  [out_type] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [car_color] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [platform_status] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [car_image] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [front_image] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [upload_status] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChannelPort] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [upload_number] int  NULL,
  [serialNum] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [gateSignal] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fuelType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [emissionStandard] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [cargoName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [cargoWeight] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_CarRecord] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_Channel
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Channel]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_Channel]
GO

CREATE TABLE [dbo].[tb_Channel] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [ChannelName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChannelType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChannelPort] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_Channel] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_cmd
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_cmd]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_cmd]
GO

CREATE TABLE [dbo].[tb_cmd] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [enterpriseId] int  NULL,
  [lsh] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [doorCode] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [cmdType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [cmdStatus] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [add_time] datetime  NULL,
  [goodsId] int  NULL
)
GO

ALTER TABLE [dbo].[tb_cmd] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_Device
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_Device]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_Device]
GO

CREATE TABLE [dbo].[tb_Device] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [CameraName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChannelNo] int  NULL,
  [CameraBrand] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CameraIP] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [OpeningMethod] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CameraType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [motherboardType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [deviceId] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SnapId] int  NOT NULL,
  [IOIP] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [bigScreenId] int  NOT NULL,
  [bjip] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_Device] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_enterprise
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_enterprise]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_enterprise]
GO

CREATE TABLE [dbo].[tb_enterprise] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [organ] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [username] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [password] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [companySecretCode] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [platformId] int  NULL,
  [remoteType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [remoteDoccode] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [remotePass] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [desc] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [add_time] datetime  NULL
)
GO

ALTER TABLE [dbo].[tb_enterprise] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_exceptional
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_exceptional]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_exceptional]
GO

CREATE TABLE [dbo].[tb_exceptional] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [CameraId] int  NULL,
  [add_time] datetime2(0)  NULL,
  [OpeningType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SnapImagePath1] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SnapImagePath2] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SnapImagePath3] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SnapVideoPath] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_exceptional] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_ImageDetaile
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_ImageDetaile]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_ImageDetaile]
GO

CREATE TABLE [dbo].[tb_ImageDetaile] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [ImagePath] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [detaileID] int  NULL
)
GO

ALTER TABLE [dbo].[tb_ImageDetaile] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_kayValue
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_kayValue]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_kayValue]
GO

CREATE TABLE [dbo].[tb_kayValue] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [keyCode] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [keyValue] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [keyType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [platformId] int  NULL
)
GO

ALTER TABLE [dbo].[tb_kayValue] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_large_screen
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_large_screen]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_large_screen]
GO

CREATE TABLE [dbo].[tb_large_screen] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [IP] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [largeName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [largeWidth] float(53)  NULL,
  [largeHeight] float(53)  NULL
)
GO

ALTER TABLE [dbo].[tb_large_screen] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_large_screen_detaile
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_large_screen_detaile]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_large_screen_detaile]
GO

CREATE TABLE [dbo].[tb_large_screen_detaile] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [x] int  NULL,
  [y] int  NULL,
  [xstx] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [yxsd] int  NULL,
  [tlsj] int  NULL,
  [customText] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [largeId] int  NULL,
  [Width] int  NULL,
  [Height] int  NULL
)
GO

ALTER TABLE [dbo].[tb_large_screen_detaile] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_nonRoad
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_nonRoad]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_nonRoad]
GO

CREATE TABLE [dbo].[tb_nonRoad] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [hbdjh] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [jxscrq] datetime  NULL,
  [car_no] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [pfjd] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ryxl] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [jxzl] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [pin] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [jxxh] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fdjxh] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fdjcs] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fdjbh] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [shr] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_nonRoad] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_nonRoadRecord
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_nonRoadRecord]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_nonRoadRecord]
GO

CREATE TABLE [dbo].[tb_nonRoadRecord] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [nonRoadId] int  NULL,
  [addtime] datetime2(0)  NULL,
  [outType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_nonRoadRecord] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_TempCarInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_TempCarInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_TempCarInfo]
GO

CREATE TABLE [dbo].[tb_TempCarInfo] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [car_no] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [licenseColor] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [standard] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [passMessage] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [isPass] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [add_time] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fuelType] varchar(255) COLLATE Chinese_PRC_CI_AS DEFAULT '' NULL
)
GO

ALTER TABLE [dbo].[tb_TempCarInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_vehicleInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_vehicleInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_vehicleInfo]
GO

CREATE TABLE [dbo].[tb_vehicleInfo] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [vehicleNo] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [licenseColor] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [vehicleType] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [vin] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [useCharacter] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [engineNo] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [onwer] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [address] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [model] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [registerDate] datetime  NULL,
  [issueDate] datetime  NULL,
  [emissionStandard] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [drivingLicenseImg] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [drivingLicenseImgAbsolute] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [drivingLicenseImg2] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [drivingLicenseImg2Absolute] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [xzdw] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [fueltype] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [enterpriseId] int  NULL
)
GO

ALTER TABLE [dbo].[tb_vehicleInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for tb_videotape
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_videotape]') AND type IN ('U'))
	DROP TABLE [dbo].[tb_videotape]
GO

CREATE TABLE [dbo].[tb_videotape] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [doccode] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [pass] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChannelID] int  NULL,
  [IP] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [snapNumber] int  NULL,
  [type] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tb_videotape] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for tb_car_info
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_car_info]', RESEED, 1010)
GO


-- ----------------------------
-- Primary Key structure for table tb_car_info
-- ----------------------------
ALTER TABLE [dbo].[tb_car_info] ADD CONSTRAINT [PK_tb_car_info_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_CarRecord
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_CarRecord]', RESEED, 1205)
GO


-- ----------------------------
-- Primary Key structure for table tb_CarRecord
-- ----------------------------
ALTER TABLE [dbo].[tb_CarRecord] ADD CONSTRAINT [PK__tb_CarRe__3213E83F464F18BD] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_Channel
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_Channel]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table tb_Channel
-- ----------------------------
ALTER TABLE [dbo].[tb_Channel] ADD CONSTRAINT [PK__tb_Chann__3213E83F0B1E2204] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_cmd
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_cmd]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tb_cmd
-- ----------------------------
ALTER TABLE [dbo].[tb_cmd] ADD CONSTRAINT [PK_tb_cmd_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_Device
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_Device]', RESEED, 20)
GO


-- ----------------------------
-- Primary Key structure for table tb_Device
-- ----------------------------
ALTER TABLE [dbo].[tb_Device] ADD CONSTRAINT [PK__tb_Devic__3213E83F84EA3C4A] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_enterprise
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_enterprise]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tb_enterprise
-- ----------------------------
ALTER TABLE [dbo].[tb_enterprise] ADD CONSTRAINT [PK_tb_enterprise_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_exceptional
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_exceptional]', RESEED, 109)
GO


-- ----------------------------
-- Primary Key structure for table tb_exceptional
-- ----------------------------
ALTER TABLE [dbo].[tb_exceptional] ADD CONSTRAINT [PK__tb_excep__3213E83FC2FC828F] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_ImageDetaile
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_ImageDetaile]', RESEED, 14)
GO


-- ----------------------------
-- Primary Key structure for table tb_ImageDetaile
-- ----------------------------
ALTER TABLE [dbo].[tb_ImageDetaile] ADD CONSTRAINT [PK__ImageDet__3213E83FDBB6A37A] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_kayValue
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_kayValue]', RESEED, 621)
GO


-- ----------------------------
-- Primary Key structure for table tb_kayValue
-- ----------------------------
ALTER TABLE [dbo].[tb_kayValue] ADD CONSTRAINT [PK_tb_kayValue_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_large_screen
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_large_screen]', RESEED, 6)
GO


-- ----------------------------
-- Primary Key structure for table tb_large_screen
-- ----------------------------
ALTER TABLE [dbo].[tb_large_screen] ADD CONSTRAINT [PK__tb_large__3213E83FE609B7E7] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_large_screen_detaile
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_large_screen_detaile]', RESEED, 20)
GO


-- ----------------------------
-- Primary Key structure for table tb_large_screen_detaile
-- ----------------------------
ALTER TABLE [dbo].[tb_large_screen_detaile] ADD CONSTRAINT [PK__tb_large__3213E83FEBDB859B] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_nonRoad
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_nonRoad]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table tb_nonRoad
-- ----------------------------
ALTER TABLE [dbo].[tb_nonRoad] ADD CONSTRAINT [PK_tb_nonRoad_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_nonRoadRecord
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_nonRoadRecord]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table tb_nonRoadRecord
-- ----------------------------
ALTER TABLE [dbo].[tb_nonRoadRecord] ADD CONSTRAINT [PK__tb_nonRo__3213E83F83EBC20D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_TempCarInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_TempCarInfo]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table tb_TempCarInfo
-- ----------------------------
ALTER TABLE [dbo].[tb_TempCarInfo] ADD CONSTRAINT [PK__tb_TempC__3213E83F9D43377E] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_vehicleInfo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_vehicleInfo]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table tb_vehicleInfo
-- ----------------------------
ALTER TABLE [dbo].[tb_vehicleInfo] ADD CONSTRAINT [PK_tb_vehicleInfo_id] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tb_videotape
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tb_videotape]', RESEED, 2)
GO


-- ----------------------------
-- Primary Key structure for table tb_videotape
-- ----------------------------
ALTER TABLE [dbo].[tb_videotape] ADD CONSTRAINT [PK__tb_video__3213E83FB79346E0] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

