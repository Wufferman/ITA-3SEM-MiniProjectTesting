using shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ordination_test
{
    [TestClass]
    public class DagligFastTest
    {

        Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

        [TestMethod]
        //TC9
        public void DoegnDosis()
        {
            DagligFast df = new DagligFast(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel, 1, 1, 1, 1);

            Assert.AreEqual(4, df.doegnDosis());

        }

        [TestMethod]
        //TC10
        public void SamletDosis()
        {
            DagligFast df = new DagligFast(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel, 1, 1, 1, 1);

            Assert.AreEqual(16, df.samletDosis());

        }

        [TestMethod]
        //TC11
        public void GetDoser()
        {
            DagligFast df = new DagligFast(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel, 1, 1, 1, 1);

            Assert.AreEqual("[{\"DosisId\":0,\"tid\":\"0001-01-01T06:00:00\",\"antal\":1},{\"DosisId\":0,\"tid\":\"0001-01-01T12:00:00\",\"antal\":1},{\"DosisId\":0,\"tid\":\"0001-01-01T18:00:00\",\"antal\":1},{\"DosisId\":0,\"tid\":\"0001-01-01T23:59:00\",\"antal\":1}]", JsonSerializer.Serialize(df.getDoser()));

        }

        [TestMethod]
        //TC12
        public void TestGetType()
        {
            DagligFast df = new DagligFast(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel, 1, 1, 1, 1);

            Assert.AreEqual("DagligFast", df.getType());

        }

        [TestMethod]
        //TC13
        public void AntalDage()
        {
            DagligFast df = new DagligFast(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel, 1, 1, 1, 1);

            Assert.AreEqual(4, df.antalDage());

        }


    }
}
