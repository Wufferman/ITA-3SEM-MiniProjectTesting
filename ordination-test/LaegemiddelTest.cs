using shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordination_test
{
    [TestClass]
    public class LaegemiddelTest
    {

        [TestMethod]
        //TC2
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetFactorFromWeightNegativeValues()
        {
            Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

            testMiddel.GetFactorFromWeight(-1);

        }

        [TestMethod]
        //TC3
        public void GetFactorFromWeightLet()
        {
            Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

            Assert.AreEqual(0.5, testMiddel.GetFactorFromWeight(24));

        }
        [TestMethod]
        //TC4
        //TC5
        public void GetFactorFromWeightNormal()
        {
            Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

            Assert.AreEqual(1, testMiddel.GetFactorFromWeight(25));
            Assert.AreEqual(1, testMiddel.GetFactorFromWeight(120));

        }

        [TestMethod]
        //TC6
        public void GetFactorFromWeightTung()
        {
            Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

            Assert.AreEqual(2, testMiddel.GetFactorFromWeight(121));

        }

        [TestMethod]
        //TC7
        public void TestToString()
        {
            Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

            Assert.AreEqual("testMiddel", testMiddel.ToString());

        }
    }
}
