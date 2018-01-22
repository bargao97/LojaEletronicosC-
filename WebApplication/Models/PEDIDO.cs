using GridMvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication.Models.Enums;

namespace WebApplication.Models
{
    public class PEDIDO
    {

        [Key]
        [GridColumn(Title = "ID", SortEnabled = true, FilterEnabled = true)]
        [MinLength(12)]
        public int COD_PEDIDO { get; set; }

        [Display(Name = "Nome do Produto")]
        [GridColumn(Title = "Nome Fantasia", SortEnabled = true, FilterEnabled = true)]
        public string NOME { get; set; }


        [Display(Name = "Preço")]
        public double PRECO { get; set; }
        [NotMappedColumn]

        public virtual CLIENTE CLIENTES {get;set;}

        [ForeignKey("CLIENTES")]
        public string ID_CLIENTE { get; set; }

        [Display(Name = "Status do pedido")]
        public StatusPedido STATUS_PEDIDO { get; set; }

    }
}