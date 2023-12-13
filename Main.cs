namespace API_Tarefas
{
    public partial class Main : Form
    {
        public string? Token { get; set; }
        public string FileName { get; set; }
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (Properties.LoginData.Default.IsLogged != true)
            {
                Login loginScreen = new Login();
                var result = loginScreen.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Token = loginScreen.Token;
                    statusLabel.Text = $"Login realizado com sucesso. Token: {Token}";
                }
                else
                {
                    MessageBox.Show("Login cancelado, encerrando...", "Erro");
                    Close();
                }
            }
        }

        private void fileSelect_Click(object sender, EventArgs e)
        {
            var result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileName = openFile.FileName;
                fileNameBox.Text = FileName;
                process.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nenhum arquivo selecionado.", "Erro");
            }
        }

        private async void process_Click(object sender, EventArgs e)
        {
            if (!(sender as Control).Enabled)
                return;

            process.Enabled = false;
            statusLabel.Text = "Lendo planilha...";

            var listaProcessos = ApiExcel.ReadExcel(FileName);
            var tarefasDict = new Dictionary<string, string>();

            var tamanhoLista = listaProcessos.Count;
            var processoAtual = 0;

            foreach (var numeroProcesso in listaProcessos.Select(numero => numero.Trim()))
            {
                statusLabel.Text = $"Obtendo a lista de tarefas do processo nº {numeroProcesso}... ";
                var listaTarefas = await ApiListas.ObterLista(Token, numeroProcesso);
                var listaFiltrada = ApiFiltro.FiltraLista(listaTarefas);

                var listaExcel = NomesLista(listaFiltrada);
                tarefasDict.Add(numeroProcesso, listaExcel);

                processoAtual++;
                var porcentagem = (int)Math.Round((double)(100*processoAtual)/tamanhoLista);

                progressBar.Value = porcentagem;

                continue;

                // Função para elencar as tarefas agendadas em uma única string, de acordo com o n�mero de tarefas pendentes identificadas.

                static string NomesLista(List<string> lista)
                {
                    return lista.Count switch
                    {
                        0 => "Não há tarefas pendentes.",
                        1 => "Temos no Projuris: " + string.Join("", lista.ToArray()) + ".",
                        _ => "Temos no Projuris: " + string.Join(", ", lista.ToArray(), 0, lista.Count - 1) + " e " + lista.LastOrDefault() + "."
                    };
                }
            }

            string? outFile = null;
            var result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                outFile = saveFile.FileName;
                ApiExcel.WriteExcel(outFile, tarefasDict);
                MessageBox.Show($"Listas de tarefas salvas no arquivo: {outFile}", "Sucesso");
                Close();
            }
            else
            {
                MessageBox.Show("Nenhum arquivo selecionado. Cancelando...", "Erro");
            }
        }
    }
}