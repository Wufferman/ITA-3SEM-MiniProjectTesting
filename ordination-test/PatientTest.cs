namespace ordination_test;

using shared.Model;

[TestClass]
public class PatientTest
{

    [TestMethod]
    public void PatientHasName()
    {
        string cpr = "160563-1234";
        string navn = "John";
        double vægt = 83;
        
        Patient patient = new Patient(cpr, navn, vægt);
        Assert.AreEqual(navn, patient.navn);
    }


    //[TestMethod]
    //public void TestDerAltidFejler()
    //{
    //    string cpr = "160563-1234";
    //    string navn = "John";
    //    double vægt = 83;

    //    Patient patient = new Patient(cpr, navn, vægt);
    //    Assert.AreEqual("Egon", patient.navn);
    //}

    [TestMethod]
    //TC1
    public void PatientToString()
    {
        Patient patient = new Patient("10180-2223", "Jeff", 75);
        Assert.AreEqual(patient.ToString(), "Jeff 10180-2223");
    }
}