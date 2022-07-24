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
            //DESKTOP-O66ATKR\\SQLEXPRESS //possible username : DESKTOP-O66ATKR\\1
          string conString = "Server=MAHOLAPTOP\\SQLEXPRESS;Database=docrafERPDB;User Id=abcd;Password=abcd;";
        //  conString = "Server=DESKTOP-O66ATKR\\SQLEXPRESS;Database=docrafERPDB;Trusted_Connection=True;"; // for trusted now


            Connection = new SqlConnection(conString);

            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not connect to the Database server.");   
            }

        }

        #region AssetDataService:
        public List<Asset> GetAllAssets()
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[ASSET]";
            return Connection.Query<Asset>(query).ToList();
        }

        public Asset GetAsset(Asset assetID)
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
        public List<Supply> GetAllSupplies()
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[SUPPLY]";
            return Connection.Query<Supply>(query).ToList();
        }

        public Supply GetSupply(Supply supplyID)
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[SUPPLY] WHERE [SupplyID]=" + supplyID.SupplyID;
            return Connection.Query<Supply>(query).ToList().First();
        }

        public void DeleteSupply(Supply supply)
        {
            string query = @"DELETE FROM [dbo].[SUPPLY] WHERE SupplyID = " + supply.SupplyID;
            Connection.Execute(query);
        }

        public void InsertSupply(Supply supply)
        {        
            string query = @"INSERT INTO [dbo].[SUPPLY]([PurchaseRequestID],[DocumentsFolderPath],[ImagePath],[RemarksJson],[Name],[StockStatus],[Quantity],[LotNumber],[ExpirationDate],[PurchasedVendor],[PurchasePrice],[Barcode]) VALUES ( " + supply.PurchaseRequetID + ",'" + supply.DocumentsFolderPath + "','" + supply.ImagePath + "','" + supply.RemarksJson + "','" + supply.Name + "','" + supply.StockStatus + "','"+supply.Quantity+"','" + supply.LotNumber+ "','" + supply.ExpirationDate + "','" + supply.PurchasedVendor + "','" + supply.PurchasePrice + "','" + supply.Barcode + "')";
            Connection.Execute(query);
        }

        public void UpdateSupply(Supply supply)
        {
            string query = @"UPDATE [dbo].[SUPPLY] SET [PurchaseRequestID] = " + supply.PurchaseRequetID + " ,[DocumentsFolderPath] = '" + supply.DocumentsFolderPath + "',[ImagePath] = '" + supply.ImagePath + "',[RemarksJson] = '" + supply.RemarksJson + "' ,[Name] = '" + supply.Name + "',[Quantity] = '" + supply.Quantity + "',[StockStatus] = '" + supply.StockStatus + "' ,[LotNumber] = '" + supply.LotNumber + "' ,[ExpirationDate] = '" + supply.ExpirationDate + "',[PurchasedVendor] = '" + supply.PurchasedVendor + "',[PurchasePrice] = '" + supply.PurchasePrice + "',[Barcode] = '" + supply.Barcode + "' WHERE SupplyID = " + supply.SupplyID;
            Connection.Execute(query);
        }

        #endregion


        #region PurchaseRequestDataService:

        public List<PurchaseRequest> GetAllPurchaseRequests()
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[PurchaseRequest]";
            return Connection.Query<PurchaseRequest>(query).ToList();
        }

        public PurchaseRequest GetPurchaseRequest(PurchaseRequest purchaseRequestID)
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[PurchaseRequest] WHERE [PurchaseRequetID] = "+purchaseRequestID.PurchaseRequetID;
            return Connection.Query<PurchaseRequest>(query).ToList().FirstOrDefault();
        }

        public void DeletePurchaseRequest(PurchaseRequest purchaseRequestID)
        {
            string query = @"DELETE FROM [dbo].[PurchaseRequest] WHERE [PurchaseRequetID] = " + purchaseRequestID.PurchaseRequetID;
            Connection.Execute(query);
        }

        public void InsertPurchaseRequest(PurchaseRequest purchaseRequest)
        {
            string query = @"INSERT INTO [dbo].[PurchaseRequest]([ProductName],[IssuedDate],[IsApproved],[PRdocumentPath])VALUES('"+ purchaseRequest.ProductName+ "','"+ purchaseRequest.IssuedDate+ "','"+ purchaseRequest.IsApproved+ "','"+ purchaseRequest.PRdocumentPath+ "')";
            Connection.Execute(query);
        }

        public void UpdatePurchaseRequest(PurchaseRequest purchaseRequest)
        {
            string query = @"UPDATE [dbo].[PurchaseRequest] SET [ProductName] = '" + purchaseRequest.ProductName + "',[IssuedDate] = '" + purchaseRequest.IssuedDate + "',[IsApproved] = '" + purchaseRequest.IsApproved + "',[PRdocumentPath] = '" + purchaseRequest.PRdocumentPath + "'WHERE [PurchaseRequetID] = " + purchaseRequest.PurchaseRequetID;
            Connection.Execute(query);
        }

        #endregion

    }
}
