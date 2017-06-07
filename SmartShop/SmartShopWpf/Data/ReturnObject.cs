namespace SmartShopWpf.Data
{
    public class ReturnObject
    {
        public int Number { get; set; }
        public int IdOrder { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Count { get; set; }
        public int CountToReturn { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
    }
}