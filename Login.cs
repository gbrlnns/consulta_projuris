using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;

namespace API_Tarefas
{
    public partial class Login : Form
    {
        public string? Token { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameLabel.TabStop = false;
            passwordLabel.TabStop = false;
            domainLabel.TabStop = false;
            clientIdLabel.TabStop = false;
            clientSecretLabel.TabStop = false;

            if (Properties.LoginData.Default.Username == string.Empty) return;
            saveData.Checked = true;
            usernameBox.Text = Properties.LoginData.Default.Username;
            passwordBox.Text = Properties.LoginData.Default.Password;
            domainBox.Text = Properties.LoginData.Default.Domain;
            clientIdBox.Text = Properties.LoginData.Default.ClientId;
            clientSecretBox.Text = Properties.LoginData.Default.ClientSecret;
        }

        private void username_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameBox.Text))
            {
                e.Cancel = true;
                textboxErrorProvider.SetError(usernameBox, "O nome de usuário não pode ser deixado em branco.");
            }
            else
            {
                e.Cancel = false;
                textboxErrorProvider.SetError(usernameBox, null);
            }
        }

        private void password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                e.Cancel = true;
                textboxErrorProvider.SetError(passwordBox, "A senha não pode ser deixada em branco.");
            }
            else
            {
                e.Cancel = false;
                textboxErrorProvider.SetError(passwordBox, null);
            }
        }

        private void domain_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(domainBox.Text))
            {
                e.Cancel = true;
                textboxErrorProvider.SetError(domainBox, "O domínio não pode ser deixado em branco.");
            }
            else
            {
                e.Cancel = false;
                textboxErrorProvider.SetError(domainBox, null);
            }
        }

        private void clientId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(clientIdBox.Text))
            {
                e.Cancel = true;
                textboxErrorProvider.SetError(clientIdBox, "O ID do cliente não pode ser deixado em branco.");
            }
            else
            {
                e.Cancel = false;
                textboxErrorProvider.SetError(clientIdBox, null);
            }
        }

        private void clientSecret_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(clientSecretBox.Text))
            {
                e.Cancel = true;
                textboxErrorProvider.SetError(clientSecretBox, "O segredo do cliente não pode ser deixado em branco.");
            }
            else
            {
                e.Cancel = false;
                textboxErrorProvider.SetError(clientSecretBox, null);
            }
        }

        private async void DoLogin_ClickAsync(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Preencha todos os campos do formulário antes de tentar fazer login", "Erro");
            }

            if (saveData.Checked)
            {
                Properties.LoginData.Default.Username = usernameBox.Text;
                Properties.LoginData.Default.Password = passwordBox.Text;
                Properties.LoginData.Default.Domain = domainBox.Text;
                Properties.LoginData.Default.ClientId = clientIdBox.Text;
                Properties.LoginData.Default.ClientSecret = clientSecretBox.Text;
                Properties.LoginData.Default.Save();
            }
            else
            {
                Properties.LoginData.Default.Reset();
            }

            var username = usernameBox.Text.Trim();
            var domain = domainBox.Text.Trim();
            var password = passwordBox.Text;

            var clientId = clientIdBox.Text.Trim();
            var clientSecret = clientSecretBox.Text.Trim();
            var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://login.projurisadv.com.br/adv-bouncer-authorization-server/oauth/token"),
                Headers =
                {
                    { "Authorization", $"Basic {base64EncodedAuthenticationString}"},
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", $"{username}$${domain}"},
                    { "password", $"{password}"},
                })
            };

            var response = await client.SendAsync(request);

            try
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                if (body is not null && body.TryGetValue("access_token", out var value))
                Token = value.ToString();
                Properties.LoginData.Default.IsLogged = true;
                DialogResult = DialogResult.OK;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Falha ao obter token de login. {ex.Message}", "Erro.");
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
