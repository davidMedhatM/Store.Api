using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntities
{
    public enum OrderPaymentStatus
    {
        PENDING,
        PAYMENT_RECEIVED,
        PAYMENT_FAILED
    }
}
