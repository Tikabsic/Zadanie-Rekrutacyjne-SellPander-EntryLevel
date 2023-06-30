using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_rekrutacyjne_SellPander.Helpers
{
    internal static class Compare
    {
        internal static bool CompareRecivedOrdersFromFaireToExistingOrderInBaselinker(string faireOrderId, string baselinkerExtraFieldFaireOrderId)
        {
            return faireOrderId.Equals(baselinkerExtraFieldFaireOrderId);
        }
    }
}
