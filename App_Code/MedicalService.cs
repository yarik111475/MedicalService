using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using PrivateService.Models;


public class MedicalService : IPrivateMedicalService {
    #region IPrivateMedicalServiceImplementation
    public int CreateNewPacient(string name, string birthday, string polisNumber, string phone) {
        throw new NotImplementedException();
    }

    public Region[] GetReagions() {
        throw new NotImplementedException();
    }

    public City[] GetCitiesByRegionId(int regionId) {
        throw new NotImplementedException();
    }

    public Speciality[] GetSpecialities() {
        throw new NotImplementedException();
    }

    public Doctor[] GetDoctorsBySpecialityId(int specialityId) {
        throw new NotImplementedException();
    }

    public Clinic[] GetClinicsByCityIdAndDoctorId(int cityId, int doctorId) {
        throw new NotImplementedException();
    }

    public Appointment[] GetAppointmentsByClinicIdAndDoctorId(int clinicId, int doctorId) {
        throw new NotImplementedException();
    }

    public void SetAppointment(int appointmentId, int pacientId) {
        throw new NotImplementedException();
    }
    #endregion
}
