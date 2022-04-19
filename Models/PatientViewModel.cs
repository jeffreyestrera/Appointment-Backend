using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Models
{
    public class PatientViewModel
    {
        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public string Status { get; set; }

        public DateTime AppointmentSchedule { get; set; }
    }
}
