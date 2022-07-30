namespace Dataplace.Imersao.Core.Domain.Orcamentos.Enums
{
    public enum OrcamentoItemStatusEnum
    {
        Aberto,
        Fechado,
        Cancelado
    }

    public static class OrcamentoItemStatusEnumExtensions
    {

        // Aberto = P
        // Fechado = F
        // Cancelado = C
        private const string ABERTO = "P";
        private const string FECHADO = "F";
        private const string CANCELADO = "C";

        public static string ToDataValue(this OrcamentoItemStatusEnum value)
        {
            return value == OrcamentoItemStatusEnum.Fechado ? FECHADO : value == OrcamentoItemStatusEnum.Cancelado ? CANCELADO : ABERTO;
        }
        public static OrcamentoItemStatusEnum ToOrcamentoItemStatusEnum(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return OrcamentoItemStatusEnum.Aberto;
            if (value == FECHADO)
                return OrcamentoItemStatusEnum.Fechado;
            else if (value == CANCELADO)
                return OrcamentoItemStatusEnum.Cancelado;
            else
                return OrcamentoItemStatusEnum.Aberto;
        }


    }
}
