using Appointment.Models;
using Appointment.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Controllers
{
    [Route("Patient")]
    [Produces("application/json")]
    public class PatientController : Controller
    {
        private readonly IPatient _patient;

        public PatientController(IPatient patient)
        {
            _patient = patient;
        }

        [HttpGet("GetPatients")]
        public async Task<IActionResult> GetPatients()
        {
            var response = await _patient.GetPatients();
            return Ok(response);
        }

        [HttpGet("GetPatient/{PatientID}")]
        public async Task<IActionResult> GetPatient(int PatientID)
        {
            var response = await _patient.GetPatient(PatientID);
            return Ok(response);
        }

        [HttpPost("SavePatient")]
        public async Task<IActionResult> SavePatient([FromBody] PatientViewModel model)
        {
            var response = await _patient.SavePatient(model);
            return Ok(response);
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientViewModel model)
        {
            var response = await _patient.UpdatePatient(model);
            return Ok(response);
        }

        [HttpDelete("DeletePatient/{PatientID}")]
        public async Task<IActionResult> DeletePatient(int PatientID)
        {
            var response = await _patient.DeletePatient(PatientID);
            return Ok(response);
        }

        [HttpPut("CancelAppointment/{PatientID}")]
        public async Task<IActionResult> CancelAppointment(int PatientID)
        {
            var response = await _patient.CancelAppointment(PatientID);
            return Ok(response);
        }
    }
}
