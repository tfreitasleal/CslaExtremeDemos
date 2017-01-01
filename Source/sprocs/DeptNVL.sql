/****** Object:  StoredProcedure [dbo].[GetDeptNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeptNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetDeptNVL]
GO

CREATE PROCEDURE [dbo].[GetDeptNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DeptNVL from table */
        SELECT
            [Depts].[DeptId],
            [Depts].[DeptName]
        FROM [dbo].[Depts]
        WHERE
            [Depts].[IsActive] = 'true'

    END
GO

