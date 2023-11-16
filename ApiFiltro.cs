namespace API_Tarefas;

public static class ApiFiltro
{
    public static List<string> FiltraLista(List<Dictionary<string, object?>> listaTarefas)
    {
        var listaFiltrada = new List<string>();
        foreach (var tarefa in listaTarefas)
        {
            tarefa.TryGetValue("codigoSituacao", out var codigoSituacao);
            var status = Convert.ToByte(codigoSituacao);

            /* O código a seguir pula as tarefas com status 2, 3 ou 5.
             * Na API do Projuris, estes códigos correspondem às tarefas concluídas com sucesso, concluídas sem sucesso ou canceladas.
             */

            if (status is 2 or 3 or 5)
            {
                continue;
            }
            
            tarefa.TryGetValue("nomeTarefaTipo", out var nomeTarefaTipo);
            var nomeTarefa = Convert.ToString(nomeTarefaTipo);
            
            tarefa.TryGetValue("dataLimite", out var fatalObj);
            var unixTimestamp = Convert.ToInt64(fatalObj);
            var fatalBrasil = ApiConverteData.ConverteData(unixTimestamp);

            string? tarefaFinal = null;
            
            if (tarefa["descricao"] is not null)
            {
                var descricaoTarefa = tarefa["descricao"]?.ToString();
                var tarefaMultilinha = descricaoTarefa != null && descricaoTarefa.Contains("Esta tarefa foi criada com base em uma intimação que você recebeu do Projuris ADV") ? $"{nomeTarefa} - Fatal: {fatalBrasil}" : $"{nomeTarefa} ({descricaoTarefa}) - Fatal: {fatalBrasil}";
                tarefaFinal = tarefaMultilinha.Replace(System.Environment.NewLine, " ");
            }
            else
            {
                var tarefaMultilinha = $"{nomeTarefa} - Fatal: {fatalBrasil}";
                tarefaFinal = tarefaMultilinha.Replace(System.Environment.NewLine, " ");
            }
            
            listaFiltrada.Add(tarefaFinal);
        }
        return listaFiltrada;
    }
}