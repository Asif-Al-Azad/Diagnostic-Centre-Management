using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticCenterManagement
{
    public static class PatientSession
    {
        public static int PatientId = 0;
        public static string PatientName = "";
        public static string Phone = "";

        public static bool IsLoggedIn = false;

        public static void Logout()
        {
            PatientId = 0;
            PatientName = "";
            Phone = "";
            IsLoggedIn = false;
        }
    }
}
