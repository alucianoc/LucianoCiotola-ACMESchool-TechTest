using ACMESchool.Payment_GateWay.Mock_Gateway.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Payment_GateWay.Mock_Gateway.Gateway
{
    public class MockPaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            return true; // Always returns true for simplicity
        }
    }
}
