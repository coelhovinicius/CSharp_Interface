/* >>> CAMADA DE DOMINIO - CLASSE INVOICE - PASTA ENTITIES <<< */
using System.Globalization;

namespace Aulas194a196_ExSemInterface.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; } // Faz um get no BasicPayment e soma com a taxa
        }

        public override string ToString()
        {
            return "Basic Payment: " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture) // "\n" adiciona quebra de linha
                + "\nTotal Payment: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
