using System;
using System.Collections.Generic;

namespace ViveirosID.Models
{
    public class ICOlection<T>
    {
        public static implicit operator ICOlection<T>(HashSet<Carrinhos> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ICOlection<T>(HashSet<CarrinhoArtigo> v)
        {
            throw new NotImplementedException();
        }
    }
}