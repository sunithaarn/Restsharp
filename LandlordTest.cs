using Newtonsoft.Json;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp.Deserializers;
using System.Collections;

namespace ApiTestingPostman
{
    public class LandlordTest
    {
        Apioperations apiobj = new Apioperations();
        [Test, Order(1)]
        [TestCaseSource("Datalandlords")]
        public void TCPost(string fn, string ln, string trusted)
        {

            Landlord lobj = new Landlord(fn, ln, trusted);
            string Landlorddata = JsonConvert.SerializeObject(lobj);
            IRestResponse Postresult = apiobj.Post(Landlorddata);

            IRestResponse getresult = apiobj.GetAll();
            ArrayList ld = new ArrayList();

            JArray lists = JArray.Parse(getresult.Content);
            int lng = lists.Count;

           // Console.Error.Write(lng);

            if (lng > 0)
            {
                lng = lng - 1;
                //Console.Error.Write(lng);
               // Console.Error.Write(lists[lng].ToString());
                ld.Add(lists[lng].ToString());
                int ldcount = ld.Count;
              //  Console.Error.Write(ldcount);
               string Details = (string)ld[0];
                //Console.Error.Write(ld[lng]);

                Landlord expected = JsonConvert.DeserializeObject<Landlord>(Details);
                Assert.AreEqual(expected.firstName, fn);
                Assert.AreEqual(expected.lastName, ln);
                Assert.AreEqual(expected.trusted, trusted);
            }
        }

            private static IEnumerable<string[]> Datalandlords()
            {
                using (var csvfile = new CsvReader(new StreamReader("C:\\Users\\CC-MTR\\Desktop\\data.csv"), true))
                {
                    while (csvfile.ReadNextRecord())
                    {
                        string fname = csvfile[0];
                        string lname = csvfile[1];
                        string trus = csvfile[2];
                        yield return new[] { fname, lname, trus };

                    }
                }

            } 
       [Test,Order(2)]
        [TestCase]
        public void TCGetDeleteAll()
        {
            IRestResponse getresult = apiobj.GetAll();
            ArrayList ld = new ArrayList();
            JArray lists = JArray.Parse(getresult.Content);
                       
            for (int i = 0; i < lists.Count; i++)
            {
                ld.Add(lists[i].ToString());
                string one = (string)ld[i];
               Landlord expected = JsonConvert.DeserializeObject<Landlord>(one);
               IRestResponse DelResult = apiobj.DeletebyId(expected.id);
              // string Expect = DelResult.ResponseStatus;
                //string Actual= "{""message"/ : LandLord with id: " + expected.id+" successfully deleted}";
                                
               // Assert.AreSame(Expect, Actual);
            }

            IRestResponse getresult2 = apiobj.GetAll();
             string Actres=getresult2.Content;
            Assert.AreEqual(Actres, "[]");

        }

               

    }
}
