using Moq;
using NUnit.Framework;
using ProjetPourTU.Model;
using ProjetPourTU.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTUTest
{
    class VehiculeServiceTest
    {
        VehiculeService vehiculeService;
        Mock<VehiculeService> mockVehicule;

        List<Vehicule> vehicules = new List<Vehicule>();

        [SetUp]
        public void setUp()
        {
            //vehicules = new List<Vehicule>();
            //vehicules.Add(new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "A" });

            mockVehicule = new Mock<VehiculeService>();
            mockVehicule.CallBase = true;

            mockVehicule.Setup(m => m.getAll())
                .Returns(vehicules);
            mockVehicule.Setup(m => m.Save())
                .Callback(() => vehicules.Add(new Vehicule()));

            vehiculeService = mockVehicule.Object;
        }

        [Test]
        public void CreerMessagePourUnVehiculeTest()
        {
            string expected = "Véhicule : Peugeot 308, immatriculation : AAA";
            string result = vehiculeService.CreerMessagePourUnVehicule(new Vehicule { ID = 1, Immatriculation = "AAA", Nom = "A" });
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddVehiculeTest()
        {
            Vehicule vehiculeTest = new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "A" };
            vehiculeService.AddVehicule(vehiculeTest);

            Assert.AreEqual(1, vehicules.Count);
        }

        //[Test]
        //public void CreerMessageTest()
        //{
        //    string expected = "Véhicule : Peugeot 308, immatriculation : AAA\nVéhicule: Toyota Aygo, immatriculation: BBB\nVéhicule: Renault Clio, immatriculation: CCC";
        //    string result = vehiculeService.CreerMessage();
        //    Assert.AreEqual(expected, result);
        //}
    }
}
