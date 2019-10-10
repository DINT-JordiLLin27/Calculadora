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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Llama a método para crear cada botón del 1 al 9
            CreaBotones();

        }

        //Handler del evento Clic para los Botones
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Añade al TextBox que forma la pantalla de la calculadora el Tag del botón pulsado, en este caso los Tags corresponden al número del botón.
            CalculadoraTextBlock.Text += (sender as Button).Tag; 
        }


        //Metodo que inicializa los botones añadiendo los elementos necesarios.
        public void CreaBotones()
        {
            //Elementos que van a estar en la etiqueta <Button>
            Viewbox vb;
            TextBlock tb;
            Button b;

            //Lista de botones donde se almacenarán una vez completos
            List<Button> botones = new List<Button>();

            for (int i = 1; i <= 9; i++)
            {
                //Inicialización de elementos
                vb = new Viewbox();
                b = new Button();
                tb = new TextBlock();

                
                tb.Text = i.ToString(); //asigno texto al TextBox que irá dentro del ViewBox.
                vb.Child = tb; //Añado como hijo del ViewBox el TextBox
                b.Content = vb; //Añado como contenido del botón el ViewBox con su TextBox
                b.Margin = new Thickness(5); //Le doy un margen de 5
                b.Click += Button_Click; //Añado el controlador para el evento de 'Click'
                b.Tag = i; //Le asigno un Tag al botón que me servirá para el manejador.

                botones.Add(b); //Lista de botones
            }

            //Llamar al método que los colocará en el Grid
            ColocaBotonesEnGrid(botones);
        }

        //Método que asigna las propiedades 'Grid.Row' y 'Grid.Column' a los botones dada una lista con ellos ya creados.
        public void ColocaBotonesEnGrid(List<Button> botones)
        {

            Grid gr = (Grid)this.Content;
            int filas = 1, columnas = 0;

            for (int i = 0; i < botones.Count; i++)
            {
                //indico en qué fila y columna poner el botón
                Grid.SetRow(botones[i], filas);
                Grid.SetColumn(botones[i], columnas);
                //lo añado a la tabla            
                gr.Children.Add(botones[i]);

                //Control de los contadores de filas y columnas
                if (filas < 3 && columnas == 2)
                    filas++;

                if (columnas < 2 )
                    columnas++;
                else
                    columnas = 0;
            }



        }

    }

}

