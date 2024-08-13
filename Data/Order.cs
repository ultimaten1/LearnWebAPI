namespace LearnWebAPI.Data
{
    public enum OrderStatus
    {
        Created = 0,
        Paid = 1,
        Completed = 2,
        Cancelled = -1
    }

    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverPhone { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
