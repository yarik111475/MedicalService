using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Город
    /// </summary>
    [DataContract]
    public class City {
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public int RegionId { get; set; }
    }
}
