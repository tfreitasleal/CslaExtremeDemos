/****** Object:  StoredProcedure [dbo].[AddVendorItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddVendorItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddVendorItem]
GO

CREATE PROCEDURE [dbo].[AddVendorItem]
    @VendorId int OUTPUT,
    @ProjectId int,
    @VendorName varchar(50),
    @VendorContact varchar(50),
    @VendorPhone varchar(50),
    @VendorEmail varchar(50),
    @IsPrimaryVendor bit,
    @LastUpdated datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Vendors */
        INSERT INTO [dbo].[Vendors]
        (
            [ProjectId],
            [VendorName],
            [VendorContact],
            [VendorPhone],
            [VendorEmail],
            [IsPrimaryVendor],
            [LastUpdated]
        )
        VALUES
        (
            @ProjectId,
            @VendorName,
            @VendorContact,
            @VendorPhone,
            @VendorEmail,
            @IsPrimaryVendor,
            @LastUpdated
        )

        /* Return new primary key */
        SET @VendorId = SCOPE_IDENTITY()

    END
GO
