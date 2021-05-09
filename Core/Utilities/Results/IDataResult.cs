using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult//IResulttakileri de içerdiği için burdan inherit alıyoruz tekrar yazmamak için
    {
        T Data { get; }
    }
}
