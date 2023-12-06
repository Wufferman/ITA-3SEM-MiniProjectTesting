using shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordination_test
{
    [TestClass]
    public class DagligSkaevTest
    {
        Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //TC14
        public void TestOpretDosisThrowInvalidNegative1()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            ds.opretDosis(new DateTime(2023, 11, 25), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //TC15
        public void TestOpretDosisThrowInvalidZero()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            ds.opretDosis(new DateTime (2023, 11, 25), 0);
        }

        [TestMethod]
        //TC16
        //TC18
        //TC19
        public void TestOpretDosis()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            ds.opretDosis(new DateTime(2023, 11, 25), 2);
            ds.opretDosis(new DateTime(2023, 11, 24), 2);
            ds.opretDosis(new DateTime(2023, 11, 27), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //TC17
        public void TestOpretDosisThrowBeforeDate()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            ds.opretDosis(new DateTime(2023, 11, 23), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        //TC20
        public void TestOpretDosisThrowAfterDate()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            ds.opretDosis(new DateTime(2023, 11, 28), 1);
        }

        [TestMethod]
        //TC21
        public void TestDoegnDosis()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);

            Assert.AreEqual(1, ds.doegnDosis());
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            Assert.AreEqual(2, ds.doegnDosis());

        }

        [TestMethod]
        //TC22
        public void TestSamletDosis()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);

            Assert.AreEqual(4, ds.samletDosis());
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            ds.opretDosis(new DateTime(2023, 11, 25), 1);
            Assert.AreEqual(8, ds.samletDosis());
        }

        [TestMethod]
        //TC23
        public void TestAntalDage()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            Assert.AreEqual(4, ds.antalDage());


        }

        [TestMethod]
        //TC24
        public void TestToString()
        {
            List<Dosis> dosiser = new List<Dosis>() { new Dosis(new DateTime(2023, 11, 25), 2), new Dosis(new DateTime(2023, 11, 26), 2) };
            DagligSkæv ds = new DagligSkæv(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), testMiddel);

            Assert.AreEqual("DagligSkæv", ds.getType());


        }

    }
}
