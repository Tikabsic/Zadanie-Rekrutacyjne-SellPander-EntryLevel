
namespace Zadanie_rekrutacyjne_SellPander.Helpers
{
    internal static class CheckForPayment
    {
        internal static bool CheckForOrderPayment(DTO.Faire.Order faireOrder)
        {
            if (faireOrder.state >= DTO.Faire.Enums.OrderStates.PRE_TRANSIT)
            {
                return true;
            }

            return false;
        }
    }
}
