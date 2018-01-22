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
    public class CLIENTE
    {
        [Key]
        [MinLength(8)]
        public string COD_CLIENTE { get; set; }

        [Display(Name = "Nome Do cliente")]
        [StringLength(int.MaxValue)]
        [GridColumn(Title = "Nome Fantasia", SortEnabled = true, FilterEnabled = true)]
        public string NOME { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [MinLength(14)]
        [StringLength(150)]
        [NotMappedColumn]
        public string CPF_CNPJ { get; set; }

        [StringLength(3)]
        [GridColumn(Title = "DDD", SortEnabled = true, FilterEnabled = true)]
        [NotMappedColumn]
        public string DDD { get; set; }
        [Display(Name = "Contato")]
        [StringLength(20)]
        [GridColumn(Title = "Telefone", SortEnabled = true, FilterEnabled = true)]
        public string CONTATO { get; set; }

        [Display(Name = "UF")]
        [StringLength(100)]
        [NotMappedColumn]
        public string UF { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(100)]
        [GridColumn(Title = "Cidade", SortEnabled = true, FilterEnabled = true)]
        public string CIDADE { get; set; }

        [Display(Name = "CEP")]
        [StringLength(11)]
        [NotMappedColumn]
        public string CEP { get; set; }

        [Display(Name = "Tipo de Logradouro")]
        [StringLength(150)]
        [NotMappedColumn]
        
        public string LOGRADOURO { get; set; }

        [Display(Name = "Numero")]
        [StringLength(10)]
        [NotMappedColumn]
        public string Numero { get; set; }


        [Display(Name = "Bairro")]
        [StringLength(100)]
        [NotMappedColumn]
        public string BAIRRO { get; set; }

        public REGIAO REGIAO { get; set; }
    }
}