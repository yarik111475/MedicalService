using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PrivateService.Models;

namespace PrivateService.Repositories.Abstract {
    public interface IRepository {
        #region READ
        Pacient[] ReadPaciens();
        Region[] ReadRegions();
        City[] ReadCities();
        Doctor[] ReadDoctors();
        Speciality[] ReadSpecialities();
        Clinic[] ReadClinics();
        Appointment[] ReadAppointments();
        DoctorsToClinics[] ReadDoctorsToClinics();
        #endregion
    }
}
