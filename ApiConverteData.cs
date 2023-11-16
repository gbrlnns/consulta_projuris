/*
 * O Projuris ADV informa as datas em formato Unix.
 * Esta classe converte uma data em formato Unix para o formato local do Brasil.
 */

namespace API_Tarefas;

public class ApiConverteData
{
    public static string ConverteData(long unix)
    {
        var dataUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var utcFinal = dataUtc.AddMilliseconds(unix);
        var fusoHorario = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        var horaLocal = TimeZoneInfo.ConvertTimeFromUtc(utcFinal, fusoHorario);

        var dataString = horaLocal.ToString("dd/MM/yyyy");
        return dataString;
    }
}