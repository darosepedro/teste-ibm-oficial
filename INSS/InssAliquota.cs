using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class InssAliquotaRecord
    {
        public int Ano { get; set; }
        public decimal Aliquota { get; set; }
        public double SalarioContribuicao { get; set; }

        public InssAliquotaRecord(int ano, decimal aliquota, double salarioContribuicao)
        {
            this.Aliquota = aliquota;
            this.Ano = ano;
            this.SalarioContribuicao = salarioContribuicao;
        }
    }
}
