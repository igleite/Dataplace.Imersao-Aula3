namespace Dataplace.Imersao.Core.Domain.Orcamentos.Enums
{

    public enum TpRegistroEnum
    {
        ProdutoFinal = 1,
        SubProduto = 2,
        MateriaPrima = 3,
        Componente = 4,
        Servico = 5,
        BemDeConsumo = 9

    }

    public static class TpRegistroEnumExtension
    {
        private const string PRODUTO_FINAL = "1";
        private const string SUBPRODUTO = "2";
        private const string MATERIA_PRIMA = "3";
        private const string COMPONENTE = "4";
        private const string SERVICO = "5";
        private const string BEM_COSUMO = "9";

        public static string ToDataValue(this TpRegistroEnum value)
        {
            return 
                value == TpRegistroEnum.ProdutoFinal ? PRODUTO_FINAL : 
                value == TpRegistroEnum.SubProduto ? SUBPRODUTO :
                value == TpRegistroEnum.MateriaPrima ? MATERIA_PRIMA :
                value == TpRegistroEnum.Componente ? COMPONENTE :
                value == TpRegistroEnum.Servico ? SERVICO :
                value == TpRegistroEnum.BemDeConsumo ? BEM_COSUMO : null;


        }

        public static TpRegistroEnum? ToTpRegistroEnum(this string value)
        {
            TpRegistroEnum? t = 
                   value == PRODUTO_FINAL ? TpRegistroEnum.ProdutoFinal  :
                   value == SUBPRODUTO ? TpRegistroEnum.SubProduto :
                   value == MATERIA_PRIMA ? TpRegistroEnum.MateriaPrima :
                   value == COMPONENTE ? TpRegistroEnum.Componente  :
                   value == SERVICO ? TpRegistroEnum.Servico  :
                   value == BEM_COSUMO ? TpRegistroEnum.BemDeConsumo : default;

            return t;
        }
    }
}
