namespace CKK.Online.Models
{
    public class CheckoutConfirmation
    {
        public string Confirmation { get; }
        public string OrderNumber { get; }
        public CheckoutConfirmation(string orderNumber)
        {
            OrderNumber = orderNumber;
            Confirmation = $"Thank you for your purchase.{Environment.NewLine}Your order number is: {OrderNumber}";
        }
    }
}
