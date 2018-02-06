using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

using NetrikaService.Wrappers;
using NetrikaService.NetrikaReference;

[ServiceContract]
public interface INetrikaMedicalService {
    [OperationContract]
    [WebGet(UriTemplate="/getDistricts")]
    District[] GetDistricts();

    [OperationContract]
    [WebGet(UriTemplate="/getClinics?idDistrict={idDistrict}")]
    Clinic[] GetClinics(int idDistrict);
}