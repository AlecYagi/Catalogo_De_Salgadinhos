using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_De_Salgadinhos.Exceptions
{
    public class ProdutoNaoCadastradoException: Exception
    { 
        public ProdutoNaoCadastradoException()
            : base("Este salgadinho não está cadastrado")
    { }
    }
}
