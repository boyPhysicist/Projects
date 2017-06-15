namespace Task4_LastVersion_
{
    public class SaleData
    {
        public string ManagerName { get; }
        public string ClientName { get; }
        public string ProductName { get; }
        public string ProductCost { get; }
        public string Date { get; }


        public SaleData(string managerName, string date, string clientName, string productName, string productCost)
        {
            ManagerName = managerName;
            Date = date;
            ClientName = clientName;
            ProductName = productName;
            ProductCost = productCost;
        }
    }
}