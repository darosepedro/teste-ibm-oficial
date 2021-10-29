using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public static class Constants
    {
        public static int TETO = 99;
    }

    public static class Extensions
    {
        public static double AsValorContribuicao(this double salarioContribuicao, double aliquota)
        {
            return Math.Round(aliquota * salarioContribuicao / 100, 2);
        }
    }

    public static class Data
    {
        public static List<InssAliquotaRecord> aliquotas = new List<InssAliquotaRecord>();
    }

}
