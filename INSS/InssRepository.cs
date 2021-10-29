using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class InssRepository : IInssRepository
    {

        //private List<InssAliquotaRecord> data = new List<InssAliquotaRecord>();

        public List<InssAliquotaRecord> Get()
        {
            return Data.aliquotas;
        }

        public double GetTetoDesconto(int ano)
        {
            var recAliquota = Data.aliquotas.Where(w => w.Ano == ano).OrderBy(o => o.Aliquota).LastOrDefault();
            return recAliquota.SalarioContribuicao.AsValorContribuicao((double)recAliquota.Aliquota);
        }

        public decimal GetAliquota(DateTime dataRequest, double salarioContribuicao)
        {

            if (Data.aliquotas.Count() == 0)
                throw new Exception("Não existe alíquotas cadastradas!");

            var inssAliquotaRecords = Data.aliquotas.Where(w =>
                w.Ano == dataRequest.Year
            ).OrderBy(o => o.Aliquota);

            if (inssAliquotaRecords.Count() == 0)
                throw new Exception("Não há alíquota cadastrada para este período!");

            var inssAliquotaRecord = inssAliquotaRecords.Where(w => w.SalarioContribuicao >= salarioContribuicao).FirstOrDefault();

            return inssAliquotaRecord == null ? Constants.TETO : inssAliquotaRecord.Aliquota;


        }

        public void PostNewTable(List<InssAliquotaRecord> newTable)
        {
            Data.aliquotas.AddRange(newTable);
        }
    }
}
