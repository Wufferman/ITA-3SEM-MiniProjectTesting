using shared.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordination_test
{
    [TestClass]
    public class DosisTest
    {

        [TestMethod]
        //TC8
        public void TestToString()
        {
            Dosis dosis = new Dosis(new DateTime(2023, 11, 24, 9, 50, 00), 2);

            Assert.AreEqual("Kl: 09.50.00    antal:  2", dosis.ToString());
        }
    }
}
