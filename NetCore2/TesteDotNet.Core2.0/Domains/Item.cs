using System;
using TesteDotNet.Core2_0.Domains.Base;
using TesteDotNet.Core2_0.Models;

namespace TesteDotNet.Core2_0.Domains
{
    public class Item : Entidade, IExclusaoLogica
    {
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }

        public virtual int CategoriaId { get; set; }
        public virtual string CategoriaNome { get; set; }
        
        public virtual DateTime? DataExclusao { get; set; }


        public Item(ItemViewModel itemVM)
        {
            Id = itemVM.Id;
            Nome = itemVM.Nome;
            Descricao = itemVM.Descricao;
            CategoriaId = Convert.ToInt32(itemVM.CategoriaId);
        }

        public Item()
        {

        }
    }
}
