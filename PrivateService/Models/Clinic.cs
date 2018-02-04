using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Клиника
    /// </summary>
    [DataContract]
    public class Clinic {
        [DataMember]
        public int ClinicId { get; set; }
        [DataMember]
        public string ClinicName { get; set; }
        [DataMember]
        public string ClinicAddress { get; set; }
        [DataMember]
        public int CityId { get; set; }
    }
}
