using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Exercises_ITHS.NET;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{

		InitializeComponent();
		for (int i = 0; i*100 < Width; i++)
		{
			topRow.ColumnDefinitions.Add(
				new ColumnDefinition()
				{
					Width = new(1, GridUnitType.Star),
					MaxWidth = 100,
					MinWidth = 100
				}
				);
			var btn = new Button() { Content = "Button " + i, };
			btn.Click += (_, _) => Button_Click(i);
			topRow.Children.Add(btn);
			Grid.SetColumn(btn, i);
		}

		gridRowSelector.SelectedValuePath = "Row";
		gridRowSelector.DisplayMemberPath = "ContentType";
		for (int i = 0; i < mainContent.RowDefinitions.Count; i++)
		{
			
			gridRowSelector.Items.Add(new RowIdentifier(){Row = i, ContentType = mainContent.RowDefinitions[i].Name });
		}
		gridColSelector.SelectedValuePath = "Col";
		gridColSelector.DisplayMemberPath = "Field";
		for (int i = 0; i < mainContent.ColumnDefinitions.Count; i++)
		{
			gridColSelector.Items.Add(new ColumnIdentifier(){Col=i, Field=mainContent.ColumnDefinitions[i].Name });
		}
		//btnstack.Style = new(typeof (Button)) { Setters = { new Setter { Property = Button.BackgroundProperty, Value = Brushes.Red } } };
		//asd1.Click += (_,_) =>  Button_Click(1);
		//wasd.Click += (_,_) =>  Button_Click(2);
		//asd2.Click += (_,_) =>  Button_Click(3);
	}
	public class RowIdentifier
	{
		public int Row { get; init; }
		public required string ContentType { get; init; }
	}
	public class ColumnIdentifier
	{
		public int Col { get; init; }
		public required string Field { get; init; }
	}
	private void Button_Click(int buttonNr)
	{

		switch (buttonNr)
		{
			//case 1:
			//	textbox.Text = "Button 1 clicked";
			//	break;
				
			//case 2:
			//	textbox.Text = "Button 2 clicked";
			//	break;
				
			//case 3:
			//	textbox.Text = "Button 3 clicked";
			//	break;

			default:
				break;
		}
	}

	private void Button_Click_Create(object sender, RoutedEventArgs e)
	{
		var name = elementName.Text;
		var type = elementType.Text;
		var row = gridRowSelector.SelectedIndex;
		var col = gridColSelector.SelectedIndex;

		switch (type)
		{
			case "TextBlock":
				var newText = new TextBlock() { Text = name, TextWrapping = TextWrapping.Wrap };
				mainContent.Children.Add(newText);
				Grid.SetRow(newText, row);
				Grid.SetColumn(newText, col);
				break;

			case "Button":
				var newButton = new Button() { Content = name };
				mainContent.Children.Add(newButton);
				Grid.SetRow(newButton, row);
				Grid.SetColumn(newButton, col);
				break;

			case "DataGrid":
				var newGrid = new DataGrid() { Name = name };
				mainContent.Children.Add(newGrid);
				Grid.SetRow(newGrid, row);
				Grid.SetColumn(newGrid, col);
				break;

			case "TabPanel":
				var newTabPanel = new TabControl() { Name = name };
				mainContent.Children.Add(newTabPanel);
				Grid.SetRow(newTabPanel, row);
				Grid.SetColumn(newTabPanel, col);
				break;

			default:
				break;
		}

	}

	private void elementName_TextChanged(object sender, TextChangedEventArgs e)
	{
		//var asd = new Binding();
		//asd.Converter
	}

	private void elementName_GotFocus(object sender, RoutedEventArgs e)
	{
		txtNamePlaceholder.Visibility = Visibility.Hidden;
	}

	private void elementName_LostFocus(object sender, RoutedEventArgs e)
	{
		if (elementName.Text.Length == 0)
		{
			txtNamePlaceholder.Visibility = Visibility.Visible;
		}
		else
		{
			txtNamePlaceholder.Visibility = Visibility.Hidden;
		}
	}
}

public static class  WPFExtenstions
{
	public static void GridExt(this Grid g)
	{

	}

}
