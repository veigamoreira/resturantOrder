using System.Collections.Generic;

namespace Crud.VagnerMoreira.Application.ViewModels
{
    public abstract class BaseResponse
    {
        public List<ErroViewModel> Erros { get; set; }
    }
}
