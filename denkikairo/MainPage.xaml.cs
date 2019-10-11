using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Numerics;

namespace denkikairo
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	//[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            Title = "Solve complex and phaser";
			InitializeComponent();

            add.IsEnabled = false;
            sub.IsEnabled = false;
            mul.IsEnabled = false;
            div.IsEnabled = false;
		}

        void OnEntryTextChanged(object sender, EventArgs args)
        {
            Entry entry = (Entry)sender;
            double save;

            add.IsEnabled = double.TryParse(num1.Text, out save) &&
                double.TryParse(numi1.Text, out save) &&
                double.TryParse(num2.Text, out save) &&
                double.TryParse(numi2.Text, out save);

            sub.IsEnabled = double.TryParse(num1.Text, out save) &&
                double.TryParse(numi1.Text, out save) &&
                double.TryParse(num2.Text, out save) &&
                double.TryParse(numi2.Text, out save);

            div.IsEnabled = double.TryParse(num1.Text, out save) &&
                double.TryParse(numi1.Text, out save) &&
                double.TryParse(num2.Text, out save) &&
                double.TryParse(numi2.Text, out save);

            mul.IsEnabled = double.TryParse(num1.Text, out save) &&
                double.TryParse(numi1.Text, out save) &&
                double.TryParse(num2.Text, out save) &&
                double.TryParse(numi2.Text, out save);
        }

		void solveAdd(object sender, EventArgs args)
		{
            double n1 = Double.Parse(num1.Text);
            double ni1 = Double.Parse(numi1.Text);
            double n2 = Double.Parse(num2.Text);
            double ni2 = Double.Parse(numi2.Text);

            Complex complex1 = new Complex(n1, ni1);
            Complex complex2 = new Complex(n2, ni2);

            Complex ans = complex1 + complex2;

            conplexNum.Text = string.Format(new ComplexFormatter(), "{0:J3}", ans);

            double abs = Complex.Abs(ans);
            double angle = Math.Atan(ans.Imaginary / ans.Real) * 180 / Math.PI;

            phaser.Text = abs.ToString("F3") + " ∠ " + angle.ToString("F3") + '°';
        }

		void solveSub(object sender, EventArgs args)
		{
            double n1 = Double.Parse(num1.Text);
            double ni1 = Double.Parse(numi1.Text);
            double n2 = Double.Parse(num2.Text);
            double ni2 = Double.Parse(numi2.Text);

            Complex complex1 = new Complex(n1, ni1);
            Complex complex2 = new Complex(n2, ni2);

            Complex ans = complex1 - complex2;

            conplexNum.Text = string.Format(new ComplexFormatter(), "{0:J3}", ans);

            double abs = Complex.Abs(ans);
            double angle = Math.Atan(ans.Imaginary / ans.Real) * 180 / Math.PI;

            phaser.Text = abs.ToString("F3") + " ∠ " + angle.ToString("F3") + '°';
        }

		void solveDiv(object sender, EventArgs args)
		{
			double n1 = Double.Parse(num1.Text);
			double ni1 = Double.Parse(numi1.Text);
			double n2 = Double.Parse(num2.Text);
			double ni2 = Double.Parse(numi2.Text);

			Complex complex1 = new Complex(n1, ni1);
			Complex complex2 = new Complex(n2, ni2);

			Complex ans = complex1 / complex2;

			conplexNum.Text = string.Format(new ComplexFormatter(), "{0:J3}", ans);

			double abs = Complex.Abs(ans);
			double angle = Math.Atan(ans.Imaginary/ans.Real) * 180 / Math.PI;

			phaser.Text = abs.ToString("F3") + " ∠ " + angle.ToString("F3") + '°';
		}

        void solveMul(object sender, EventArgs args)
        {
            double n1 = Double.Parse(num1.Text);
            double ni1 = Double.Parse(numi1.Text);
            double n2 = Double.Parse(num2.Text);
            double ni2 = Double.Parse(numi2.Text);

            Complex complex1 = new Complex(n1, ni1);
            Complex complex2 = new Complex(n2, ni2);

            Complex ans = complex1 * complex2;

            conplexNum.Text = string.Format(new ComplexFormatter(), "{0:J3}", ans);

            double abs = Complex.Abs(ans);
            double angle = Math.Atan(ans.Imaginary / ans.Real) * 180 / Math.PI;

            phaser.Text = abs.ToString("F3") + " ∠ " + angle.ToString("F3") + '°';
        }
	}

	public class ComplexFormatter : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
				return this;
			else
				return null;
		}

		public string Format(string format, object arg,
							 IFormatProvider provider)
		{
			if (arg is Complex)
			{
				Complex c1 = (Complex)arg;
				// Check if the format string has a precision specifier.
				int precision;
				string fmtString = String.Empty;
				if (format.Length > 1)
				{
					try
					{
						precision = Int32.Parse(format.Substring(1));
					}
					catch (FormatException)
					{
						precision = 0;
					}
					fmtString = "N" + precision.ToString();
				}
				if (format.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase))
					return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "i";
				else if (format.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase))
					return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "j";
				else
					return c1.ToString(format, provider);
			}
			else
			{
				if (arg is IFormattable)
					return ((IFormattable)arg).ToString(format, provider);
				else if (arg != null)
					return arg.ToString();
				else
					return String.Empty;
			}
		}
	}
}
