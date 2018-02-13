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
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public string PolisNumber { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
