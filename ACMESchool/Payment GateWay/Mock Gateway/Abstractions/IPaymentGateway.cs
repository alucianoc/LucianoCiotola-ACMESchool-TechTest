using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Payment_GateWay.Mock_Gateway.Abstractions
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(decimal amount);
    }
}
