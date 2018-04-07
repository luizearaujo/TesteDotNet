using System;

namespace TesteDotNet.Core2_0.Domains.Base
{
    public abstract class Entidade
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime DataAlteracao { get; private set; }

        protected Entidade()
        {
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
