using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GridMvc.DataAnnotations;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public class PRODUTO
    {
        [Key]
        [GridColumn(Title = "ID", SortEnabled = true, FilterEnabled = true)]
        [MinLength(12)]
        public int COD_PRODUTO { get; set; }

        [Display(Name = "Nome do Produto")]
        [GridColumn(Title = "Nome Fantasia", SortEnabled = true, FilterEnabled = true)]
        public string NOME { get; set; }


        [Display(Name = "Preço")]
        public double PRECO { get; set; }

        [Display(Name = "Regiao de comercialização")]
        public REGIAO REGIAO { get; set; }
        
    }
}