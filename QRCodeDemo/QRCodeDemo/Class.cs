using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRCodeDemo
{
    class Class
    {
        // bit TRUE = 1 and FALSE = 0
        //public static string con = "Data Source=LAPTOP-0QBJ070A; Database=DBQRCode; Integrated Security=True;";
        public static string tublecon = @"Data Source=EUNICE;Initial Catalog=DBdjaas;Integrated Security=True";
        public static byte[] Picture;
        public static bool GenerateRegister = false, isLogged = false;

        //////////////////////////////////////////////////

        // FormAddWorkers Collection Error
        public static string contsplitspace;
        public static string[] contspittuble;
        public static string[] contfirsttuble;
        public static string[] contsecondthirdtuble;
        public static string[] contfirstandfirsttuble;

        public static string emersplitspace;
        public static string[] emerspittuble;
        public static string[] emerfirsttuble;
        public static string[] emersecondthirdtuble;
        public static string[] emerfirstandfirsttuble;


        public static int AddWorkersCollectionError = 0;
        public static string AddWorkerCollectionStatusError;
        
        //////////////////////////////////////////////////

        //Edit Attendance
        public static string WorkersID;

        //////////////////////////////////////////////////

        public static string UserSearchPair, PasswordSearchPair, GenerateQRCode, EmployeeID, EmployeePassword, Gender;
    }
}
