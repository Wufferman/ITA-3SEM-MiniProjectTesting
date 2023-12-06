using shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordination_test
{
    [TestClass]
    public class PNTest
    {
        Laegemiddel testMiddel = new Laegemiddel("testMiddel", 0.5, 1, 2, "testpille");

        [TestMethod]
        //TC25
        //TC28
        public void TestGivDosisOutOfDate()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26)}
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            Assert.IsFalse(pn.givDosis(new Dato
            {
                dato = new DateTime(2023, 11, 23)
            }));

            Assert.IsFalse(pn.givDosis(new Dato
            {
                dato = new DateTime(2023, 11, 28)
            }));

        }

        [TestMethod]
        //TC26
        //TC27
        public void TestGivDosis()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26)}
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            Assert.IsTrue(pn.givDosis(new Dato
            {
                dato = new DateTime(2023, 11, 24)
            }));

            Assert.IsTrue(pn.givDosis(new Dato
            {
                dato = new DateTime(2023, 11, 27)
            }));

        }

        [TestMethod]
        //TC29
        public void TestDoegnDosis()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26) }
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            Assert.AreEqual(2, pn.doegnDosis());
        }

        [TestMethod]
        //TC30
        public void TestSamletDosis()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26) }
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            pn.givDosis(new Dato
            {
                dato = new DateTime(2023, 11, 27)
            });

            Assert.AreEqual(6, pn.samletDosis());
        }

        [TestMethod]
        //TC31
        public void TestAntalDage()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26) }
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            Assert.AreEqual(4, pn.antalDage());
        }

        [TestMethod]
        //TC32
        public void TestGetType()
        {
            List<Dato> dates = new List<Dato>()
            {
                new Dato{ dato = new DateTime(2023, 11,25) },
                new Dato{ dato = new DateTime(2023, 11, 26) }
            };
            PN pn = new PN(new DateTime(2023, 11, 24), new DateTime(2023, 11, 27), 2, testMiddel);

            pn.dates = dates;

            Assert.AreEqual("PN", pn.getType());
        }
    }
}
