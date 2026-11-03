using System;
using System.Windows.Forms;

namespace PayrollApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Inputs configuration based on assignment requirements
                decimal dailyRate = 755.00m; // Daily basic pay (or 19,630 monthly equivalent)
                decimal hoursWorked = 8.0m;  
                decimal otHours = 0.0m;       
                decimal specialHolHours = 0.0m; 
                decimal regularHolHours = 0.0m; 
                decimal lateMinutes = 0.0m;   
                decimal absencesDays = 0.0m;  

                // 1. Hourly pay calculation
                decimal hourlyPay = dailyRate / 8.0m;

                // 2. OT Pay (+30% premium)
                decimal otPay = otHours * (hourlyPay * 1.30m);

                // 3. Special Holiday (+30% premium)
                decimal specialHolidayPay = specialHolHours * (hourlyPay * 1.30m);

                // 4. Holiday Pay (+100% premium / double pay)
                decimal regularHolidayPay = regularHolHours * (hourlyPay * 2.00m);

                // Regular earnings for hours worked
                decimal regularEarnings = hoursWorked * hourlyPay;

                // Deductions calculations
                decimal lateDeduction = lateMinutes * (hourlyPay / 60.0m);
                decimal absenceDeduction = absencesDays * dailyRate;

                // 5. Gross Pay = (Earnings + OT + Holidays) - (Absences + Late)
                decimal grossPay = (regularEarnings + otPay + specialHolidayPay + regularHolidayPay) - (absenceDeduction + lateDeduction);

                // Statutory Deductions
                decimal sss = grossPay * 0.04m; // 4% of Gross Pay
                decimal hmdf = 200.00m;          // Fixed Pag-IBIG
                decimal phealth = 200.00m;       // Fixed PhilHealth

                // 6. Net Pay = Gross Pay - Total Deductions
                decimal netPay = grossPay - (sss + hmdf + phealth);

                // Display exact values
                MessageBox.Show(
                    $"1. Hourly Pay: ₱{hourlyPay:N2}\n" +
                    $"2. OT Pay: ₱{otPay:N2}\n" +
                    $"3. Special Holiday Pay: ₱{specialHolidayPay:N2}\n" +
                    $"4. Holiday Pay: ₱{regularHolidayPay:N2}\n" +
                    $"5. Gross Pay: ₱{grossPay:N2}\n" +
                    $"6. Net Pay: ₱{netPay:N2}", 
                    "Payroll Calculation Results", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
