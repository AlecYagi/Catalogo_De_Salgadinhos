using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_De_Salgadinhos.InputModel
{
    public class ProdutoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do produto deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da marca deve conter entre 3 e 100 caracteres")]
        public string Marca { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preco deve ser de no minimo 1 real e no maximo 1000 reais")]
        public double Preco { get; set; }

    }
}
