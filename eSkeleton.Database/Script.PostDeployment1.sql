
/*Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------*/

/*
SET DATEFORMAT dmy

DELETE FROM MENUS;
GO

SET IDENTITY_INSERT [dbo].[Menus] ON
INSERT INTO [dbo].[Menus] ([Id], [Name], [Description], [Label], [IsMaster], [Order], [Icon], [IconColor], [OnClick], [IsSecurity], [IsSystem], [Menu_Menu]) VALUES (3, N'Security', N'Gestão de segurança do sistema', N'Segurança', 1, 4, N'fa fa-lock', N'clredlight', NULL, 1, 0, NULL)
INSERT INTO [dbo].[Menus] ([Id], [Name], [Description], [Label], [IsMaster], [Order], [Icon], [IconColor], [OnClick], [IsSecurity], [IsSystem], [Menu_Menu]) VALUES (6, N'Users', N'Cadastro de usuários', N'Usuários', 0, 1, N'fa fa-user', N'clredlight', N'showUserDetailsBrowse', 1, 0, 3)
INSERT INTO [dbo].[Menus] ([Id], [Name], [Description], [Label], [IsMaster], [Order], [Icon], [IconColor], [OnClick], [IsSecurity], [IsSystem], [Menu_Menu]) VALUES (7, N'UserGroups', N'Cadastro de grupos de usuários', N'Grupos', 0, 2, N'fa fa-group', N'clredlight', N'showRoleDetailsBrowse', 1, 0, 3)
INSERT INTO [dbo].[Menus] ([Id], [Name], [Description], [Label], [IsMaster], [Order], [Icon], [IconColor], [OnClick], [IsSecurity], [IsSystem], [Menu_Menu]) VALUES (9, N'Menus', N'Cadastro de menus', N'Menus', 0, 4, N'fa fa-code', N'clredlight', N'showMenusBrowse', 0, 1, 3)
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
*/
