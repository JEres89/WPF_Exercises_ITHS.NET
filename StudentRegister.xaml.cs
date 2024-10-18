using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

// !!!!! Your custom class must not be a nested class. !!!!!

namespace WPF_Exercises_ITHS.NET;
/// <summary>
/// Interaction logic for StudentRegister.xaml
/// </summary>
public partial class StudentRegister : UserControl
{
	public string ContentName { get; set; } = "Students";

	[Bindable(true)]
    public ObservableCollection<Student> Students { get; set; } = new();
    public StudentRegister()
	{
		InitializeComponent();

		Students.Add(new Student("John", "Doe", "asd.asd@aasd.asd"));
		Students.Add(new Student("Jane", "Doe", "asd.asd@aasd.asd"));
		Students.Add(new Student("John", "Smith", "asd.asd@aasd.asd"));
	}

	public void Button_Click(object sender, RoutedEventArgs e)
	{
		if(studentCreateForm.DataContext is Student s)
			Students.Add(s);
		
		//studentList.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
		studentCreateForm.DataContext = new StudentValidationRule();

		if (sender is Button b)
		{
			b.GetBindingExpression(IsEnabledProperty).UpdateTarget();
		}
	}
}

public class Student
{
	public Student() { }
	public Student(string firstname, string lastname, string email)
	{
		Firstname = firstname;
		Lastname = lastname;
		Email = email;
	}

	[Bindable(true)]
	public string Firstname { get; 
		set; }
	[Bindable(true)]
	public string Lastname { get; set; }
	[Bindable(true)]
	public string Email { get; set; }

	public override string ToString()
	{
		return $"{Firstname} {Lastname}";
	}
}

public class StudentValidationRule : ValidationRule, INotifyPropertyChanged
{
	private string _firstName = "";
	private string _lastName = "";
	private string _email = "";
	private bool _isValid = false;
	public string Firstname {
		get => _firstName; 
		set {
			_firstName = value;
			if (_firstName.Length > 0)
				IsValid = true;
		}
	}
	public string Lastname
	{
		get => _lastName;
		set
		{
			_lastName = value;
			if (_lastName.Length > 0)
				IsValid = true;
		}
	}
	public string Email
	{
		get => _email;
		set
		{
			_email = value;
			if(_email.Length > 0)
				IsValid = true;
		}
	}
    public bool IsValid
	{
		get => _firstName.Length > 0 && _lastName.Length > 0 && _email.Length > 0;
		private set
		{
			if (_firstName.Length > 0 && _lastName.Length > 0 && _email.Length > 0)
			{
				OnPropertyChanged();
			}
		}
	}

	public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
	{
		if (value is string str)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				return new ValidationResult(false, "Field cannot be empty.");
			}
			return ValidationResult.ValidResult;
		}
		return new ValidationResult(false, "Invalid input");
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}


