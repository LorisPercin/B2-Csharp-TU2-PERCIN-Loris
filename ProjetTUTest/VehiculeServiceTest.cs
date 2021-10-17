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

        List<Vehicule> listeVehicules = new List<Vehicule>();

        [SetUp]
        public void setUp()
        {
            listeVehicules = new List<Vehicule>();
            mockVehicule = new Mock<VehiculeService>();

            mockVehicule.Setup(m => m.getAll())
                .Returns(listeVehicules);
            mockVehicule.Setup(m => m.Save());

            vehiculeService = mockVehicule.Object;
        }

        [Test]
        public void CreerMessagePourUnVehiculeTest()
        {
            string expected = "Véhicule : A, immatriculation : AAA";
            string result = vehiculeService.CreerMessagePourUnVehicule(new Vehicule { ID = 1, Immatriculation = "AAA", Nom = "A" });
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddVehiculeTest()
        {
            Vehicule vehiculeTest = new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "A" };
            vehiculeService.AddVehicule(vehiculeTest);

            Assert.AreEqual(1, listeVehicules.Count);
            Assert.AreEqual(1, listeVehicules[0].ID);
            Assert.AreEqual("AAA", listeVehicules[0].Immatriculation);
            Assert.AreEqual("A", listeVehicules[0].Nom);
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
