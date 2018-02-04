using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Доктор
    /// </summary>
    [DataContract]
    public class Doctor {
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public string DoctorName { get; set; }
        [DataMember]
        public int SpecialityId { get; set; }
    }
}
