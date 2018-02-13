using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NetrikaService.NetrikaReference;

namespace NetrikaService.Wrappers {
    public class NetrikaWrapper {
        private string guid = null;

        private int? idHistory;

        private HubServiceClient proxy;

        public NetrikaWrapper(string guid, int? idHistory = 0) {
            this.guid = guid;
            this.idHistory = idHistory;
            this.proxy = new HubServiceClient();
        }

        public District[] GetDistrists() {
            DistrictResult result = this.proxy.GetDistrictList(this.guid, this.idHistory);
            if (result.Success) {
                return result.Districts;
            }
            return null;
        }

        public Clinic[] GetClinics(int? idDistrict) {
            GetLPUListResult result = this.proxy.GetLPUList(idDistrict, this.guid, this.idHistory);
            if (result.Success) {
                return result.ListLPU;
            }
            return null;
        }

        public Doctor1[] GetDoctors(string idSpeciality, int idLpu, string idPat) {
            GetDoctorListResult result = this.proxy.GetDoctorList(idSpeciality, idLpu, idPat, guid, idHistory);
            if (result.Success) {
                return result.Docs;
            }
            return null;
        }

        public PatientsArea[] GetPacientAreas(string idLpu, string idPat) {
            GetPatientsAreasResult result = this.proxy.GetPatientsAreas(idLpu, idPat, Guid.Parse(this.guid), this.idHistory);
            if (result.Success) {
                return result.PatientsAreaList;
            }
            return null;
        }

        public Spesiality[] GetSpecialities(int idLpu, string idPat) {
            GetSpesialityListResult result = this.proxy.GetSpesialityList(idLpu, idPat, this.guid, this.idHistory);
            if (result.Success) {
                return result.ListSpesiality;
            }
            return null;
        }

        public DateTime[] GetAvailableDates(string idDoc, int idLpu, string idPat, DateTime visitStart, DateTime visitEnd) {
            GetAvailableDatesResult result = proxy.GetAvailableDates(idDoc, idLpu, idPat, visitStart, visitEnd, guid, idHistory);
            if (result.Success) {
                return result.AvailableDateList;
            }
            return null;
        }

        public Appointment[] GetAvailableAppointments(string idDoc, int idLpu, string idPat, DateTime visitStart, DateTime visitEnd) {
            GetAvaibleAppointmentsResult result = proxy.GetAvaibleAppointments(idDoc, idLpu, idPat, visitStart, visitEnd, guid, idHistory);
            if (result.Success) {
                return result.ListAppointments;
            }
            return null;
        }

        public SpecialistType SetAppointment(string idAppointment, int idLpu, string idPat) {
            SetAppointmentResult result = proxy.SetAppointment(idAppointment, idLpu, idPat, null, null, null, guid, idHistory);
            if (result.Success) {
                return result.Type;
            }
            return SpecialistType.отсутстствует_неопределено;
        }
    }
}

