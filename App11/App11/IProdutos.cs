using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App11
{
    public class IProdutos
    {
        HttpClient client = new HttpClient();
        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                string Url = "http://produtosxamarin.gearhostpreview.com/api/products/";
                var response = await client.GetStringAsync(Url);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AdicionaProduto(Produto produto)
        {
            try
            {
                string Url = "http://produtosxamarin.gearhostpreview.com/api/products/";
                var uri = new Uri(string.Format(Url, produto));

                var data = JsonConvert.SerializeObject(produto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao Incluir Produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
