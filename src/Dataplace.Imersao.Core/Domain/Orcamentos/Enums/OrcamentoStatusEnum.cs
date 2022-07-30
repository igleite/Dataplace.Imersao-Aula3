namespace Dataplace.Imersao.Core.Domain.Orcamentos.Enums
{
 

    public enum OrcamentoStatusEnum
    {
        Aberto = 0 ,
        Fechado =1,
        Cancelado =2,
    }

    public static class OrcamentoStatusEnumExtensions
    {

        // Aberto = P
        // Fechado = F
        // Cancelado = C
        private const string ABERTO = "P";
        private const string FECHADO = "F";
        private const string CANCELADO = "C";

        public static string ToDataValue(this OrcamentoStatusEnum value)
        {
            return value == OrcamentoStatusEnum.Fechado ? FECHADO : value == OrcamentoStatusEnum.Cancelado ? CANCELADO : ABERTO;         
        }
        public static OrcamentoStatusEnum ToOrcamentoStatusEnum(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return OrcamentoStatusEnum.Aberto;
            if (value == FECHADO)
                return OrcamentoStatusEnum.Fechado;
            else if (value == CANCELADO)
                return OrcamentoStatusEnum.Cancelado;
            else
                return OrcamentoStatusEnum.Aberto;
        }

       
    }
}
