USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE NAME='GuildCars')
DROP DATABASE GuildCars
GO

CREATE DATABASE GuildCars
GO

USE GuildCars
GO