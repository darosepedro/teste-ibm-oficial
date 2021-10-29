using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public interface IInssRepository
    {
        decimal GetAliquota(DateTime data, double salario);
        double GetTetoDesconto(int ano);
        void PostNewTable(List<InssAliquotaRecord> newTable);
        List<InssAliquotaRecord> Get();
        
    }
}
