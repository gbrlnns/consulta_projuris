using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace API_Tarefas;

public static class ApiListas
{
    public static async Task<List<Dictionary<string, object?>>> ObterLista(string token, string numeroProcesso)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api.projurisadv.com.br/adv-service/tarefa/consulta-com-paginacao"),
            Headers =
            {
                { "accept", "application/json" },
                { "Authorization", $"Bearer {token}" },
            },
            Content = new StringContent($"{{\n\t\"numeroProcesso\": \"{numeroProcesso}\"\n}}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        
        /*
         * As linhas a seguir convertem a resposta JSON para uma lista de dicionários.
         * Com a conversão, é possível que o programa manipule as tarefas com base em seus dados cadastrais.
         * No caso do Projuris ADV, apenas a chave "tarefaConsultaWs" é usada, pois é ela que contém os dados de cada tarefa.
         */

        JObject jsonResponse = JObject.Parse(body);
        JArray tarefasArray = (JArray)jsonResponse["tarefaConsultaWs"];
        List<Dictionary<string, object?>> tarefasDictList = tarefasArray.Select(item => item.ToObject<Dictionary<string, object>>()).ToList();
        return tarefasDictList;
    }
}