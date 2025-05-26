using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PooModel
{
    public class Animal
    {
        #region Atributes
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Color { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        public AnimalType AnimalType { get; set; }
        // Incializando aqui para evitar avisos do compilador
        public List<Vaccine> Vaccines { get; set; } = new();
        #endregion


        public bool Validate()
        {
            bool isValid = true;

            isValid = !string.IsNullOrEmpty(Name) && Id > 0 &&
                Birthdate.HasValue && !string.IsNullOrEmpty(Color) &&
                Weight > 0 && Height > 0 && AnimalType != null;

            return isValid;
        }
    }
}