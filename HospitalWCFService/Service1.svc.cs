using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HospitalWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public getVisits GetVisits(int patientID)
        {
            getVisits data = new getVisits();
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Visits where PatientID = @PatientID", conn);
            cmd.Parameters.AddWithValue("@PatientID", patientID);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("mytab2");
            adapter.Fill(dataTable);
            data.visitsTable = dataTable;
            conn.Close();
            return data;

        }

        public string Add(AddVisit visit)
        {
            string msg;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Visits (PatientID,Recognition,Recommendation,Date,Doctor) values (@PatientID, @Recognition, @Recommendation, @Date, @Doctor)", conn);
            cmd.Parameters.AddWithValue("@PatientID", visit.PatientID);
            cmd.Parameters.AddWithValue("@Recognition", visit.Recognition);
            cmd.Parameters.AddWithValue("@Recommendation", visit.Recognition);
            cmd.Parameters.AddWithValue("@Date", visit.Date);
            cmd.Parameters.AddWithValue("@Doctor", visit.Doctor);

            int insertion = cmd.ExecuteNonQuery();
            if (insertion == 1)
            {
                msg = "Success insertion";
            }
            else
            {
                msg = "Fail insertion";
            }

            conn.Close();
            return msg;

        }

        public string DelVisit(DeleteVisit v)
        {
            string msg = "";
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Visits where VisitID = @VisitID", conn);
            cmd.Parameters.AddWithValue("VisitID", v.Vid);
            int operation = cmd.ExecuteNonQuery();
            if (operation == 1)
            {
                msg = "Success deleted";
            }
            else
            {
                msg = "Fail deleted";
            }

            conn.Close();
            return msg;
        }

        public string Delete(DeletePatient patient)
        {
            string msg = "";
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from Patients where PatientID = @PatientID", conn);
            cmd.Parameters.AddWithValue("PatientID", patient.Pid);
            int operation = cmd.ExecuteNonQuery();
            if (operation == 1)
            {
                msg = "Success deleted";
            }
            else
            {
                msg = "Fail deleted";
            }

            conn.Close();
            return msg;
        }

        public string Update(UpdatePatient patient)
        {
            string msg = "";
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Patients set Name = @Name, Surname = @Surname, Birthdate = @Birthdate, Phone = @Phone, Pesel = @Pesel where PatientID = @PatientID", conn);
            cmd.Parameters.AddWithValue("@PatientID", patient.Pid);
            cmd.Parameters.AddWithValue("@Name", patient.Name);
            cmd.Parameters.AddWithValue("@Surname", patient.Surname);
            cmd.Parameters.AddWithValue("@Pesel", patient.Pesel);
            cmd.Parameters.AddWithValue("@Birthdate", patient.Birthdate);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);
            int operation = cmd.ExecuteNonQuery();
            if (operation == 1)
            {
                msg = "Success update";
            }
            else
            {
                msg = "Fail update";
            }

            conn.Close();
            return msg;
        }

        public getData GetData()
        {
            getData data = new getData();
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Patients", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("mytab");
            adapter.Fill(dataTable);
            data.patientsTable = dataTable;
            conn.Close();
            return data; 

        }

        public string Insert(InserPatient patient)
        {
            string msg;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWCF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Patients (Name,Surname,Pesel,Birthdate,Phone) values (@Name, @Surname, @Pesel, @Birthdate, @Phone)", conn);
            cmd.Parameters.AddWithValue("@Name", patient.Name);
            cmd.Parameters.AddWithValue("@Surname", patient.Surname);
            cmd.Parameters.AddWithValue("@Pesel", patient.Pesel);
            cmd.Parameters.AddWithValue("@Birthdate", patient.Birthdate);
            cmd.Parameters.AddWithValue("@Phone", patient.Phone);

            int insertion = cmd.ExecuteNonQuery();
            if( insertion == 1)
            {
                msg = "Success insertion";
            }
            else
            {
                msg = "Fail insertion";
            }

            conn.Close();
            return msg;

        }

        
    }
}
