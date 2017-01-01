/****** Object:  StoredProcedure [dbo].[AddDeptItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddDeptItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddDeptItem]
GO

CREATE PROCEDURE [dbo].[AddDeptItem]
    @DeptId smallint OUTPUT,
    @DeptName varchar(50),
    @IsActive bit
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Depts */
        INSERT INTO [dbo].[Depts]
        (
            [DeptName],
            [IsActive]
        )
        VALUES
        (
            @DeptName,
            @IsActive
        )

        /* Return new primary key */
        SET @DeptId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdateDeptItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDeptItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateDeptItem]
GO

CREATE PROCEDURE [dbo].[UpdateDeptItem]
    @DeptId smallint,
    @DeptName varchar(50),
    @IsActive bit
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DeptId] FROM [dbo].[Depts]
            WHERE
                [DeptId] = @DeptId
        )
        BEGIN
            RAISERROR ('''dbo.DeptItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Depts */
        UPDATE [dbo].[Depts]
        SET
            [DeptName] = @DeptName,
            [IsActive] = @IsActive
        WHERE
            [DeptId] = @DeptId

    END
GO

/****** Object:  StoredProcedure [dbo].[DeleteDeptItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteDeptItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteDeptItem]
GO

CREATE PROCEDURE [dbo].[DeleteDeptItem]
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DeptId] FROM [dbo].[Depts]
            WHERE
                [DeptId] = @DeptId
            /* Ignore filter option is on */
        )
        BEGIN
            RAISERROR ('''dbo.DeptItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DeptItem object as not active */
        UPDATE [dbo].[Depts]
        SET    [IsActive] = 'false'
        WHERE
            [dbo].[Depts].[DeptId] = @DeptId

    END
GO
