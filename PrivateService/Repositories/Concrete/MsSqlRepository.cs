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
            string command = "INSERT INTO Pacients(FirstName, SecondName, LastName, Birthday, PolisNumber, Phone) VALUES (@FirstName, @SecondName, @LastName, @Birthday, @PolisNumber, @Phone) SET @PacientId=SCOPE_IDENTITY";
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    cmd.Parameters.AddWithValue("@FirstName", pacient.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", pacient.SecondName);
                    cmd.Parameters.AddWithValue("@LastName", pacient.LastName);
                    cmd.Parameters.AddWithValue("@Birthday", pacient.Birthday);
                    cmd.Parameters.AddWithValue("@PolisNumber", pacient.PolisNumber);
                    cmd.Parameters.AddWithValue("@Phone", pacient.Phone);
                    cmd.Parameters.AddWithValue("@PacientId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int pacientId = cmd.Parameters["@PacientId"].Value==DBNull.Value ? -1 : int.Parse(cmd.Parameters["@PacientId"].Value.ToString());
                    return pacientId;
                }
            }
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
            string command = "SELECT * From Pacients";
            List<Pacient> pacients = new List<Pacient>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Pacient pacient = new Pacient {
                                PacientId = int.Parse(dr["PacientId"].ToString()),
                                FirstName = (string)dr["FirstName"],
                                SecondName = (string)dr["SecondName"],
                                LastName = (string)dr["LastName"],
                                Birthday = (string)dr["Birthday"],
                                PolisNumber = (string)dr["PolisNumber"],
                                Phone = (string)dr["Phone"]
                            };
                            pacients.Add(pacient);
                        }
                    }
                }
            }
            return pacients.ToArray();
        }

        public Region[] ReadRegions() {
            string command = "SELECT * FROM Regions";
            List<Region> regions = new List<Region>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Region region = new Region {
                                RegionId = int.Parse(dr["RegionId"].ToString()),
                                RegionName = (string)dr["RegionName"],
                                RegionCode = int.Parse(dr["RegionCode"].ToString())
                            };
                            regions.Add(region);
                        }
                    }
                }
            }
            return regions.ToArray();
        }

        public City[] ReadCities() {
            string command = "SELECT * FROM Cities";
            List<City> cities = new List<City>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            City city = new City {
                                CityId = int.Parse(dr["CityId"].ToString()),
                                CityName = (string)dr["CityName"],
                                RegionId = int.Parse(dr["RegionId"].ToString())
                            };
                            cities.Add(city);
                        }
                    }
                }
            }
            return cities.ToArray();
        }

        public Doctor[] ReadDoctors() {
            string command = "SELECT * FROM Doctors";
            List<Doctor> doctors = new List<Doctor>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Doctor doctor = new Doctor {
                                DoctorId = int.Parse(dr["DoctorId"].ToString()),
                                DoctorName = (string)dr["DoctorName"],
                                SpecialityId = int.Parse(dr["SpecialityId"].ToString())
                            };
                            doctors.Add(doctor);
                        }
                    }
                }
            }
            return doctors.ToArray();
        }

        public Speciality[] ReadSpecialities() {
            string command = "SELECT * FROM Specialities";
            List<Speciality> specialities = new List<Speciality>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Speciality speciality = new Speciality {
                                SpecialityId = int.Parse(dr["SpecialityId"].ToString()),
                                SpecialityName = (string)dr["SpecialityName"]
                            };
                            specialities.Add(speciality);
                        }
                    }
                }
            }
            return specialities.ToArray();
        }

        public Clinic[] ReadClinics() {
            string command = "SELECT * FROM Clinics";
            List<Clinic> clinics = new List<Clinic>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Clinic clinic = new Clinic {
                                ClinicId = int.Parse(dr["ClinicId"].ToString()),
                                ClinicName = (string)dr["ClinicName"],
                                ClinicAddress = (string)dr["ClinicAddress"],
                                CityId = int.Parse(dr["CityId"].ToString())
                            };
                            clinics.Add(clinic);
                        }
                    }
                }
            }
            return clinics.ToArray();
        }

        public Appointment[] ReadAppointments() {
            string command = "SELECT * FROM Appointments";
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            Appointment appointment = new Appointment {
                                AppointmentId = int.Parse(dr["AppointmentId"].ToString()),
                                AppointmentState = (string)dr["AppointmentState"],
                                AppointmentDate = DateTime.Parse(dr["AppointmentDate"].ToString()),
                                ClinicId = int.Parse(dr["ClinicId"].ToString()),
                                DoctorId = int.Parse(dr["DoctorId"].ToString()),
                                PacientId = dr["PacientId"] == DBNull.Value ? -1 : int.Parse(dr["PacientId"].ToString())
                            };
                            appointments.Add(appointment);
                        }
                    }
                }
            }
            return appointments.ToArray();
        }

        public DoctorsToClinics[] ReadDoctorsToClinics() {
            string command = "SELECT * FROM DoctorsToClinics";
            List<DoctorsToClinics> doctorsToClinics = new List<DoctorsToClinics>();
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            DoctorsToClinics dtc = new DoctorsToClinics {
                                DoctorsToClinicsId = int.Parse(dr["DoctorsToClinicsId"].ToString()),
                                DoctorId = int.Parse(dr["DoctorId"].ToString()),
                                ClinicId = int.Parse(dr["ClinicId"].ToString())
                            };
                            doctorsToClinics.Add(dtc);
                        }
                    }
                }
            }
            return doctorsToClinics.ToArray();
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
            string command = "UPDATE Appointments SET AppointmentSate=@AppointmentState, AppointmentDate=@AppointmentDate, ClinicId=@ClinicId, DoctorId=@DoctorId, PacientId=@PacientId WHERE AppointmentId=@AppointmentId";
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    cmd.Parameters.AddWithValue("@AppointmentState", appointment.AppointmentState);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@ClinicId", appointment.ClinicId);
                    cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@PacientId", appointment.PacientId);
                    cmd.ExecuteNonQuery();
                }
            }
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
            string command = "SELECT * FROM Pacients WHERE PacientId=@PacientId";
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    cmd.Parameters.AddWithValue("@PacientId", pacientId);
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (!dr.HasRows) throw new Exception("wrong pacient id");
                        dr.Read();
                        Pacient pacient = new Pacient {
                            PacientId = pacientId,
                            FirstName = (string)dr["FirstName"],
                            SecondName = (string)dr["SecondName"],
                            LastName = (string)dr["LastName"],
                            Birthday = (string)dr["Birthday"],
                            PolisNumber = (string)dr["PolisNumber"],
                            Phone = (string)dr["Phone"]
                        };
                        return pacient;
                    }
                }
            }
        }

        public Region ReadRegionByRegionId(int regionId) {
            string command = "SELECT * FROM Regions WHERE RegionId=@RegionId";
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    cmd.Parameters.AddWithValue("@RegionId", regionId);
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (!dr.HasRows) throw new Exception("wrong region id");
                        dr.Read();
                        Region region = new Region {
                            RegionId = regionId,
                            RegionName = (string)dr["RegionName"],
                            RegionCode = int.Parse(dr["RegionCode"].ToString())
                        };
                        return region;
                    }
                }
            }
        }

        public City ReadCityByCityId(int cityId) {
            string command = "SELECT * FROM Cities WHERE CityId=@CityId";
            using (SqlConnection cnn = CreateConnection()) {
                using (SqlCommand cmd = new SqlCommand(command, cnn)) {
                    cmd.Parameters.AddWithValue("@CityId", cityId);
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (!dr.HasRows) throw new Exception("erong city id");
                        dr.Read();
                        City city = new City {
                            CityId = int.Parse(dr["CityId"].ToString()),
                            CityName = (string)dr["CityName"],
                            RegionId = int.Parse(dr["RegionId"].ToString())
                        };
                        return city;
                    }
                }
            }
        }

        public Doctor ReadDoctorByDoctorId(int doctorId) {
            throw new NotImplementedException();
        }

        public Doctor ReadDoctorByDoctorPassword(string doctorPassword) {
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
