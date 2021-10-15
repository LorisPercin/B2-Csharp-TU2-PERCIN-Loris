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

        [SetUp]
        public void setUp()
        {
            mockVehicule = new Mock<VehiculeService>();

            vehiculeService = mockVehicule.Object;
        }

        [Test]
        public void CreerMessagePourUnVehiculeTest()
        {
            string expected = "Véhicule : Peugeot 308, immatriculation : AAA";
            string result = vehiculeService.CreerMessagePourUnVehicule(new Vehicule { ID = 1, Immatriculation = "AAA", Nom = "Peugeot 308" });
            Assert.AreEqual(expected, result);
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
