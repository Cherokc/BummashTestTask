using System.ComponentModel.DataAnnotations;

namespace ForgingModelCalculator.Web.Models
{
    public class RolledRingModel
    {
        [Display(Name = "D")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal D { get; set; }

        [Display(Name = "d")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal InnderD { get; set; }

        [Display(Name = "H")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal H { get; set; }

        [Display(Name = "x")]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public int x { get; set; }

        [Display(Name = "y")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal y { get; set; }

        [Display(Name = "Q")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal Q { get; set; }

        [Display(Name = "Напуск на термообработку")]
        [Range(0, double.MaxValue, ErrorMessage = "Значение должно быть больше нуля.")]
        public decimal ThermalTreatmentAllowance { get; set; }

        public int z => x - 1;

        public decimal H1 => H * x + y * z + ThermalTreatmentAllowance;

        public decimal H2 => H * x + y * z + Q + ThermalTreatmentAllowance;
    }
}
