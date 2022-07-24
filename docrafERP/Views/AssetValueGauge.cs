namespace docrafERP.Views
{
    public class AssetValueGauge
    {
        public int ValueNumber { get; set; }
        public string ValueDisplay { get; set; }

        public AssetValueGauge(int value , string displayText)
        {
            this.ValueNumber = 98;
            this.ValueDisplay = "Net Value";
            ValueNumber = value;
            ValueDisplay = displayText;

        }
    }
}