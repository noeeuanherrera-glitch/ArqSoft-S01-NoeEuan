using Catalogo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo1.Controllers
{
    public class CatalogoController : Controller
    {
        // Lista con el nuevo campo ImagenUrl incluido (Paso 3 corregido)[cite: 1]
        private static List<Item> _items = new()
        {
            new Item
            {
                Id = 1, Titulo = "Chisato Nishikigi", Genero = "Agente", Ano = 2022,
                Consola = "DA - 1ra Clase", Descripcion = "la Hermosa Especialista en combate no letal.",
                ImagenUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQSckhlIU3tCS9QhSiaexVmeqDEcLCWOXt1KPY4ZVn_at97b1QG"
            },
            new Item
            {
                Id = 2, Titulo = "Takina Inoue", Genero = "Agente", Ano = 2022,
                Consola = "DA - 2da Clase", Descripcion = "La hermosa Experta en precisión táctica.",
                ImagenUrl = "https://cdn.rafled.com/anime-icons/images/lCLiocTU6iRxNZUVEziS5hazDmipp3Yh.jpg"
            },
            new Item
            {
                Id = 3, Titulo = "Pistola de Chisato Nishikigi", Genero = "Equipamiento", Ano = 2022,
                Consola = "Arma Custom", Descripcion = "Munición de impacto de goma.",
                ImagenUrl = "https://img.anmosugoi.com/file/media-sugoi/2024/02/Lycoris-Recoil-arm_-Chisato-2.webp"
            },
            new Item
            {
                Id = 4, Titulo = "Arma de Takina Inoue", Genero = "Equipamiento", Ano = 2022,
                Consola = "Arma Custom", Descripcion ="Pistola Semiautomatica de 9mm",
                ImagenUrl = "https://cash-for-arms-pictures.s3.amazonaws.com/recZHl3ByRz2m9oLG/6.jpg"
            },
            new Item
            {
                Id = 5, Titulo = "Kurumi (Walnut)", Genero = "Soporte", Ano = 2022,
                Consola = "Hacker", Descripcion = "Soporte técnico y ciberseguridad.",
                ImagenUrl = "https://media.japanesewithanime.com/uploads/overly-long-sleeves-Kurumi-Lycoris-Recoil-ep04.jpg"
            },
            new Item
            {
                Id = 6, Titulo = "Uniforme LycoReco", Genero = "Uniforme", Ano = 2022,
                Consola = "Vestimenta", Descripcion = "Uniforme del café para operaciones.",
                ImagenUrl = "https://cdn.somoskudasai.com/image/9b3f8105c6c6b42ffd5675a58b19116c/452x263/story_2343_photo_1656689171861354295.webp"
            },
            new Item
            {
                 Id = 7, Titulo = "Mizuki Nakahara", Genero = "Soporte", Ano = 2022,
                Consola = "Logística", Descripcion = "Jefa de Operaciones de logística.",
                ImagenUrl = "https://cdn.rafled.com/anime-icons/images/IGxsRyO10iGZOBRp9Jk5IjWr69HpTZQq.jpg"
            }, 
            new Item
            {
                Id = 8, Titulo = "Mika", Genero = "Soporte", Ano = 2022, 
                Consola = "Logistica", Descripcion ="Mentor", 
                ImagenUrl = "https://shikimori.one/system/characters/original/207493.jpg"
            },
            new Item
            {
                Id = 9, Titulo = "Shinji Yoshimatsu", Genero = "Antagonista", Ano = 2022,
                Consola = "Miembro del instituo Alan", Descripcion =" Miembro de alto rango del Instituto Alan, una organización secreta que busca y apoya a personas con talentos excepcionales",
                ImagenUrl = "https://myanimelist.net/images/characters/10/480168.jpg"
            }
        };

        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            // Si el usuario no pone URL, le asignamos una por defecto para evitar errores visuales
            if (string.IsNullOrEmpty(item.ImagenUrl)) item.ImagenUrl = "https://via.placeholder.com/150";

            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}