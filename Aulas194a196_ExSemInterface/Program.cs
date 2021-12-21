/* INTERFACE - E um Tipo que define um conjunto de operacoes que uma Classe (ou Struct) deve implementar.
    - Estavelece um "contrato" que a a Classe (ou Struct) deve cumprir.
    Notacao:
   
        interface IShape // Figura possuindo:
        {
            double Area(); // Area
            double Perimeter(); // Perimetro
        }

    Exemplo: Uma locadora brasileira de carros cobra um valor por hora para locacoes de ate 12 horas. Porem, se a duração da
             locacao ultrapassar 12 horas, esta sera cobrada com base em um valor diario. Alem do valor da locacao, e acrescido
             ao preço o valor do imposto, conforme regras do pais que, no caso do Brasil, e de 20% para valores ate 100.00,
             ou 15% para valores acima de 100.00. Fazer um programa que le os dados da locacao (modelo do carro, instante
             inicial e final da locacao), bem como o valor por hora e o valor diario de locacao. O programa deve, então,
             gerar a nota de pagamento (contendo valor da locacao, valor do imposto e valor total do pagamento) e informar
             os dados na tela. Veja os exemplos:

             Exemplo 1:

                Enter rental data:
                Car model: Civic
                Pickup (dd/MM/yyyy hh:mm): 25/06/2018 10:30
                Return (dd/MM/yyyy hh:mm): 25/06/2018 14:40
                Enter price per hour: 10.00
                Enter price per day: 130.00
                INVOICE:
                Basic payment: 50.00
                Tax: 10.00
                Total payment: 60.00

                Calculos:
                Duration = (25/06/2018 14:40) - (25/06/2018 10:30) = 4:10 = 5 hours
                Basic payment = 5 * 10 = 50
                Tax = 50 * 20% = 50 * 0.2 = 10

             Exemplo 2:

                Enter rental data:
                Car model: Civic
                Pickup (dd/MM/yyyy hh:mm): 25/06/2018 10:30
                Return (dd/MM/yyyy hh:mm): 27/06/2018 11:40
                Enter price per hour: 10.00
                Enter price per day: 130.00
                INVOICE:
                Basic payment: 390.00
                Tax: 58.50
                Total payment: 448.50

                Calculos:
                Duration = (27/06/2018 11:40) - (25/06/2018 10:30) = 2 days + 1:10 = 3 days
                Basic payment = 3 * 130 = 390
                Tax = 390 * 15% = 390 * 0.15 = 58.50


    >>> CAMADA DE DOMINIO - ENTIDADES DO NEGOCIO:
        - Vehicle - Model: String;
        - CarRental - Start: Date; - Finish: Date;
        - Invoice - BasicPayment: Double; - Tax: Double; - / TotalPayment: Double(pode ser um metodo tambem).

    >>> CAMADA DE SERVICOS - SEM INTERFACE
        - RentalService - PricePerHour: Double; PricePerDay: Double; Operacao: ProcessInvoice(CarRental: carRental): void;
        - BrazilTaxService.

 */

/* >>> PROGRAMA PRINCIPAL <<< */
using System;
using System.Globalization;
using Aulas194a196_ExSemInterface.Entities;
using Aulas194a196_ExSemInterface.Services;

namespace Aulas194a196_ExSemInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data: ");
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Rental date (dd/MM/yyyy hh:mm): ");
            DateTime rentalDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return date (dd/MM/yyyy hh:mm): ");
            DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instancia o objeto tipo CarRental com os argumentos entre parenteses
            CarRental carRental = new CarRental(rentalDate, returnDate, new Vehicle(model));

            // Instancia o RentalService
            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental); // Gera o objeto "Invoice" associado ao aluguel do CarRental

            Console.WriteLine("Invoice:");
            Console.WriteLine(carRental.Invoice);

        }
    }
}
