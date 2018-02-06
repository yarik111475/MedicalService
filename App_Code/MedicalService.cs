using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.Configuration;

using PrivateService.Models;
using PrivateService.Repositories.Abstract;
using PrivateService.Repositories.Concrete;

using NetrikaService.Wrappers;

/// <summary>
/// Реализация контракта службы
/// </summary>
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class MedicalService : IPrivateMedicalService, INetrikaMedicalService {
    private NetrikaWrapper netrikaWrapper;
    /// <summary>
    /// Поле репозитория
    /// </summary>
    private IRepository repository;
    /// <summary>
    /// Поле строки соединения с БД
    /// </summary>
    private string connectionString = ConfigurationManager.ConnectionStrings["TestBase"].ConnectionString;

    /// <summary>
    /// Конструктор
    /// </summary>
    public MedicalService() {
        repository = new MsSqlRepository(connectionString);

        string guid = ConfigurationManager.AppSettings["guid"];
        int? idHistory = int.Parse(ConfigurationManager.AppSettings["idHistory"]);
        netrikaWrapper = new NetrikaWrapper(guid, idHistory);
    }

    #region IPrivateMedicalServiceImplementation
    /// <summary>
    /// Создание нового пациента
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="secondName">Отчество</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="birthday">Дата рождения</param>
    /// <param name="polisNumber">Номер полиса</param>
    /// <param name="phone">Телефон</param>
    /// <returns>Идентификатор</returns>
    public int CreateNewPacient(string firstName, string secondName, string lastName, string birthday, string polisNumber, string phone) {
        Pacient pacient = new Pacient {
            FirstName = firstName,
            SecondName = secondName,
            LastName = lastName,
            Birthday = birthday,
            PolisNumber = polisNumber,
            Phone = phone
        };
        return repository.CreatePacient(pacient);
    }

    /// <summary>
    /// Получение списка регионов
    /// </summary>
    /// <returns>Список регионов</returns>
    public Region[] GetReagions() {
        try {
            return repository.ReadRegions();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Получение списка городов определенного региона
    /// </summary>
    /// <param name="regionId">Идентификатор региона</param>
    /// <returns>Список городов</returns>
    public City[] GetCitiesByRegionId(int regionId) {
        try {
            return repository.ReadCities()
            .Where(c => c.RegionId == regionId)
            .ToArray();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Получение списка специальностей
    /// </summary>
    /// <returns>Сптсок специальностей</returns>
    public Speciality[] GetSpecialities() {
        try {
            return repository.ReadSpecialities();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Получение списка врачей определенной специальности
    /// </summary>
    /// <param name="specialityId">Идентификатор специальности</param>
    /// <returns>Список врачей</returns>
    public Doctor[] GetDoctorsBySpecialityId(int specialityId) {
        try {
            return repository.ReadDoctors()
            .Where(d => d.SpecialityId == specialityId)
            .ToArray();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Получение списка клиник определенного города по идентификатору города и идентификатору врача
    /// </summary>
    /// <param name="cityId">Идентификатор города</param>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns>Список клиник</returns>
    public Clinic[] GetClinicsByCityIdAndDoctorId(int cityId, int doctorId) {
        try {
            var clinicsByCityId = repository.ReadClinics().Where(c => c.CityId == cityId);
            var indexes = repository.ReadDoctorsToClinics().Where(dc => dc.DoctorId == doctorId).Select(dc => dc.ClinicId);
            var selectedClinics = clinicsByCityId.Where(c => indexes.Contains(c.ClinicId)).ToArray();
            return selectedClinics;
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Получение точки записи на прием по идентификатору клиники и идентификатору врача
    /// </summary>
    /// <param name="clinicId">Идентификатор клиники</param>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns>Список точек записи</returns>
    public Appointment[] GetAppointmentsByClinicIdAndDoctorId(int clinicId, int doctorId) {
        try {
            return repository.ReadAppointments()
            .Where(a => a.ClinicId == clinicId && a.DoctorId == doctorId)
            .ToArray();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }

    /// <summary>
    /// Записл на прием в определенной точке записи
    /// </summary>
    /// <param name="appointmentId">Идентификатор точки записи на прием</param>
    /// <param name="pacientId">Идентификатор пациента</param>
    public void SetAppointment(int appointmentId, int pacientId) {
        try {
            Appointment appointment = repository.ReadAppointmentByAppointmentId(appointmentId);
            appointment.PacientId = pacientId;
            repository.UpdateAppointments(appointment);
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }
    #endregion

    public NetrikaService.NetrikaReference.District[] GetDistricts() {
        try {
            return netrikaWrapper.GetDistrists();
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }


    public NetrikaService.NetrikaReference.Clinic[] GetClinics(int idDistrict) {
        try {
            return netrikaWrapper.GetClinics(idDistrict);
        }
        catch (Exception ex) {
            FaultException error = new FaultException(ex.Message);
            throw error;
        }
    }
}
