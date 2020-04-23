namespace Crud.VagnerMoreira.Application.ViewModels
{
    public class UsuarioAdicionarResponse : BaseResponse
    {
        public int Id { get; set; }
    }

    public class UsuarioEditarResponse : BaseResponse
    {
    }

    public class UsuarioDeletarResponse : BaseResponse
    {
    }

    public class UsuarioObterResponse
    {
        public int Id { get; set; }

        public string Nome { get; private set; }

        public string DataNascimento { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public int Sexo { get; private set; }
    }

    public class UsuarioListarResponse
    {
        public int Id { get; set; }

        public string Nome { get; private set; }

        public string DataNascimento { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public int Sexo { get; private set; }
    }
}
