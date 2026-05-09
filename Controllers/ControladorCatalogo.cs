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
                ImagenUrl = "https://pbs.twimg.com/media/Fu0wroGWcAEm80V.png"
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
                Id = 6, Titulo = "Uniforme LycorisRecoil", Genero = "Uniforme Chisato", Ano = 2022,
                Consola = "Vestimenta", Descripcion = "Uniforme del café para operaciones.",
                ImagenUrl = "https://www.gcosplay.com/cdn/shop/products/1_c31c003c-00b3-4836-8cb6-c2ac18b9f759.jpg?v=1659496621",
            },
            new Item
            {
                Id = 7, Titulo = "Uniforme LycorisRecoil", Genero = "Uniforme Takina", Ano = 2022,
                Consola = "Vestimenta", Descripcion = "Uniforme del café para operaciones.",
                ImagenUrl = "https://www.gcosplay.com/cdn/shop/products/1_c2f46062-88fb-4398-89d0-da96acba5637.jpg?v=1659496722",
            },
            new Item
            {
                 Id = 8, Titulo = "Mizuki Nakahara", Genero = "Soporte", Ano = 2022,
                Consola = "Logística", Descripcion = "Jefa de Operaciones de logística.",
                ImagenUrl = "https://cdn.rafled.com/anime-icons/images/IGxsRyO10iGZOBRp9Jk5IjWr69HpTZQq.jpg"
            }, 
            new Item
            {
                Id = 9, Titulo = "Mika", Genero = "Soporte", Ano = 2022, 
                Consola = "Logistica", Descripcion ="Mentor", 
                ImagenUrl = "https://shikimori.one/system/characters/original/207493.jpg"
            },
            new Item
            {
                Id = 10, Titulo = "Shinji Yoshimatsu", Genero = "Antagonista", Ano = 2022,
                Consola = "Miembro del instituo Alan", Descripcion =" Miembro de alto rango del Instituto Alan, una organización secreta que busca y apoya a personas con talentos excepcionales",
                ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDL1tVDZyhfs4WvjHsGvFwayNGduxvFMutnA&s"
            },
            new Item
            {
                Id = 11, Titulo = "Majima", Genero = "Antagonista", Ano = 2022,
                Consola = "Terrorista", Descripcion ="Es un terrorista que cree que Japón miente sobre los datos de seguridad pública y quiere compensarlo cometiendo actos terroristas para derrocar a Lycoris",
                ImagenUrl = "https://assets.mycast.io/actor_images/actor-majima-lycoris-recoil-611380_large.jpg?1670010507"
            },
            new Item
            {
                Id = 12, Titulo = "Robota", Genero = "Antagonista", Ano = 2022,
                Consola = "Hacker terrorista", Descripcion ="Hacker que complmaasta ica las misiones de las Lycoris",
                ImagenUrl = "https://anibase.net/files/540932d899b5b7f7c564e722b539928a"
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