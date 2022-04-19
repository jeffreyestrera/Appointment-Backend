using Appointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Services.Interface
{
    public interface IPatient
    {
        Task<List<PatientViewModel>> GetPatients();

        Task<PatientViewModel> GetPatient(int PatientID);

        Task<int> SavePatient(PatientViewModel model);

        Task<int> UpdatePatient(PatientViewModel model);

        Task<int> DeletePatient(int PatientID);

        Task<int> CancelAppointment(int PatientID);
    }
}
