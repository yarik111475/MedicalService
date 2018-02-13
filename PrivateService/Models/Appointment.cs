using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Точка записи
    /// </summary>
    [DataContract]
    public class Appointment {
        [DataMember]
        public int AppointmentId { get; set; }
        [DataMember]
        public string AppointmentState { get; set; }
        [DataMember]
        public DateTime AppointmentDate { get; set; }
        [DataMember]
        public int ClinicId { get; set; }
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public int PacientId { get; set; }
    }
}
