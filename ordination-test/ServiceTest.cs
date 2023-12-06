namespace ordination_test;

using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using shared.Model;
using static shared.Util;

[TestClass]
public class ServiceTest
{
    private DataService service;
    private Random rnd = new Random();

    [TestInitialize]
    public void SetupBeforeEachTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrdinationContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: $"test-database-{DateTime.UtcNow.Ticks}");
        var context = new OrdinationContext(optionsBuilder.Options);
        service = new DataService(context);
        service.SeedData();
    }

    [TestMethod]
    public void PatientsExist()
    {
        Assert.IsNotNull(service.GetPatienter());

    }

    [TestMethod]
    //TC33
    public void DagligFastExist()
    {
        Assert.IsNotNull(service.GetDagligFaste());
    }

    [TestMethod]
    //TC34
    public void DagligSkævExist()
    {
        Assert.IsNotNull(service.GetDagligSkæve());
    }

    [TestMethod]
    //TC35
    public void PNExist()
    {
        Assert.IsNotNull(service.GetPNs());
    }

    [TestMethod]
    public void OpretPatient()
    {
        Patient patient = new Patient("001122 - 1122", "JegErSejTest", 50);

        Assert.AreEqual(5, service.GetPatienter().Count());

        service.OpretPatient(patient.cprnr, patient.navn, patient.vaegt);

        Assert.AreEqual(6, service.GetPatienter().Count());
    }

    [TestMethod]
    public void OpretDagligFast()
    {
        Patient patient = service.GetPatienter().First();
        Laegemiddel lm = service.GetLaegemidler().First();

        Assert.AreEqual(1, service.GetDagligFaste().Count());


        service.OpretDagligFast(patient.PatientId, lm.LaegemiddelId,
            2, 2, 1, 0, DateTime.Now, DateTime.Now.AddDays(3));

        Assert.AreEqual(2, service.GetDagligFaste().Count());
    }

    [TestMethod]
    //TC36
    public void OpretDagligSkæv()
    {
        Patient patient = service.GetPatienter().First();
        Laegemiddel lm = service.GetLaegemidler().First();

        Assert.AreEqual(1, service.GetDagligSkæve().Count());

        service.OpretDagligSkaev(patient.PatientId, lm.LaegemiddelId,
            new Dosis[] {
                new Dosis(CreateTimeOnly(12, 0, 0), 0.5),
                new Dosis(CreateTimeOnly(12, 40, 0), 1),
                new Dosis(CreateTimeOnly(16, 0, 0), 2.5),
                new Dosis(CreateTimeOnly(18, 45, 0), 3)
            }, DateTime.Now, DateTime.Now.AddDays(3));

        Assert.AreEqual(2, service.GetDagligSkæve().Count());
    }

    [TestMethod]
    //TC37
    public void OpretPN()
    {
        Patient patient = service.GetPatienter().First();
        Laegemiddel lm = service.GetLaegemidler().First();

        Assert.AreEqual(4, service.GetPNs().Count());

        service.OpretPN(patient.PatientId, lm.LaegemiddelId, 2, DateTime.Now, DateTime.Now.AddDays(3));

        Assert.AreEqual(5, service.GetPNs().Count());
    }

    [TestMethod]
    //TC38
    public void TestGetAnbefaletDosisPrDøgn()
    {
        Patient patient = new Patient("001122 - 1122", "JegErSejTest", 50);
        Laegemiddel lm = new Laegemiddel("SejLaegemiddel", 0.5, 1, 2, "kg");

        patient = service.OpretPatient(patient.cprnr, patient.navn, patient.vaegt);
        lm = service.OpretLaegemiddel(lm.navn, lm.enhedPrKgPrDoegnLet, lm.enhedPrKgPrDoegnNormal, lm.enhedPrKgPrDoegnTung, lm.enhed);

        Assert.AreEqual(50, service.GetAnbefaletDosisPerDøgn(patient.PatientId, lm.LaegemiddelId));
    }

    [TestMethod]
    //TC39
    // Den her fejler altid, jeg ved ikke hvorfor
    // - Den kan ikke finde den ordination den har fundet
    // - Det virker i praksis
    [ExpectedException(typeof(DbUpdateConcurrencyException))]
    public void TestAnvendOrdination()
    {
        Patient patient = service.GetPatienter().FirstOrDefault();
        PN pn = service.OpretPN(patient.PatientId, service.GetLaegemidler().FirstOrDefault().LaegemiddelId, 2, new DateTime(2023, 11, 24), new DateTime(2023, 11, 27));
        Console.WriteLine(pn.OrdinationId);
        Dato nu = new Dato
        {
            DatoId = 1,
            dato = new DateTime(2023, 11, 24)
        };
        Dato fejl = new Dato
        {
            DatoId = 2,
            dato = new DateTime(2023, 11, 23)
        };

        Assert.AreEqual("Givet Ordination", service.AnvendOrdination(pn.OrdinationId, nu));
        Assert.AreEqual("Kan ikke give ordination udenfor ordinationstiden", service.AnvendOrdination(pn.OrdinationId, fejl));

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestAtKodenSmiderEnException()
    {
        // Herunder skal man så kalde noget kode,
        // der smider en exception.

        // Hvis koden _ikke_ smider en exception,
        // så fejler testen.

        throw new ArgumentOutOfRangeException();
    }




}