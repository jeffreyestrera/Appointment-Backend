using Appointment.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context.Appointment;
using Appointment.Models;
using Microsoft.EntityFrameworkCore;
using Context.Appointment.Entities;

namespace Appointment.Services
{
    public class PatientService : IPatient
    {
        private readonly AppointmentContext _appointmentContext;

        public PatientService(AppointmentContext appointmentContext)
        {
            _appointmentContext = appointmentContext;
        }

        public async Task<List<PatientViewModel>> GetPatients()
        {
            return await _appointmentContext.Patient
                .Select(a => new PatientViewModel
                {
                    PatientID = a.PatientID,
                    PatientName = a.PatientName,
                    AppointmentSchedule = a.AppointmentSchedule,
                    Status = a.Status
                })
                .ToListAsync();
        }

        public async Task<PatientViewModel> GetPatient(int PatientID)
        {
            return await _appointmentContext.Patient
                .Select(a => new PatientViewModel
                {
                    PatientID = a.PatientID,
                    PatientName = a.PatientName,
                    AppointmentSchedule = a.AppointmentSchedule,
                    Status = a.Status
                })
                .Where(a => a.PatientID == PatientID)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SavePatient(PatientViewModel model)
        {
            try
            {
                Patient patient = new();
                patient.PatientName = model.PatientName;
                patient.AppointmentSchedule = model.AppointmentSchedule;
                patient.Status = "Approved";

                _appointmentContext.Add(patient);

                await _appointmentContext.SaveChangesAsync();

                var response = await _appointmentContext.Patient.FirstOrDefaultAsync(a => a.PatientID == model.PatientID);

                return patient.PatientID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdatePatient(PatientViewModel model)
        {
            try
            {
                var patient = await _appointmentContext.Patient.FindAsync(model.PatientID);

                patient.PatientName = model.PatientName;
                patient.AppointmentSchedule = model.AppointmentSchedule;
                patient.Status = "Approved";

                _appointmentContext.Update(patient);

                await _appointmentContext.SaveChangesAsync();

                var response = await _appointmentContext.Patient.FirstOrDefaultAsync(a => a.PatientID == model.PatientID);

                return response.PatientID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeletePatient(int PatientID)
        {
            try
            {
                var patient = await _appointmentContext.Patient.FindAsync(PatientID);

                if (patient == null)
                    return 0;

                _appointmentContext.Remove(patient);

                await _appointmentContext.SaveChangesAsync();

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CancelAppointment(int PatientID)
        {
            try
            {
                var patient = await _appointmentContext.Patient.FindAsync(PatientID);

                patient.Status = "Cancelled";

                _appointmentContext.Update(patient);

                await _appointmentContext.SaveChangesAsync();

                var response = await _appointmentContext.Patient.FirstOrDefaultAsync(a => a.PatientID == PatientID);

                return response.PatientID;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
