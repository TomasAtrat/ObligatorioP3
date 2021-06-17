using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IControllers
    {
        List<string> Alta(IDto dto);

        List<string> Baja(IDto dto);

        List<string> Modificacion(IDto dto);

        List<IDto> ListAll();
    }
}
