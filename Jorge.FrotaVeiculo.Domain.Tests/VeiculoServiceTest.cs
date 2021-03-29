using Jorge.FrotaVeiculo.Data.Repositories;
using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using Jorge.FrotaVeiculo.Domain.Interfaces.Services;
using Jorge.FrotaVeiculo.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jorge.FrotaVeiculo.Domain.Tests
{
    [TestClass]
    public class VeiculoServiceTest
    {
        IVeiculoService veiculoService;
        IVeiculoRepository veiculoRepository;
        [TestInitialize]
        public void Setup()
        {
            veiculoRepository = new VeiculoRepository();
            veiculoService = new VeiculoService(veiculoRepository);
        }

        [TestMethod]
        public void Add_Test()
        {
            var veiculo = new Veiculo()
            {
                Chassi = new Random().Next(1111, 99999999).ToString(),
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };

            var veiculoAdd = veiculoService.Add(veiculo);

            var veiculoById = veiculoService.GetById(veiculoAdd.Id);

            Assert.IsTrue(veiculoAdd.Id == veiculoById.Id);

            veiculoService.Remove(veiculoById.Id);
        }

        [TestMethod]
        public void Update_Test()
        {
            var veiculo = new Veiculo()
            {
                Chassi = new Random().Next(1111, 99999999).ToString(),
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };

            var veiculoAdd = veiculoService.Add(veiculo);
            var veiculoById = veiculoService.GetById(veiculoAdd.Id);
            Assert.IsTrue(veiculoById != null && veiculoById.Cor == "Cinza");


            veiculoService.Update(veiculo.Chassi, "Azul");

            veiculoById = veiculoService.GetById(veiculoAdd.Id);
            Assert.IsTrue(veiculoById != null && veiculoById.Cor == "Azul");

            veiculoService.Remove(veiculoById.Id);
        }

        [TestMethod]
        public void Add_SameChassi_Test()
        {
            var chassi = new Random().Next(1111, 99999999).ToString();
            var veiculo = new Veiculo()
            {
                Chassi = chassi,
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };

            veiculoService.Add(veiculo);

            var veiculo2 = new Veiculo()
            {
                Chassi = chassi,
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };
            try
            {
                veiculoService.Add(veiculo2);
                Assert.Fail();
            } catch(Exception e)
            {
                Assert.IsTrue(e.Message == "Já existe um veículo com esse chassi.");
                veiculoService.Remove(veiculo.Id);
            }
        }

        [TestMethod]
        public void Remove_Test()
        {
            var chassi = new Random().Next(1111, 99999999).ToString();
            var veiculo = new Veiculo()
            {
                Chassi = chassi,
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };

            var veiculoId = veiculoService.Add(veiculo).Id;

            Assert.IsTrue(veiculoService.GetById(veiculoId) != null);

            veiculoService.Remove(chassi);

            Assert.IsTrue(veiculoService.GetById(veiculoId) == null);
        }

        [TestMethod]
        public void Remove_WrongChassi_Test()
        {
            var chassi = new Random().Next(1111, 99999999).ToString();
            var veiculo = new Veiculo()
            {
                Chassi = chassi,
                Cor = "Cinza",
                Tipo = Enums.ETipoVeiculo.Caminhao,
            };

            var veiculoId = veiculoService.Add(veiculo).Id +10;
            try
            {
                veiculoService.Remove(chassi+1290741702412);
            }catch(Exception e)
            {
                Assert.IsTrue(e.Message == "Chassi informado não existe");
            }


            
        }
    }
}
