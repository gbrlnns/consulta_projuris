using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
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
            RequestUri = new Uri("https://api.projurisadv.com.br/adv-service/tarefa/calendario/consulta-sem-paginacao"),
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

        if (response.StatusCode == (HttpStatusCode)204)
        {
            return new List<Dictionary<string, object?>>();
        }
        var body = await response.Content.ReadAsStringAsync();
        
        /*
         * As linhas a seguir convertem a resposta JSON para uma lista de dicionários.
         * Com a conversão, é possível que o programa manipule as tarefas com base em seus dados cadastrais.
         * No caso do Projuris ADV, apenas a chave "tarefaConsultaWs" é usada, pois é ela que contém os dados de cada tarefa.
         */
        
        var jsonResponse = JsonConvert.DeserializeObject<JObject>(body);
        var tarefasAgrupadasDataTipoWs = jsonResponse["tarefasAgrupadasDataTipoWs"];
        var tarefasDictList = new List<Dictionary<string, object>>();
        
        foreach (var item in tarefasAgrupadasDataTipoWs)
        {
            var tarefaConsultaWs = item["tarefaConsultaWs"];
            foreach (var tarefa in tarefaConsultaWs)
            {
                var tarefaDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(tarefa.ToString());
                tarefasDictList.Add(tarefaDict);
            }
        }
        
        return tarefasDictList;
    }
}