namespace Task4.DAL.BufEnt
{
    public class BufSale
    {
        public int Id { get; set; }
        public string SaleDate { get; set; }
        public int ProductSet_Id { get; set; }
        public int ClientSet_Id { get; set; }
        public int ManagerSet_Id { get; set; }
    }
}