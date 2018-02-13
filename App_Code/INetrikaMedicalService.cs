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
    [WebGet(UriTemplate = "/getDoctors?idSpeciality={idSpeciality}&idLpu={idLpu}&idPat={idPat}")]
    Doctor1[] GetDoctors(string idSpeciality, int idLpu, string idPat);

    [OperationContract]
    [WebGet(UriTemplate="/getPacientAreas?idLpu={idLpu}&idPat={idPat}")]
    PatientsArea[] GetPacientAreas(string idLpu, string idPat);

    [OperationContract]
    [WebGet(UriTemplate="/getSpecialities?idLpu={idLpu}&idPat={idPat}")]
    Spesiality[] GetSpecialities(int idLpu, string idPat);

    [OperationContract]
    [WebGet(UriTemplate = "/getAvailableDates?idDoc={idDoc}&idLpu={idLpu}&idPat={idPat}&visitStart={visitStart}&visitEnd={visitEnd}")]
    DateTime[] GetAvailableDates(string idDoc, int idLpu, string idPat, DateTime visitStart, DateTime visitEnd);

    [OperationContract]
    [WebGet(UriTemplate = "/getAvailableAppointments?idDoc={idDoc}&idLpu={idLpu}&idPat={idPat}&visitStart={visitStart}&visitEnd={visitEnd}")]
    Appointment[] GetAvailableAppointments(string idDoc, int idLpu, string idPat, DateTime visitStart, DateTime visitEnd);
}