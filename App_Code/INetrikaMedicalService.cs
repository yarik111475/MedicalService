using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

using NetrikaService.Wrappers;
using NetrikaService.NetrikaReference;

/// <summary>
/// Контракт службы для Netrika
/// </summary>
[ServiceContract]
public interface INetrikaMedicalService {
    [OperationContract]
    [WebGet(UriTemplate="/getDistricts")]
    District[] GetDistricts();

    [OperationContract]
    [WebGet(UriTemplate="/getClinics?idDistrict={idDistrict}")]
    Clinic[] GetClinics(int idDistrict);

    [OperationContract]
    [WebGet(UriTemplate="/getPacientAreas?idLpu={idLpu}&idPat={idPat}")]
    PatientsArea[] GetPacientAreas(string idLpu, string idPat);
}