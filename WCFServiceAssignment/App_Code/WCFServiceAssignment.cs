using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFServiceAssignment" in code, svc and config file together.
public class WCFServiceAssignment : IWCFServiceAssignment
{
    Community_AssistEntities db = new Community_AssistEntities();

    public List<GrantRequest> GetGrantRequests(int personKey)
    {
        var grants = from g in db.GrantRequests
                     where g.PersonKey == personKey
                     select g;
        List<GrantRequest> requests = new List<GrantRequest>();
        foreach(var gr in grants)
        {
            GrantRequest grt = new GrantRequest();
            grt.GrantRequestKey = gr.GrantRequestKey;
            grt.GrantRequestDate = gr.GrantRequestDate;
            grt.PersonKey = gr.PersonKey;
            grt.GrantTypeKey = gr.GrantTypeKey;
            grt.GrantRequestExplanation = gr.GrantRequestExplanation;
            grt.GrantRequestAmount = gr.GrantRequestAmount;
            requests.Add(grt);
        }
        return requests;
    }

    public int Login(string email, string password)
    {
        int key = 0;
        int result = db.usp_Login(email, password);
        if (result != -1)
        {
            var requesterKey = (from k in db.People
                                where k.PersonEmail.Equals(email)
                                select k.PersonKey).FirstOrDefault();
            key = (int)requesterKey;
        }
        return key;
    }

    public bool RegisterRequester(Requester r)
    {
        bool result = true;
        int res = db.usp_Register(r.LastName, r.FirstName, r.Email, r.Password, r.Street,
            r.Apartment, r.City, r.State, r.Zipcode, r.HomePhone, r.WorkPhone);
        if (res == -1)
        {
            result = false;
        }
        return result;
    }

    public bool RequestGrant(Request req)
    {
        bool result = true;
        int res = db.usp_AddRequest(req.GrantType, req.GrantRequestExplansion,
            req.GrantRequestAmount, req.PersonKey);
        if (res == -1)
        {
            result = false;
        }
        return result;
    }
}
