using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.Core2_0.Domains;
using TesteDotNet.Core2_0.Models;
using TesteDotNet.Core2_0.Repositories.Base;
using TesteDotNet.Core2_0.Services.Base;

namespace TesteDotNet.Core2_0.Services
{
    public class ItemService : IService<ItemViewModel>
    {
        IRepository<Item> _itemRepository;
        IRepository<Categoria> _categoriaRepository;

        public ItemService(IRepository<Item> itemRepository, IRepository<Categoria> categoriaRepository)
        {
            _itemRepository = itemRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task Save(ItemViewModel itemVM)
        {
            var item = new Item(itemVM);

            if (itemVM.Id == 0)
                await _itemRepository.AddAsync(item);
            else
                await _itemRepository.UpdateAsync(item);
        }

        public async Task Delete(int id)
        {
            await _itemRepository.DeleteAsync(id);
        }

        private List<SelectListItem> listaCategorias()
        {
            var categorias = _categoriaRepository.GetAll(null);

            return categorias.Select(
                x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                }
            ).ToList();
        }

        public ItemViewModel Get(int? id)
        {
            ItemViewModel itemVM;

            if (id != null)
            {
                var item = _itemRepository.Get((int)id);

                if (item == null)
                    return null;

                itemVM = new ItemViewModel(item);
            }
            else
                itemVM = new ItemViewModel();

            itemVM.ListaCategorias = listaCategorias();

            return itemVM;
        }

        public IEnumerable<ItemViewModel> Find(string busca)
        {
            return _itemRepository.GetAll(busca).Select(x => new ItemViewModel(x));
        }

        public bool Duplicate(int id, string nome)
        {
            return _itemRepository.Exists(id, nome);
        }
    }
}
