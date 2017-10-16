/****** Object:  StoredProcedure [dbo].[AddProjectEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddProjectEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddProjectEdit]
GO

CREATE PROCEDURE [dbo].[AddProjectEdit]
    @ProjectId int OUTPUT,
    @ProjectName varchar(50),
    @StartDate datetime2,
    @DeliveryDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Projects */
        INSERT INTO [dbo].[Projects]
        (
            [ProjectName],
            [StartDate],
            [DeliveryDate]
        )
        VALUES
        (
            @ProjectName,
            @StartDate,
            @DeliveryDate
        )

        /* Return new primary key */
        SET @ProjectId = SCOPE_IDENTITY()

    END
GO
