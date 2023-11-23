using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Services.Core.Application.UnitOfWorks
{
    public interface IUnitOfWork// repository de db verilerinde değişiklik yapıldığında tek tek yapmayıp 
                                // bütün verileri toplayıp en son savechange savechangeasync yapmayı sağlayan yerdir.
                                // eğer bir kısımda hata olursa hiçbir değişiklik uygulanmaz.
    {
        Task CommitAsync();

        void Commit();
    }
}
