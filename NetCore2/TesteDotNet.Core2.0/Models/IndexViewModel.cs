using System.Collections.Generic;

namespace TesteDotNet.Core2_0.Models
{
    public class IndexViewModel
    {        
        public string Busca { get; set; }
        public IEnumerable<ItemViewModel> ListaItem { get; set; }
    }
}
