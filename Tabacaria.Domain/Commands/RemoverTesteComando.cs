using System.Collections.Generic;
using Tabacaria.Domain.Entities;

namespace Tabacaria.Domain.Commands
{
    //REMOVER TESTANDO
    //public class RemoverTesteComando : ProductCommand<EssenceEntity>
    public class RemoverTesteComando : ProductCommand
    {
        public int RemoverTeste { get; set; }
    }
}
