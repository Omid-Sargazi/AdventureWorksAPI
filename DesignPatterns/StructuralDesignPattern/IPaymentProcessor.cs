namespace DesignPatterns.StructuralDesignPattern
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class BankAPIPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"پرداخت مبلغ {amount} تومان از طریق API بانک با موفقیت انجام شد.");
        }
    }

    public class ThirdPartyPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"پرداخت مبلغ {amount} تومان از طریق درگاه پرداخت شخص ثالث با موفقیت انجام شد.");
        }
    }

    public class TestPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"(TEST) پرداخت مبلغ {amount} تومان در محیط آزمایشی با موفقیت شبیه‌سازی شد.");
        }
    }

    public abstract class Payment
    {
        protected readonly IPaymentProcessor _paymentProcessor;
        public Payment(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public abstract void Pay(decimal amount);
    }
}