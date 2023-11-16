namespace API_Tarefas
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            usernameBox = new TextBox();
            passwordBox = new TextBox();
            saveData = new CheckBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            domainLabel = new Label();
            domainBox = new TextBox();
            clientIdLabel = new Label();
            clientIdBox = new TextBox();
            clientSecretLabel = new Label();
            clientSecretBox = new TextBox();
            doLogin = new Button();
            cancel = new Button();
            textboxErrorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)textboxErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(107, 57);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(246, 27);
            usernameBox.TabIndex = 0;
            usernameBox.Validating += username_Validating;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(107, 135);
            passwordBox.Name = "passwordBox";
            passwordBox.Size = new Size(246, 27);
            passwordBox.TabIndex = 1;
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.Validating += password_Validating;
            // 
            // saveData
            // 
            saveData.AutoSize = true;
            saveData.Location = new Point(139, 448);
            saveData.Name = "saveData";
            saveData.Size = new Size(175, 24);
            saveData.TabIndex = 5;
            saveData.Text = "Salvar dados de login";
            saveData.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(107, 34);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(123, 20);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Nome de usuário";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(107, 112);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(49, 20);
            passwordLabel.TabIndex = 9;
            passwordLabel.Text = "Senha";
            // 
            // domainLabel
            // 
            domainLabel.AutoSize = true;
            domainLabel.Location = new Point(107, 196);
            domainLabel.Name = "domainLabel";
            domainLabel.Size = new Size(67, 20);
            domainLabel.TabIndex = 10;
            domainLabel.Text = "Domínio";
            // 
            // domainBox
            // 
            domainBox.Location = new Point(107, 219);
            domainBox.Name = "domainBox";
            domainBox.Size = new Size(246, 27);
            domainBox.TabIndex = 2;
            domainBox.Validating += domain_Validating;
            // 
            // clientIdLabel
            // 
            clientIdLabel.AutoSize = true;
            clientIdLabel.Location = new Point(110, 278);
            clientIdLabel.Name = "clientIdLabel";
            clientIdLabel.Size = new Size(94, 20);
            clientIdLabel.TabIndex = 11;
            clientIdLabel.Text = "ID do cliente";
            // 
            // clientIdBox
            // 
            clientIdBox.Location = new Point(110, 301);
            clientIdBox.Name = "clientIdBox";
            clientIdBox.Size = new Size(246, 27);
            clientIdBox.TabIndex = 3;
            clientIdBox.Validating += clientId_Validating;
            // 
            // clientSecretLabel
            // 
            clientSecretLabel.AutoSize = true;
            clientSecretLabel.Location = new Point(110, 361);
            clientSecretLabel.Name = "clientSecretLabel";
            clientSecretLabel.Size = new Size(135, 20);
            clientSecretLabel.TabIndex = 12;
            clientSecretLabel.Text = "Segredo do cliente";
            // 
            // clientSecretBox
            // 
            clientSecretBox.Location = new Point(110, 384);
            clientSecretBox.Name = "clientSecretBox";
            clientSecretBox.Size = new Size(246, 27);
            clientSecretBox.TabIndex = 4;
            clientSecretBox.UseSystemPasswordChar = true;
            clientSecretBox.Validating += clientSecret_Validating;
            // 
            // doLogin
            // 
            doLogin.Location = new Point(73, 515);
            doLogin.Name = "doLogin";
            doLogin.Size = new Size(131, 29);
            doLogin.TabIndex = 6;
            doLogin.Text = "Fazer login";
            doLogin.UseVisualStyleBackColor = true;
            doLogin.Click += DoLogin_ClickAsync;
            // 
            // cancel
            // 
            cancel.CausesValidation = false;
            cancel.Location = new Point(276, 515);
            cancel.Name = "cancel";
            cancel.Size = new Size(131, 29);
            cancel.TabIndex = 7;
            cancel.Text = "Cancelar";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // textboxErrorProvider
            // 
            textboxErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            textboxErrorProvider.ContainerControl = this;
            textboxErrorProvider.Icon = (Icon)resources.GetObject("textboxErrorProvider.Icon");
            // 
            // Login
            // 
            AcceptButton = doLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancel;
            ClientSize = new Size(446, 606);
            Controls.Add(cancel);
            Controls.Add(doLogin);
            Controls.Add(clientSecretLabel);
            Controls.Add(clientSecretBox);
            Controls.Add(clientIdLabel);
            Controls.Add(clientIdBox);
            Controls.Add(domainLabel);
            Controls.Add(domainBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(saveData);
            Controls.Add(passwordBox);
            Controls.Add(usernameBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)textboxErrorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox passwordBox;
        private CheckBox saveData;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label domainLabel;
        private TextBox domainBox;
        private Label clientIdLabel;
        private TextBox clientIdBox;
        private Label clientSecretLabel;
        private TextBox clientSecretBox;
        private Button doLogin;
        private Button cancel;
        private TextBox usernameBox;
        private ErrorProvider textboxErrorProvider;
    }
}