using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_rekrutacyjne_SellPander.DTO.Faire.Enums
{
    internal enum OrderStates
    {
        NEW,
        PROCESSING,
        PRE_TRANSIT,
        IN_TRANSIT,
        DELIVERED,
        BACKORDERED,
        CANCELED
    }

}
