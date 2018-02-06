using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

using PrivateService.Models;

/// <summary>
/// Контракт службы
/// </summary>
[ServiceContract]
public interface IPrivateMedicalService {
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
    [OperationContract]
    [WebGet(UriTemplate="/createPacient?firstName={firstName}&secondName={secondName}&lastName={lastName}&birthday={birthday}&polisNumber={polisNumber}&phone={phone}")]
    int CreateNewPacient(string firstName, string secondName, string lastName, string birthday, string polisNumber, string phone);

    /// <summary>
    /// Получение списка регионов
    /// </summary>
    /// <returns>Список регионов</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getRegions")]
    Region[] GetReagions();

    /// <summary>
    /// Получение списка городов определенного региона
    /// </summary>
    /// <param name="regionId">Идентификатор региона</param>
    /// <returns>Список городов</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getCities?regionId={regionId}")]
    City[] GetCitiesByRegionId(int regionId);

    /// <summary>
    /// Получение списка специальностей
    /// </summary>
    /// <returns>Сптсок специальностей</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getSpecialities")]
    Speciality[] GetSpecialities();

    /// <summary>
    /// Получение списка врачей определенной специальности
    /// </summary>
    /// <param name="specialityId">Идентификатор специальности</param>
    /// <returns>Список врачей</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getDoctors?specialityId={specialityId}")]
    Doctor[] GetDoctorsBySpecialityId(int specialityId);

    /// <summary>
    /// Получение списка клиник определенного города по идентификатору города и идентификатору врача
    /// </summary>
    /// <param name="cityId">Идентификатор города</param>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns>Список клиник</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getClinics?cityId={cityId}&doctorId={doctorId}")]
    Clinic[] GetClinicsByCityIdAndDoctorId(int cityId, int doctorId);

    /// <summary>
    /// Получение точки записи на прием по идентификатору клиники и идентификатору врача
    /// </summary>
    /// <param name="clinicId">Идентификатор клиники</param>
    /// <param name="doctorId">Идентификатор врача</param>
    /// <returns>Список точек записи</returns>
    [OperationContract]
    [WebGet(UriTemplate="/getAppointments?clinicId={clinicId}&doctorId={doctorId}")]
    Appointment[] GetAppointmentsByClinicIdAndDoctorId(int clinicId, int doctorId);

    /// <summary>
    /// Записл на прием в определенной точке записи
    /// </summary>
    /// <param name="appointmentId">Идентификатор точки записи на прием</param>
    /// <param name="pacientId">Идентификатор пациента</param>
    [OperationContract]
    [WebGet(UriTemplate="/setAppointment?appointmentId={appointmentId}&pacientId={pacientId}")]
    void SetAppointment(int appointmentId, int pacientId);
}