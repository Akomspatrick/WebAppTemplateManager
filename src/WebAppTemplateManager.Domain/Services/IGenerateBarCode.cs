using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplateManager.Domain.Services
{
    public interface IGenerateBarCode
    {
        public string GenerateBarCode(string ProductId, int height = 200, int width = 400);


    }
}
