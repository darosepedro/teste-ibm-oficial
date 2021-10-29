using INSS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestINSS
{
    internal class CalculadorInssTestData_Teto : TheoryData<List<InssAliquotaRecord>, InssRepository, DateTime, double>
    {
        //Este valor deve está acima do teto em qualquer tabela
        private double salContribAcimaTeto = 10000; 
        public CalculadorInssTestData_Teto()
        {
            //Cenário 01 - 2011
            Add(Tabelas.GetTabela2011(),
            new InssRepository(),
            new DateTime(2011, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2011
            salContribAcimaTeto); //Salário gera desconto acima do Teto de Contribuição 

            //Cenário 02 - 2012
            Add(Tabelas.GetTabela2012(),
            new InssRepository(),
            new DateTime(2012, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2012
            salContribAcimaTeto); //Salário gera desconto acima do Teto de Contribuição 
        }
    }

    internal class CalculadorInssTestData_PrimeiraFaixa : TheoryData<List<InssAliquotaRecord>, InssRepository, DateTime, double>
    {
        //Este valor deve está abaixo da primeira faixa em todas as tabelas
        private double salContribFaixa01 = 500; 

        public CalculadorInssTestData_PrimeiraFaixa()
        {
            //Cenário 01 - 2011
            Add(Tabelas.GetTabela2011(),
            new InssRepository(),
            new DateTime(2011, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2011
            salContribFaixa01); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 

            //Cenário 02 - 2012
            Add(Tabelas.GetTabela2012(),
            new InssRepository(),
            new DateTime(2012, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2012
            salContribFaixa01); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 
        }
    }

    internal class CalculadorInssTestData_SegundaFaixa : TheoryData<List<InssAliquotaRecord>, InssRepository, DateTime, double>
    {
        //Este valor deve está acima da primeira faixa e abaixo da segunda faixa em todas as tabelas
        private double salContribFaixa02 = 1400;

        public CalculadorInssTestData_SegundaFaixa()
        {
            //Cenário 01 - 2011
            Add(Tabelas.GetTabela2011(),
            new InssRepository(),
            new DateTime(2011, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2011
            salContribFaixa02); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 

            //Cenário 02 - 2012
            Add(Tabelas.GetTabela2012(),
            new InssRepository(),
            new DateTime(2012, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2012
            salContribFaixa02); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 
        }
    }

    internal class CalculadorInssTestData_TerceiraFaixa : TheoryData<List<InssAliquotaRecord>, InssRepository, DateTime, double>
    {
        //Este valor deve está acima da segunda faixa e abaixo da terceira faixa em todas as tabelas
        private double salContribFaixa03 = 2500;

        public CalculadorInssTestData_TerceiraFaixa()
        {
            //Cenário 01 - 2011
            Add(Tabelas.GetTabela2011(),
            new InssRepository(),
            new DateTime(2011, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2011
            salContribFaixa03); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 

            //Cenário 02 - 2012
            Add(Tabelas.GetTabela2012(),
            new InssRepository(),
            new DateTime(2012, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2012
            salContribFaixa03); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 
        }
    }

    internal class CalculadorInssTestData_QuartaFaixa : TheoryData<List<InssAliquotaRecord>, InssRepository, DateTime, double>
    {
        //Este valor deve está acima da terceira faixa e abaixo da quarta faixa em todas as tabelas
        private double salContribFaixa04 = 3800;

        public CalculadorInssTestData_QuartaFaixa()
        {

            //Cenário 01 - 2011
            //Para este cenário não há massa de dados, pois só existe 3 faixas de aliquota nesta tabela

            //Cenário 02 - 2012
            Add(Tabelas.GetTabela2012(),
            new InssRepository(),
            new DateTime(2012, 01, 01), //Data do Pagamento dentro do intervalo da tabela 2012
            salContribFaixa04); //Salário gera desconto dentro da primeira faixa data tabela de Contribuição 
        }
    }
}
