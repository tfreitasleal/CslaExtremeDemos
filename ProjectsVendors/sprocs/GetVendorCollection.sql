/****** Object:  StoredProcedure [dbo].[GetVendorCollection] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVendorCollection]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetVendorCollection]
GO

CREATE PROCEDURE [dbo].[GetVendorCollection]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get VendorItem from table */
        SELECT
            [Vendors].[VendorId],
            [Vendors].[VendorName],
            [Vendors].[VendorContact],
            [Vendors].[VendorPhone],
            [Vendors].[VendorEmail],
            [Vendors].[IsPrimaryVendor],
            [Vendors].[LastUpdated]
        FROM [dbo].[Vendors]
            INNER JOIN [dbo].[Projects] ON [Vendors].[ProjectId] = [Projects].[ProjectId]
        WHERE
            [Projects].[ProjectId] = @ProjectId

    END
GO
