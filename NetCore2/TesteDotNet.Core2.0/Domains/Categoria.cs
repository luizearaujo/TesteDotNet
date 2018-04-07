using System;
using TesteDotNet.Core2_0.Domains.Base;

namespace TesteDotNet.Core2_0.Domains
{
    public class Categoria : Entidade, IExclusaoLogica
    {
        public virtual string Nome { get; set; }
        public virtual DateTime? DataExclusao { get; set; }
    }
}
