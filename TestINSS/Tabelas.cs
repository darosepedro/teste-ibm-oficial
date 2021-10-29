using INSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestINSS
{
    public static class Tabelas
    {
        public static List<InssAliquotaRecord> GetTabela2011()
        {
            return new List<InssAliquotaRecord>()
            {
                new InssAliquotaRecord(2011, 08, 1106.90),
                new InssAliquotaRecord(2011, 09, 1844.83),
                new InssAliquotaRecord(2011, 11, 3689.99)
            };
        }

        public static List<InssAliquotaRecord> GetTabela2012()
        {
            return new List<InssAliquotaRecord>()
            {
                new InssAliquotaRecord(2012, 07, 1000.00),
                new InssAliquotaRecord(2012, 08, 1500.00),
                new InssAliquotaRecord(2012, 09, 3000.00),
                new InssAliquotaRecord(2012, 11, 4000.00)
            };
        }
    }
}
