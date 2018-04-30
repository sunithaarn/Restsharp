using System;
using System.Collections.Generic;

namespace ApiTestingPostman
{
    public class Landlord
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public  string trusted { get; set; }
        public string id { get; set; }

        public Landlord(string fname,string lname,string trust)

        {
            firstName = fname;
            lastName = lname;
            trusted = trust;

        }
        public List<Landlord> Landlordlist;
       
    }

    

    
    
}