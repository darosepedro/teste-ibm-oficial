using System;

namespace INSS
{
    public class CalculadorInss: ICalculadorInss
	{
        private readonly IInssRepository _inssRepository;
        public CalculadorInss(IInssRepository inssRepository)
        {
            _inssRepository = inssRepository ??
            throw new ArgumentNullException(nameof(inssRepository));
        }
        public double CalcularDesconto(DateTime data, double salarioContribuicao)
        {

            var aliquota = (double)_inssRepository.GetAliquota(data, salarioContribuicao);

            return (aliquota == Constants.TETO ?
                _inssRepository.GetTetoDesconto(data.Year) :
                salarioContribuicao.AsValorContribuicao(aliquota));
        }

    }
}
