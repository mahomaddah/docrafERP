namespace docrafERP.Models
{
    public class AssetMaintenance
    {
        public int AssetID { get; set; }
        public string Title { get; set; }
        public string MaintenanceStatus { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string MaintenanceBy { get; set; }
        public string Cost { get; set; }
        public string Frequency { get; set; }

        public AssetMaintenance()
        {
            MaintenanceStatus = "Not Active";
        }

    }
}