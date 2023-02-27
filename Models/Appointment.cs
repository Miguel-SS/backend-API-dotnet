using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIBackend.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? fk_id_patient { get; set; }
        public int? fk_id_doctor { get; set; }
        public int? fk_id_hospital { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string? Name { get; set; }
        public double? TotalCost { get; set; }
        public bool? Active { get; set; }

        //public Appointment()
        //{
        //    this.Patient = new Patient();
        //    this.Doctor = new Doctor();
        //    this.Hospital = new Hospital();
        //}

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Hospital? Hospital { get; set; }
    }
}
