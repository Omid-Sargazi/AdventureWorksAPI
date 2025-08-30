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

    public class CreditCardPayment(IPaymentProcessor paymentProcessor) : Payment(paymentProcessor)
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine("در حال پردازش پرداخت با کارت اعتباری...");
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    public class PayPalPayment(IPaymentProcessor paymentProcessor) : Payment(paymentProcessor)
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine("در حال هدایت به صفحه PayPal...");
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    public class CryptoPayment(IPaymentProcessor paymentProcessor) : Payment(paymentProcessor)
    {
        public override void Pay(decimal amount)
        {
            Console.WriteLine("در حال تولید آدرس کیف پول دیجیتال...");
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    public class ClientPayment
    {
        public static void Run()
        {
            IPaymentProcessor bankProcessor = new BankAPIPaymentProcessor();
            IPaymentProcessor thirdPartyProcessor = new ThirdPartyPaymentProcessor();
            IPaymentProcessor testProcessor = new TestPaymentProcessor();

            Payment creditCardThirdPartyPayment = new CreditCardPayment(bankProcessor);
            creditCardThirdPartyPayment.Pay(12m);
        }
    }

}