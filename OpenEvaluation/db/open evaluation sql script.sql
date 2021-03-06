USE [students]
GO
/****** Object:  Table [dbo].[tblTeam]    Script Date: 04/11/2020 14:00:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTeam](
	[id] [int] NOT NULL,
	[team] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_tblTeam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudentsForExercise]    Script Date: 04/11/2020 14:00:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudentsForExercise](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[birthday] [datetime] NOT NULL,
	[logintimes] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[truename] [nvarchar](50) NOT NULL,
	[pwd] [nvarchar](max) NOT NULL,
	[gender] [bit] NOT NULL,
	[deptID] [int] NOT NULL,
	[lastLoginTime] [datetime] NOT NULL,
	[dtedate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblStudentsForExercise] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHomework]    Script Date: 04/11/2020 14:00:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHomework](
	[id] [int] NOT NULL,
	[homeWork] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tblHomework] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEvaluation]    Script Date: 04/11/2020 14:00:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEvaluation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[homeworkID] [int] NOT NULL,
	[studentID] [nvarchar](50) NOT NULL,
	[ScoreItemID] [int] NOT NULL,
	[myScore1] [float] NOT NULL,
	[myScore2] [float] NOT NULL,
	[myScore3] [float] NOT NULL,
	[myScore4] [float] NOT NULL,
	[myScore5] [float] NOT NULL,
	[teamID] [int] NOT NULL,
	[DTEDATE] [datetime] NOT NULL,
 CONSTRAINT [PK_tblEvaluation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_tblEvaluation_homeworkID]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblEvaluation] ADD  CONSTRAINT [DF_tblEvaluation_homeworkID]  DEFAULT ((0)) FOR [homeworkID]
GO
/****** Object:  Default [DF_tblEvaluation_ScoreItemID]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblEvaluation] ADD  CONSTRAINT [DF_tblEvaluation_ScoreItemID]  DEFAULT ((0)) FOR [ScoreItemID]
GO
/****** Object:  Default [DF_tblEvaluation_myScore5]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblEvaluation] ADD  CONSTRAINT [DF_tblEvaluation_myScore5]  DEFAULT ((0)) FOR [myScore5]
GO
/****** Object:  Default [DF_tblEvaluation_DTEDATE]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblEvaluation] ADD  CONSTRAINT [DF_tblEvaluation_DTEDATE]  DEFAULT (getdate()) FOR [DTEDATE]
GO
/****** Object:  Default [DF_tblStudentsForExercise_truename]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblStudentsForExercise] ADD  CONSTRAINT [DF_tblStudentsForExercise_truename]  DEFAULT ('无名氏') FOR [truename]
GO
/****** Object:  Default [DF_tblStudentsForExercise_deptID]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblStudentsForExercise] ADD  CONSTRAINT [DF_tblStudentsForExercise_deptID]  DEFAULT ((0)) FOR [deptID]
GO
/****** Object:  Default [DF_tblStudentsForExercise_dtedate]    Script Date: 04/11/2020 14:00:25 ******/
ALTER TABLE [dbo].[tblStudentsForExercise] ADD  CONSTRAINT [DF_tblStudentsForExercise_dtedate]  DEFAULT (getdate()) FOR [dtedate]
GO
