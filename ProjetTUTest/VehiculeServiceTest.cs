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
        public void CreerMessageTest()
        {
            string expected = "Véhicule : A, immatriculation : AAA\nVéhicule : B, immatriculation : BBB\nVéhicule : C, immatriculation : CCC";
            string result = vehiculeService.CreerMessage();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddVehiculeTest()
        {
            Vehicule vehiculeTest = new Vehicule() { ID = 4, Immatriculation = "CCC", Nom = "C" };
            vehiculeService.AddVehicule(vehiculeTest);

            Assert.AreEqual(4, listeVehicules.Count);
            Assert.AreEqual(4, listeVehicules[3].ID);
            Assert.AreEqual("CCC", listeVehicules[3].Immatriculation);
            Assert.AreEqual("C", listeVehicules[3].Nom);
        }
    }
}
