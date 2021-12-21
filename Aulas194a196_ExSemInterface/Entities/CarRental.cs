/* >>> CAMADA DE DOMINIO - CLASSE CARRENTAL - PASTA ENTITIES <<< */
using System;

namespace Aulas194a196_ExSemInterface.Entities
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        // Construtor sem a propriedade "Invoice", pois "Invoice" deve iniciar como "null"
        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            // Invoice = null;
        }
    }
}
