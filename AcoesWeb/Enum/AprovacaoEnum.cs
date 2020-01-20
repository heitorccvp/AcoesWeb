using System.ComponentModel;

namespace AcoesWeb.Enum
{
	public enum AprovacaoEnum
	{
		[Description("Aprovado")]
		Aprovado = 1,
		[Description("Reprovado")]
		Reprovado = 2,
		[Description("Pendente Aprovacao")]
		PendenteAprovacao = 3
	}
}
