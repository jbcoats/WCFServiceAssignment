using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFServiceAssignment" in both code and config file together.
[ServiceContract]
public interface IWCFServiceAssignment
{
    [OperationContract]
    int Login(string email, string password);

    [OperationContract]
    bool RegisterRequester(Requester r);

    [OperationContract]
    bool RequestGrant(Request req);

    [OperationContract]
    List<GrantRequest> GetGrantRequests(int personKey);
}

[DataContract]
public class Request
{
    [DataMember]
    public int GrantType { get; set; }

    [DataMember]
    public string GrantRequestExplansion { get; set; }

    [DataMember]
    public decimal GrantRequestAmount { get; set; }

    [DataMember]
    public int PersonKey { get; set; }
}

[DataContract]
public class Requester
{
    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string Email { get; set; }

    [DataMember]
    public string Password { get; set; }

    [DataMember]
    public string Apartment { get; set; }

    [DataMember]
    public string Street { get; set; }

    [DataMember]
    public string City { get; set; }

    [DataMember]
    public string State { get; set; }

    [DataMember]
    public string Zipcode { get; set; }

    [DataMember]
    public string HomePhone { get; set; }

    [DataMember]
    public string WorkPhone { get; set; }
}

