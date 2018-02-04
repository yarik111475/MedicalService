using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using PrivateService.Models;
using PrivateService.Repositories.Abstract;

namespace PrivateService.Repositories.Concrete {
    public class MsSqlRepository : AbstractMsSqlRepository, IRepository {
        public MsSqlRepository(string connectionString)
            : base(connectionString) {
        }
        #region CREATE
        public int CreatePacient(Pacient pacient) {
            throw new NotImplementedException();
        }

        public void CreateRegion(Region region) {
            throw new NotImplementedException();
        }

        public void CreateCity(City city) {
            throw new NotImplementedException();
        }

        public void CreateDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public void CreateSpeciality(Speciality speciality) {
            throw new NotImplementedException();
        }

        public void CreateClinic(Clinic clinic) {
            throw new NotImplementedException();
        }

        public void CreateAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public void CreateDoctorsToClinics(DoctorsToClinics doctorstoclinics) {
            throw new NotImplementedException();
        }
        #endregion

        #region READ
        public Pacient[] ReadPaciens() {
            throw new NotImplementedException();
        }

        public Region[] ReadRegions() {
            throw new NotImplementedException();
        }

        public City[] ReadCities() {
            throw new NotImplementedException();
        }

        public Doctor[] ReadDoctors() {
            throw new NotImplementedException();
        }

        public Speciality[] ReadSpecialities() {
            throw new NotImplementedException();
        }

        public Clinic[] ReadClinics() {
            throw new NotImplementedException();
        }

        public Appointment[] ReadAppointments() {
            throw new NotImplementedException();
        }

        public DoctorsToClinics[] ReadDoctorsToClinics() {
            throw new NotImplementedException();
        }
        #endregion

        #region UPDATE
        public void UpdatePacients(Pacient pacient) {
            throw new NotImplementedException();
        }

        public void UpdateRegions(Region region) {
            throw new NotImplementedException();
        }

        public void UpdateCities(City city) {
            throw new NotImplementedException();
        }

        public void UpdateDoctors(Doctor doctor) {
            throw new NotImplementedException();
        }

        public void UpdateSpecialities(Speciality speciality) {
            throw new NotImplementedException();
        }

        public void UpdateClinics(Clinic clinic) {
            throw new NotImplementedException();
        }

        public void UpdateAppointments(Appointment appointment) {
            throw new NotImplementedException();
        }

        public void UpdateDoctorsToClinics(DoctorsToClinics doctorstoclinics) {
            throw new NotImplementedException();
        }
        #endregion

        #region DELETEBYID
        public void DeletePacientById(int pacientId) {
            throw new NotImplementedException();
        }

        public void DeleteRegionByRegionId(int regionId) {
            throw new NotImplementedException();
        }

        public void DeleteCityByCityId(int cityId) {
            throw new NotImplementedException();
        }

        public void DeleteDoctorByDoctorId(int doctorId) {
            throw new NotImplementedException();
        }

        public void DeleteSpecialityBySpecialityId(int specialityId) {
            throw new NotImplementedException();
        }

        public void DeleteClinicByClinicId(int clinicId) {
            throw new NotImplementedException();
        }

        public void DeleteAppointmentByAppointmentId(int appointmentId) {
            throw new NotImplementedException();
        }

        public void DeleteDoctorsAndClinicsByDoctorsAndClinicsId(int doctorsandclinicsId) {
            throw new NotImplementedException();
        }
        #endregion

        #region READBYID
        public Pacient ReadPacientByPacientId(int pacientId) {
            throw new NotImplementedException();
        }

        public Region ReadRegionByRegionId(int regionId) {
            throw new NotImplementedException();
        }

        public City ReadCityByCityId(int cityId) {
            throw new NotImplementedException();
        }

        public Doctor ReadDoctorByDoctorId(int doctorId) {
            throw new NotImplementedException();
        }

        public Speciality ReadSpecialityBySpecialityId(int specialityId) {
            throw new NotImplementedException();
        }

        public Clinic ReadClinicByClinicId(int clinicId) {
            throw new NotImplementedException();
        }

        public Appointment ReadAppointmentByAppointmentId(int appointmentId) {
            throw new NotImplementedException();
        }

        public DoctorsToClinics ReadDoctorsToClinicsByDoctorsToClinicsId(int doctorstoclinicsId) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
