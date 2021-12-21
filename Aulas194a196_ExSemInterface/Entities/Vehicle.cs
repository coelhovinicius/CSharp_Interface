/* >>> CAMADA DE DOMINIO - CLASSE VEHICLE - PASTA ENTITIES <<< */
namespace Aulas194a196_ExSemInterface.Entities
{
    class Vehicle
    {
        public string Model { get; set; }

        public Vehicle(string model)
        {
            Model = model;
        }
    }
}
