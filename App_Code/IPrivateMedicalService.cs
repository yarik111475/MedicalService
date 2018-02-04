using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

using PrivateService.Models;


[ServiceContract]
public interface IPrivateMedicalService {
    [OperationContract]
    [WebGet(UriTemplate="/createPacient?name={name}&birthday={birthday}&polisNumber={polisNumber}&phone={phone}")]
    int CreateNewPacient(string name, string birthday, string polisNumber, string phone);

    [OperationContract]
    [WebGet(UriTemplate="/getRegions")]
    Region[] GetReagions();

    [OperationContract]
    [WebGet(UriTemplate="/getCities?regionId={regionId}")]
    City[] GetCitiesByRegionId(int regionId);

    [OperationContract]
    [WebGet(UriTemplate="/getSpecialities")]
    Speciality[] GetSpecialities();

    [OperationContract]
    [WebGet(UriTemplate="/getDoctors?specialityId={specialityId}")]
    Doctor[] GetDoctorsBySpecialityId(int specialityId);

    [OperationContract]
    [WebGet(UriTemplate="/getDoctors?cityId={cityId}&doctorId={doctorId}")]
    Clinic[] GetClinicsByCityIdAndDoctorId(int cityId, int doctorId);

    [OperationContract]
    [WebGet(UriTemplate="/getAppointments?clinicId={clinicId}&doctorId={doctorId}")]
    Appointment[] GetAppointmentsByClinicIdAndDoctorId(int clinicId, int doctorId);

    [OperationContract]
    [WebGet(UriTemplate="/setAppointment?appointmentId={appointmentId}&pacientId={pacientId}")]
    void SetAppointment(int appointmentId, int pacientId);
}