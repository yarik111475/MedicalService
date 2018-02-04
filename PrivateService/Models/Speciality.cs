using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Специальность
    /// </summary>
    [DataContract]
    public class Speciality {
        [DataMember]
        public int SpecialityId { get; set; }
        [DataMember]
        public string SpecialityName { get; set; }
    }
}
