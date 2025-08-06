namespace AdventureWorks.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }      // Composite Key (part 2)
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}