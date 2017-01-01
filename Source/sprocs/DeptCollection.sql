/****** Object:  StoredProcedure [dbo].[GetDeptCollection] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeptCollection]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetDeptCollection]
GO

CREATE PROCEDURE [dbo].[GetDeptCollection]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DeptItem from table */
        SELECT
            [Depts].[DeptId],
            [Depts].[DeptName],
            [Depts].[IsActive]
        FROM [dbo].[Depts]

    END
GO

