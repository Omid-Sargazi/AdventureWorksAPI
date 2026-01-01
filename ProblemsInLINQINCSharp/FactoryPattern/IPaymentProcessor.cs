namespace ProblemsInLINQINCSharp.FactoryPattern
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount, string currency);
        string GetPaymentMethod();
        string GetTransactionId();
    }

    // Concrete Products
    public class CreditCardPayment : IPaymentProcessor
    {
        private string _cardNumber;
        private string _cvv;
        private string _expiryDate;

        public CreditCardPayment(string cardNumber, string cvv, string expiryDate)
        {
            _cardNumber = cardNumber;
            _cvv = cvv;
            _expiryDate = expiryDate;
        }

        public bool ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine($"Processing Credit Card Payment:");
            Console.WriteLine($"  Amount: {amount} {currency}");
            Console.WriteLine($"  Card: ****{_cardNumber.Substring(_cardNumber.Length - 4)}");
            Console.WriteLine($"  Expiry: {_expiryDate}");
            
            // Simulate payment processing
            bool isSuccessful = SimulatePaymentProcessing();
            
            if (isSuccessful)
            {
                Console.WriteLine("✓ Payment processed successfully!");
                return true;
            }
            else
            {
                Console.WriteLine("✗ Payment failed!");
                return false;
            }
        }

        public string GetPaymentMethod()
        {
            return "Credit Card";
        }

        public string GetTransactionId()
        {
            return $"CC-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        private bool SimulatePaymentProcessing()
        {
            // Simulate random success/failure
            Random random = new Random();
            return random.Next(100) < 90; // 90% success rate
        }
    }

    public class PayPalPayment : IPaymentProcessor
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public bool ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine($"Processing PayPal Payment:");
            Console.WriteLine($"  Amount: {amount} {currency}");
            Console.WriteLine($"  PayPal Email: {_email}");
            
            // Simulate PayPal processing
            bool isSuccessful = SimulatePaymentProcessing();
            
            if (isSuccessful)
            {
                Console.WriteLine("✓ PayPal payment completed!");
                return true;
            }
            else
            {
                Console.WriteLine("✗ PayPal payment failed!");
                return false;
            }
        }

        public string GetPaymentMethod()
        {
            return "PayPal";
        }

        public string GetTransactionId()
        {
            return $"PP-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }

        private bool SimulatePaymentProcessing()
        {
            Random random = new Random();
            return random.Next(100) < 95; // 95% success rate
        }
    }

    public class BankTransferPayment : IPaymentProcessor
    {
        private string _accountNumber;
        private string _bankName;

        public BankTransferPayment(string accountNumber, string bankName)
        {
            _accountNumber = accountNumber;
            _bankName = bankName;
        }

        public bool ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine($"Processing Bank Transfer:");
            Console.WriteLine($"  Amount: {amount} {currency}");
            Console.WriteLine($"  Bank: {_bankName}");
            Console.WriteLine($"  Account: ****{_accountNumber.Substring(_accountNumber.Length - 4)}");
            
            // Bank transfers are usually successful
            Console.WriteLine("✓ Bank transfer initiated successfully!");
            Console.WriteLine("  Note: Transfer may take 1-3 business days to complete.");
            
            return true;
        }

        public string GetPaymentMethod()
        {
            return "Bank Transfer";
        }

        public string GetTransactionId()
        {
            return $"BT-{DateTime.Now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

     public class PaymentProcessorFactory
    {
        public IPaymentProcessor CreatePaymentProcessor(string paymentMethod, Dictionary<string, string> paymentDetails)
        {
            return paymentMethod.ToLower() switch
            {
                "creditcard" => new CreditCardPayment(
                    paymentDetails["cardNumber"],
                    paymentDetails["cvv"],
                    paymentDetails["expiryDate"]
                ),
                
                "paypal" => new PayPalPayment(
                    paymentDetails["email"]
                ),
                
                "banktransfer" => new BankTransferPayment(
                    paymentDetails["accountNumber"],
                    paymentDetails["bankName"]
                ),
                
                _ => throw new ArgumentException($"Unsupported payment method: {paymentMethod}")
            };
        }
    }

}