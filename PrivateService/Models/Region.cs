using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PrivateService.Models {
    /// <summary>
    /// Модель Регион
    /// </summary>
    [DataContract]
    public class Region {
        [DataMember]
        public int RegionId { get; set; }
        [DataMember]
        public string RegionName { get; set; }
        [DataMember]
        public int RegionCode { get; set; }
    }
}
