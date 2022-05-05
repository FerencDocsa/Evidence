USE [Evidence]

GO
INSERT [dbo].[Positions] ([Name], [Cost]) VALUES (N'Backend Developer', 1000)
INSERT [dbo].[Positions] ([Name], [Cost]) VALUES (N'Frontend Developer', 1100)
INSERT [dbo].[Positions] ([Name], [Cost]) VALUES (N'Fullstack Developer', 1200)

GO

INSERT [dbo].[Employees] ([Name], [Position]) VALUES (N'Jan', 1)
INSERT [dbo].[Employees] ([Name], [Position]) VALUES (N'Radek', 2)
INSERT [dbo].[Employees] ([Name], [Position]) VALUES (N'Pavel', 3)

GO

INSERT [dbo].[Projects] ([Name]) VALUES (N'API Pro Banku')
INSERT [dbo].[Projects] ([Name]) VALUES (N'Vzhled pro Pojistovny')
INSERT [dbo].[Projects] ([Name]) VALUES (N'Web Aplikace pro Elektrarnu')

GO

INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (1, 1, 3000, CAST(N'2022-05-04T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (2, 2, 2200, CAST(N'2022-05-04T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (3, 3, 3600, CAST(N'2022-05-04T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (1, 1, 3000, CAST(N'2022-05-05T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (2, 2, 5500, CAST(N'2022-05-05T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Actions] ([Employee], [Project], [Cost], [ActionDate], [SpentTime]) VALUES (3, 3, 4800, CAST(N'2022-05-05T00:00:00.000' AS DateTime), 4)
