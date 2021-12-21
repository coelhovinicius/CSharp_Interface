/* >>> CAMADA DE SERVICOS - CLASSE BRAZILTASERVICE - PASTA SERVICES <<< */

namespace Aulas194a196_ExSemInterface.Services
{
    class BrazilTaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
