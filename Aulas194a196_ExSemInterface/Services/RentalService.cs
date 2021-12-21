/* >>> CAMADA DE SERVICOS - CLASSE RENTALSERVICE - PASTA SERVICES <<< */

using System;
using Aulas194a196_ExSemInterface.Entities;

namespace Aulas194a196_ExSemInterface.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        // Instancia um atributo tipo BrazilTaxService e instancia sem argumentos (para garantir que o atributo ja seja iniciado)
        private BrazilTaxService _brazilTaxService = new BrazilTaxService(); // Underline: padrao C# para atributos privados

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice (CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start); // Calcula o periodo do aluguel do carro

            double basicPayment = 0.0; // Atribuir valor a variavel garante que ela sera iniciada
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); // "Math.Ceiling" arredonda para cima
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxService.Tax(basicPayment); // Calcula o imposto baseado no pagamento basico

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
