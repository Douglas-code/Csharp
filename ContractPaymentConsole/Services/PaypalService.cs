namespace ContractPaymentConsole.Services
{
    public class PaypalService : IOnlinePaymentService
    {
        private const double MonthlyInterest = 0.01;
        private const double PercentageFee = 0.02;

        public double PaymentFee(double amount)
        {
            return amount * PercentageFee;
        }
        public double Interest(double amount, int months)
        {
            return amount * months * MonthlyInterest;
        }
    }
}