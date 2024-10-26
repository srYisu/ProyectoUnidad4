﻿namespace ProyectoUnidad4
{
    partial class Dashboard
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
            this.btnGestionDeProductos = new Guna.UI2.WinForms.Guna2Button();
            this.btnGestionDeClientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnReportes = new Guna.UI2.WinForms.Guna2Button();
            this.lblDashboard = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCerrarSesion = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnGestionDeProductos
            // 
            this.btnGestionDeProductos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGestionDeProductos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGestionDeProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGestionDeProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGestionDeProductos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGestionDeProductos.ForeColor = System.Drawing.Color.White;
            this.btnGestionDeProductos.Location = new System.Drawing.Point(85, 104);
            this.btnGestionDeProductos.Name = "btnGestionDeProductos";
            this.btnGestionDeProductos.Size = new System.Drawing.Size(120, 41);
            this.btnGestionDeProductos.TabIndex = 0;
            this.btnGestionDeProductos.Text = "Gestión de productos";
            this.btnGestionDeProductos.Click += new System.EventHandler(this.btnGestionDeProductos_Click);
            // 
            // btnGestionDeClientes
            // 
            this.btnGestionDeClientes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGestionDeClientes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGestionDeClientes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGestionDeClientes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGestionDeClientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGestionDeClientes.ForeColor = System.Drawing.Color.White;
            this.btnGestionDeClientes.Location = new System.Drawing.Point(85, 160);
            this.btnGestionDeClientes.Name = "btnGestionDeClientes";
            this.btnGestionDeClientes.Size = new System.Drawing.Size(120, 41);
            this.btnGestionDeClientes.TabIndex = 1;
            this.btnGestionDeClientes.Text = "Gestión de clientes";
            this.btnGestionDeClientes.Click += new System.EventHandler(this.btnGestionDeClientes_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReportes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReportes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReportes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(85, 216);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(120, 41);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // lblDashboard
            // 
            this.lblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboard.Location = new System.Drawing.Point(117, 59);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(55, 15);
            this.lblDashboard.TabIndex = 3;
            this.lblDashboard.Text = "Dashboard";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCerrarSesion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCerrarSesion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(3, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(62, 34);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 322);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnGestionDeClientes);
            this.Controls.Add(this.btnGestionDeProductos);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnGestionDeProductos;
        private Guna.UI2.WinForms.Guna2Button btnGestionDeClientes;
        private Guna.UI2.WinForms.Guna2Button btnReportes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDashboard;
        private Guna.UI2.WinForms.Guna2Button btnCerrarSesion;
    }
}