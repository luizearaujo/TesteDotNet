using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteDotNet.Core2_0.Domains;
using TesteDotNet.Core2_0.Validations;

namespace TesteDotNet.Core2_0.Models
{
    public class ItemViewModel
    {
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MesmoNomeBloqueado(ErrorMessage = "Já existe um item cadastrado com o mesmo nome")]
        [StringLength(50, ErrorMessage = "Este campo deve ter no máximo {1} caractere")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(1024, ErrorMessage = "Este campo deve ter no máximo {1} caractere")]
        public string Descricao { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatório")]
        public string CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Display(Name = "Data Criação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; }

        public List<SelectListItem> ListaCategorias { get; set; }

        public string TituloPagina => Id == 0 ? "Adicionar Item" : "Alterar Item";

        public ItemViewModel(Item item)
        {
            Id = item.Id;
            Nome = item.Nome;
            Descricao = item.Descricao;
            CategoriaId = item.CategoriaId.ToString();
            CategoriaNome = item.CategoriaNome;
            DataCriacao = item.DataCriacao;
        }

        public ItemViewModel()
        {
        }
    }
}
