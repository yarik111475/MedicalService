using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PrivateService.Models;

namespace PrivateService.Repositories.Abstract {
    public interface IRepository {
        #region CREATE
        int CreatePacient(Pacient pacient);
        void CreateRegion(Region region);
        void CreateCity(City city);
        void CreateDoctor(Doctor doctor);
        void CreateSpeciality(Speciality speciality);
        void CreateClinic(Clinic clinic);
        void CreateAppointment(Appointment appointment);
        void CreateDoctorsToClinics(DoctorsToClinics doctorstoclinics);
        #endregion

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

        #region UPDATE
        void UpdatePacients(Pacient pacient);
        void UpdateRegions(Region region);
        void UpdateCities(City city);
        void UpdateDoctors(Doctor doctor);
        void UpdateSpecialities(Speciality speciality);
        void UpdateClinics(Clinic clinic);
        void UpdateAppointments(Appointment appointment);
        void UpdateDoctorsToClinics(DoctorsToClinics doctorstoclinics);
        #endregion

        #region DELETEBYID
        void DeletePacientById(int pacientId);
        void DeleteRegionByRegionId(int regionId);
        void DeleteCityByCityId(int cityId);
        void DeleteDoctorByDoctorId(int doctorId);
        void DeleteSpecialityBySpecialityId(int specialityId);
        void DeleteClinicByClinicId(int clinicId);
        void DeleteAppointmentByAppointmentId(int appointmentId);
        void DeleteDoctorsAndClinicsByDoctorsAndClinicsId(int doctorsandclinicsId);
        #endregion

        #region READBYID
        Pacient ReadPacientByPacientId(int pacientId);
        Region ReadRegionByRegionId(int regionId);
        City ReadCityByCityId(int cityId);
        Doctor ReadDoctorByDoctorId(int doctorId);
        Doctor ReadDoctorByDoctorPassword(string doctorPassword);
        Speciality ReadSpecialityBySpecialityId(int specialityId);
        Clinic ReadClinicByClinicId(int clinicId);
        Appointment ReadAppointmentByAppointmentId(int appointmentId);
        DoctorsToClinics ReadDoctorsToClinicsByDoctorsToClinicsId(int doctorstoclinicsId);
        #endregion
    }
}
