using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SenacNivelamento.Api.Tools
{
    public class FerramentaImagem
    {
        public string Salvar(IFormFile imagem, string prefixo, long id)
        {
            var folderName = Path.Combine("Resources", "Images");
            folderName = Path.Combine(folderName, prefixo);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (imagem.Length > 0)
            {
                var fileName = $"{prefixo}-{id}.{imagem.FileName.Split('.')[1]}";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imagem.CopyTo(stream);
                }

                return dbPath;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
