namespace DMS.Core.DTO.SalesOrder
{
    public class CancelledOrderDto
    {
        public string OrderCode { get; set; }
        public string ReasonToCancel { get; set; }
        public string CancelledByID { get; set; }
    }
}
