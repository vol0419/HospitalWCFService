using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HospitalWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Insert(InserPatient patient);
        [OperationContract]
        getData GetData();
        [OperationContract]
        string Update(UpdatePatient p);
        [OperationContract]
        string Delete(DeletePatient p);

        [OperationContract]
        string Add(AddVisit visit);
        [OperationContract]
        getVisits GetVisits(int patientID);
        [OperationContract]
        string DelVisit(DeleteVisit v);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class DeleteVisit
    {
        [DataMember]
        public int Vid { get; set; }
    }


    [DataContract]
    public class getVisits
    {

        [DataMember]
        public DataTable visitsTable { get; set; }
    }

    [DataContract]
    public class AddVisit
    {
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public string Recognition { get; set; }
        [DataMember]
        public string Recommendation { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Doctor { get; set; }
    }


    [DataContract]
    public class DeletePatient
    {
        [DataMember]
        public int Pid { get; set; }
    }

    [DataContract]
    public class UpdatePatient
    {

        [DataMember]
        public int Pid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public DateTime Birthdate { get; set; }
        [DataMember]
        public int Pesel { get; set; }
        [DataMember]
        public int Phone { get; set; }
    }

    [DataContract]
    public class getData
    {
        [DataMember]
        public DataTable patientsTable { get; set; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InserPatient
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public int Pesel { get; set; }

        [DataMember]
        public DateTime Birthdate { get; set; }

        [DataMember]
        public int Phone { get; set; }
    }
}
