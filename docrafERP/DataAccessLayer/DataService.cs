using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using docrafERP.Models;
using System.Data.SqlClient;

namespace docrafERP.DataAccessLayer
{
    public class DataService
    {
        public SqlConnection Connection { get; set; }
        //server will be ip later server=192.168.1.39

        public DataService()
        {
            string conString = "Server=MAHOLAPTOP\\SQLEXPRESS;Database=docrafERPDB;User Id=abcd;Password=abcd;";

            Connection = new SqlConnection(conString);

            if (Connection.State== ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        #region AssetDataService:
        public List<Asset> GetAllAssets()
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[ASSET]";
            return Connection.Query<Asset>(query).ToList();
        }

        public Asset GeAsset(Asset assetID)
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[ASSET] WHERE [AssetID]=" + assetID.AssetID;
            return Connection.Query<Asset>(query).ToList().First();
        }

        public void InsertAsset(Asset asset)
        {
           // string query = @"INSERT INTO [dbo].[ASSET]([PurchaseRequestID],[DocumentsFolderPath],[ImagePath],[RemarksJson],[Device],[OwnerOrLocation],[Status],[SerialNumber],[DateReceived],[PurchasedVendor],[PurchasePrice],[Barcode]) VALUES ( @PurchaseRequestID,@DocumentsFolderPath,@ImagePath,@RemarksJson,@Device,@OwnerOrLocation,@Status,@SerialNumber,@DateReceived,@PurchasedVendor,@PurchasePrice,@Barcode)";
           string query = @"INSERT INTO [dbo].[ASSET]([PurchaseRequestID],[DocumentsFolderPath],[ImagePath],[RemarksJson],[Device],[OwnerOrLocation],[Status],[SerialNumber],[DateReceived],[PurchasedVendor],[PurchasePrice],[Barcode]) VALUES ( "+asset.PurchaseRequetID+",'"+asset.DocumentsFolderPath+"','"+asset.ImagePath+ "','" + asset.RemarksJson + "','" + asset.Device + "','" + asset.OwnerOrLocation + "','" + asset.Status + "','" + asset.SerialNumber + "','" + asset.DateReceived + "','" + asset.PurchasedVendor + "','" + asset.PurchasePrice + "','" + asset.Barcode + "')";
           Connection.Execute(query);
        }

        public void DeleteAsset(Asset asset)
        {
            string query = @"DELETE FROM [dbo].[ASSET] WHERE AssetID = "+asset.AssetID;
            Connection.Execute(query);
        }

        public void UpdateAsset(Asset asset)
        {
            string query = @"UPDATE [dbo].[ASSET] SET [PurchaseRequestID] = "+ asset.PurchaseRequetID+ " ,[DocumentsFolderPath] = '" + asset.DocumentsFolderPath + "',[ImagePath] = '" + asset.ImagePath + "',[RemarksJson] = '" + asset.RemarksJson + "' ,[Device] = '" + asset.Device + "',[OwnerOrLocation] = '" + asset.OwnerOrLocation + "',[Status] = '" + asset.Status + "' ,[SerialNumber] = '" + asset.SerialNumber + "' ,[DateReceived] = '" + asset.DateReceived + "',[PurchasedVendor] = '" + asset.PurchasedVendor + "',[PurchasePrice] = '" + asset.PurchasePrice + "',[Barcode] = '" + asset.Barcode + "' WHERE AssetID = " + asset.AssetID;
            Connection.Execute(query);
        }
        #endregion

        #region SupplyDataService:

        #endregion


        #region PurchaseRequestDataService:

        #endregion

    }
}
