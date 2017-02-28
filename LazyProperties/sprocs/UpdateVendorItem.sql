/****** Object:  StoredProcedure [dbo].[UpdateVendorItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateVendorItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateVendorItem]
GO

CREATE PROCEDURE [dbo].[UpdateVendorItem]
    @VendorId int,
    @VendorName varchar(50),
    @VendorContact varchar(50),
    @VendorPhone varchar(50),
    @VendorEmail varchar(50),
    @IsPrimaryVendor bit,
    @LastUpdated datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [VendorId] FROM [dbo].[Vendors]
            WHERE
                [VendorId] = @VendorId
        )
        BEGIN
            RAISERROR ('''dbo.VendorItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Vendors */
        UPDATE [dbo].[Vendors]
        SET
            [VendorName] = @VendorName,
            [VendorContact] = @VendorContact,
            [VendorPhone] = @VendorPhone,
            [VendorEmail] = @VendorEmail,
            [IsPrimaryVendor] = @IsPrimaryVendor,
            [LastUpdated] = @LastUpdated
        WHERE
            [VendorId] = @VendorId

    END
GO
