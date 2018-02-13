using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateService.Models {
    /// <summary>
    /// Модель для связи многие-ко-многим между Doctor и Clinic
    /// </summary>
    public class DoctorsToClinics {
        public int DoctorsToClinicsId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
    }
}
