using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo_De_Salgadinhos.Exceptions
{
    public class ProdutoJaCadastradoException : Exception
    {
        public ProdutoJaCadastradoException()
            : base("Este salgadinho ja está cadastrado")
        { }
    }
}
