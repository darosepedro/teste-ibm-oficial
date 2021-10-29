using INSS;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestINSS
{

    public class CalculadorInssTest
    {
       
        [Theory]
        [ClassData(typeof(CalculadorInssTestData_Teto))]
        public void Testes_AcimaTeto(
            List<InssAliquotaRecord> massa, 
            IInssRepository inssRepository, 
            DateTime dataPagto, 
            double salContrib)
        {
            //Instancia a classe responsável pelo cálculo
            ICalculadorInss calculadorInss = new CalculadorInss(inssRepository);
            
            //Alimenta as tabelas
            inssRepository.PostNewTable(massa);

            //Captura o valor máximo permitido para desconto (Teto)
            var vrDescEsperado = inssRepository.GetTetoDesconto(dataPagto.Year);

            //Solicita o cálculo do valor a ser descontado
            var vrDescCalculado = calculadorInss.CalcularDesconto(dataPagto, salContrib);

            //Valida a regra de negócio
            Assert.Equal(vrDescEsperado, vrDescCalculado);
        }


        [Theory]
        [ClassData(typeof(CalculadorInssTestData_PrimeiraFaixa))]
        public void Testes_PrimeiraFaixa(
            List<InssAliquotaRecord> massa,
            IInssRepository inssRepository,
            DateTime dataPagto,
            double salContrib)
        {
            //Instancia a classe responsável pelo cálculo
            ICalculadorInss calculadorInss = new CalculadorInss(inssRepository);

            //Alimenta as tabelas
            inssRepository.PostNewTable(massa);

            //Captura a aliquota para a faixa que está sendo testada
            var aliquotaEsperada = (double)massa.First().Aliquota;

            //Captura o valor máximo permitido para desconto (Teto)
            var vrDescEsperado =  salContrib.AsValorContribuicao(aliquotaEsperada);

            //Solicita o cálculo do valor a ser descontado
            var vrDescCalculado = calculadorInss.CalcularDesconto(dataPagto, salContrib);

            //Valida a regra de negócio
            Assert.Equal(vrDescEsperado, vrDescCalculado);
        }

        [Theory]
        [ClassData(typeof(CalculadorInssTestData_SegundaFaixa))]
        public void Testes_SegundaFaixa(
            List<InssAliquotaRecord> massa,
            IInssRepository inssRepository,
            DateTime dataPagto,
            double salContrib)
        {
            //Instancia a classe responsável pelo cálculo
            ICalculadorInss calculadorInss = new CalculadorInss(inssRepository);

            //Alimenta as tabelas
            inssRepository.PostNewTable(massa);

            //Captura a aliquota para a faixa que está sendo testada
            var aliquotaEsperada = (double)massa.Take(2).OrderBy(o=>o.SalarioContribuicao).Last().Aliquota;

            //Captura o valor máximo permitido para desconto (Teto)
            var vrDescEsperado = salContrib.AsValorContribuicao(aliquotaEsperada);

            //Solicita o cálculo do valor a ser descontado
            var vrDescCalculado = calculadorInss.CalcularDesconto(dataPagto, salContrib);

            //Valida a regra de negócio 
            Assert.Equal(vrDescEsperado, vrDescCalculado);
        }

        [Theory]
        [ClassData(typeof(CalculadorInssTestData_TerceiraFaixa))]
        public void Testes_TerceiraFaixa(
            List<InssAliquotaRecord> massa,
            IInssRepository inssRepository,
            DateTime dataPagto,
            double salContrib)
        {
            //Instancia a classe responsável pelo cálculo
            ICalculadorInss calculadorInss = new CalculadorInss(inssRepository);

            //Alimenta as tabelas
            inssRepository.PostNewTable(massa);

            //Captura a aliquota para a faixa que está sendo testada
            var aliquotaEsperada = (double)massa.Take(3).OrderBy(o => o.SalarioContribuicao).Last().Aliquota;

            //Captura o valor máximo permitido para desconto (Teto)
            var vrDescEsperado = salContrib.AsValorContribuicao(aliquotaEsperada);

            //Solicita o cálculo do valor a ser descontado
            var vrDescCalculado = calculadorInss.CalcularDesconto(dataPagto, salContrib);

            //Valida a regra de negócio
            Assert.Equal(vrDescEsperado, vrDescCalculado);
        }

        [Theory]
        [ClassData(typeof(CalculadorInssTestData_QuartaFaixa))]
        public void Testes_QuartaFaixa(
            List<InssAliquotaRecord> massa,
            IInssRepository inssRepository,
            DateTime dataPagto,
            double salContrib)
        {
            //Instancia a classe responsável pelo cálculo
            ICalculadorInss calculadorInss = new CalculadorInss(inssRepository);

            //Alimenta as tabelas
            inssRepository.PostNewTable(massa);

            //Captura a aliquota para a faixa que está sendo testada
            var aliquotaEsperada = (double)massa.Take(4).OrderBy(o => o.SalarioContribuicao).Last().Aliquota;

            //Captura o valor máximo permitido para desconto (Teto)
            var vrDescEsperado = salContrib.AsValorContribuicao(aliquotaEsperada);

            //Solicita o cálculo do valor a ser descontado
            var vrDescCalculado = calculadorInss.CalcularDesconto(dataPagto, salContrib);

            //Valida a regra de negócio
            Assert.Equal(vrDescEsperado, vrDescCalculado);
        }




    }
}
