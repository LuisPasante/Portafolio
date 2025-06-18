using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioDTO
    {
        List<ProyectoDTO> ObtenerProyectos();
    }
    public class RepositorioDTO : IRepositorioDTO
    {
      
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>
            {
                new ProyectoDTO
                {
                    Titulo = "Proyecto 1",
                    Descripcion = "Descripción del proyecto 1",
                    ImagenUrl =  "/Img/amazon.png",
                    link = "/Img/amazon.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Proyecto 2",
                    Descripcion = "Descripción del proyecto 2",
                    ImagenUrl = "/Img/nyt.png",
                    link = "/Img/nyt.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Proyecto 3",
                    Descripcion = "Descripción del proyecto 3",
                    ImagenUrl =  "/Img/reddit.png",
                    link =  "/Img/reddit.png"
                },
                new ProyectoDTO
                {
                    Titulo = "Proyecto 4",
                    Descripcion = "Descripción del proyecto 4",
                    ImagenUrl = "/Img/steam.png",
                    link = "/Img/steam.png"
                }
            };
        }
    }
}
