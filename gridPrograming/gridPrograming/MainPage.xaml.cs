using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gridPrograming
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            //We out comit the scafolded method 
            //So we can use our own method to create the page

            //InitializeComponent();
            InitializePage();
        }

        //Our main method to Initialize our page
        void InitializePage()
        {
            //Our layouts on the page
            StackLayout mainLayout = new StackLayout();
            StackLayout gridStack = new StackLayout();
            StackLayout resizeLayout = new StackLayout();

            //The grid itself 
            Grid grid = new Grid();
            //Stating with a grid there is 3x3
            InitializeGrid(grid,3,3);
            //Adding the grid to its stackLayout
            gridStack.Children.Add(grid);

            //A text box for inserting how many rows the grid will have
            Entry rowEntry = new Entry();
            //Keybord numeric so the user only can insert numbers
            rowEntry.Keyboard = Keyboard.Numeric;
            rowEntry.Placeholder = "Number of Rows";
            //Adding the entry to its stackLayout
            resizeLayout.Children.Add(rowEntry);

            //A text box for inserting how many colums the grid will have
            Entry columEntry = new Entry();
            //Keybord numeric so the user only can insert numbers
            columEntry.Keyboard = Keyboard.Numeric;
            columEntry.Placeholder = "Number of Coloms";
            //Adding the entry to its stackLayout
            resizeLayout.Children.Add(columEntry);

            //The button we use to start the resizing
            Button resize = new Button();
            resize.Text = "Resize";
            //The event for what will happen when you click the button
            resize.Clicked += (sender, args) => InitializeGrid(grid, int.Parse(rowEntry.Text), int.Parse(columEntry.Text));
            //Adding the button to its stackLayout
            resizeLayout.Children.Add(resize);

            //Adding all the stackLayouts to a main StackLayout
            mainLayout.Children.Add(gridStack);
            mainLayout.Children.Add(resizeLayout);

            //Finaly we add the mainLayout to the content to show the layout
            Content = mainLayout;
        }

        //The method that is used to create the grid
        void InitializeGrid(Grid grid, int colum, int row)
        {
            //Starting with clearting everything in the grid so its emtpy
            grid.Children.Clear();

            //The to for loops for the row and colums
            for (int i = 0; i < colum; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    //The buttons we add the the grid with the position it has
                    Button but = new Button() {Text = i.ToString() +","+ j.ToString(), BackgroundColor = Color.White};
                    //Adding an event so when you click it will change the color of the button
                    but.Clicked += (sender, args) => ChangeColor(but);
                    //Adding the button to the grid
                    grid.Children.Add(but, i, j);
                }
            }
        }

        //A method to change the color of the button form black to white and back again
        void ChangeColor(Button button)
        {
            //Check if the button is black and changes it to white
            if (button.BackgroundColor == Color.Black)
            {
                button.BackgroundColor = Color.White;
                button.TextColor = Color.Black;
            }
            //Else if the button is not black we set its color to black
            else
            {
                button.BackgroundColor = Color.Black;
                button.TextColor = Color.White;
            }
        }

    }
}
