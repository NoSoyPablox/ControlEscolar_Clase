﻿using FrontEndEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontEndEscolar
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class GestionUsuarios : Window
    {
        public GestionUsuarios()
        {
            InitializeComponent();

            UsuarioViewModel modelo = new UsuarioViewModel();
            dgUsuarios.ItemsSource = modelo.usuariosBD;
        }
    }
}
