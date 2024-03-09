 

namespace SchoolProSite.DAL.Exceptions
{
    public class DaoCourseException : Exception
    {
        public DaoCourseException(string message) : base(message)
        {
            // Logica para guardar el error en la base datos y enviar un correo.
        }
    }
}
