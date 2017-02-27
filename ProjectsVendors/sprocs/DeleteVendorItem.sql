/****** Object:  StoredProcedure [dbo].[DeleteVendorItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteVendorItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteVendorItem]
GO

CREATE PROCEDURE [dbo].[DeleteVendorItem]
    @VendorId int
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

        /* Delete VendorItem object from Vendors */
        DELETE
        FROM [dbo].[Vendors]
        WHERE
            [dbo].[Vendors].[VendorId] = @VendorId

    END
GO