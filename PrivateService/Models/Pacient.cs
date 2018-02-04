using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Пациент
    /// </summary>
    [DataContract]
    public class Pacient {
        [DataMember]
        public int PacientId { get; set; }
        [DataMember]
        public string PacientName { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public string PolisNumber { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
